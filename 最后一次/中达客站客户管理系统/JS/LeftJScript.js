
function $(obj){return document.getElementById(obj)}
function Tab(Xname,Cname,Lenght,j){for(i=1;i<Lenght;i++){eval("$('"+Xname+i+"').className='n2'");}eval("$('"+Xname+j+"').className='n1'");for(i=1;i<Lenght;i++){eval("$('"+Cname+i+"').style.display='none'");eval("$('"+Cname+j+"').style.display='block'");}}
