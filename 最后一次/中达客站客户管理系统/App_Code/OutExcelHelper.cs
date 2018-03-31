using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Configuration;
using ZDDB.DAL;
using ZDDB.BLL;
using ZDDB.Model;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


/// <summary>
///OutExcelHelper 的摘要说明
/// </summary>
public class OutExcelHelper
{
   public OutExcelHelper()
       {
        //
        //TODO: 在此处添加构造函数逻辑
         //
        }

        //创建字典表
        public static Dictionary<string, string> foreignKeys = new Dictionary<string, string>();




       //构造方法
        static OutExcelHelper()
       {
           foreignKeys.Add("CustomersTB", "CusName");
           foreignKeys.Add("CarrieCompanyTB", "CoName");
       
       }
      public static void DisableControls(Control gv)
    {

        LinkButton lb = new LinkButton();

        Literal l = new Literal();

        string name = String.Empty;

        for (int i = 0; i < gv.Controls.Count; i++)
        {

            if (gv.Controls[i].GetType() == typeof(LinkButton))
            {

                l.Text = (gv.Controls[i] as LinkButton).Text;

                gv.Controls.Remove(gv.Controls[i]);

                gv.Controls.AddAt(i, l);

            }
            else if (gv.Controls[i].GetType() == typeof(DropDownList))
            {
                l.Text = (gv.Controls[i] as DropDownList).SelectedItem.Text;

                gv.Controls.Remove(gv.Controls[i]);

                gv.Controls.AddAt(i, l);

            }

            if (gv.Controls[i].HasControls())
            {
                DisableControls(gv.Controls[i]);
            }

        }

    }

      public static void ExportExcel<T>(List<T> objList, string FileName, Dictionary<string, string> columnInfo)
      {
          if (columnInfo.Count == 0)
              return;
          if (objList.Count == 0)
              return;
          //生成EXCEL的HTML
          string excelStr = "";

          Type myType = objList[0].GetType();
          //根据反射从传递进来的属性名信息得到要显示的属性
          //根据反射从传递进来的属性名信息得到要显示的属性
          List<PropertyInfo> myPro = new List<PropertyInfo>();
          foreach (string cName in columnInfo.Keys)
          {
              PropertyInfo p = myType.GetProperty(cName);
              if (p != null)
              {
                  myPro.Add(p);
                  excelStr += columnInfo[cName] + "\t";
              }
          }
          //如果没有找到可用的属性则结束
          if (myPro.Count == 0) { return; }
          excelStr += "\n";

          foreach (T obj in objList)
          {
              foreach (PropertyInfo p in myPro)
              {
                  string str = "";

                  Object objec = p.GetValue(obj, null);
                  if (objec != null)
                  {
                      //判断objec是否是外键对象类型，如果不是，直接返回
                      if (Type.GetTypeCode(objec.GetType()) == TypeCode.String || Type.GetTypeCode(objec.GetType()) == TypeCode.Int64 || Type.GetTypeCode(objec.GetType()) == TypeCode.Int32 || Type.GetTypeCode(objec.GetType()) == TypeCode.Double || Type.GetTypeCode(objec.GetType()) == TypeCode.DBNull)
                      {
                          str = objec.ToString().Trim();
                      }
                      else if (Type.GetTypeCode(objec.GetType()) == TypeCode.DateTime)
                      {
                          str = Convert.ToDateTime(objec).ToString("yyyy-M-d");
                      }

                      else
                      {
                          CustomersTB Customers = objec as CustomersTB;
                          if (Customers != null)
                          {
                              str = GetObjectPropertyValue(Customers);
                          }
                          else
                          {
                              CarrieCompanyTB carriecompany = objec as CarrieCompanyTB;
                              if (carriecompany != null)
                              {
                                  str = GetObjectPropertyValue(carriecompany);
                              }

                          }
                      }

                      if ((p.Name == "CusTel" || p.Name == "Telephone" || p.Name == "LinkmanTel" || p.Name == "BeginNo" || p.Name == "Rid" || p.Name == "CSid" || p.Name == "EndNo") && str != "")
                      {
                          excelStr += "'" + str + "\t";
                      }
                      else
                      {
                          excelStr += str + "\t";
                      }
                  }
                  else
                  {
                      excelStr += "\t";
                  }
              }
              excelStr += "\n";
          }
          //输出Excel
          HttpResponse rs = System.Web.HttpContext.Current.Response;
          rs.Clear();
          rs.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
          rs.AppendHeader("Content-Disposition", "attachment;filename=" + System.Web.HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8));
          rs.ContentType = "application/ms-excel";
          rs.Write(excelStr);
          rs.End();
      }
      /// <summary>
      /// 获取外键对象的类型，根绝构造方法中定义的获取字段的值
      /// </summary>
      /// <typeparam name="T"></typeparam>
      /// <param name="t"></param>
      /// <returns></returns>
      public static string GetObjectPropertyValue<T>(T t)
      {
          Type type = typeof(T);

          PropertyInfo property = type.GetProperty(foreignKeys[type.Name]);

          if (property == null) return string.Empty;

          object o = property.GetValue(t, null);

          if (o == null) return string.Empty;

          return o.ToString();
      }
      /// <summary>
      /// 导出GridView中的内容
      /// </summary>
      /// <param name="filename"></param>
      /// <param name="gv"></param>
      public static void OutPutExcel(string filename, GridView gv)
      {
          string style = @"<style> .text { mso-number-format:\@; } </script> "; //解决第一位字符为零时不显示的问题]

          filename = HttpUtility.UrlEncode(filename, System.Text.Encoding.UTF8);//解决导出EXCEL时乱码的问题
          HttpResponse resp = System.Web.HttpContext.Current.Response;
          resp.Clear();

          resp.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
          resp.ContentType = "application/excel";
          resp.AppendHeader("Content-Disposition", "attachment;filename=" + filename);

          System.IO.StringWriter sw = new System.IO.StringWriter();//定义一个字符串写入对象
          HtmlTextWriter htw = new HtmlTextWriter(sw);//将html写到服务器控件输出流

          gv.RenderControl(htw);//将控件GRIDVIEW中的内容输出到HTW中
          resp.Write(style);
          resp.Write(sw);
          resp.End();
      }

}
