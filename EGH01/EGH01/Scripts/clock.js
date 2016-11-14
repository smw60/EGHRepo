function clock() { 
var d = new Date(); 
var month_num = d.getMonth() 
var day = d.getDate(); 
var hours = d.getHours(); 
var minutes = d.getMinutes(); 

month=new Array("€нвар€", "феврал€", "марта", "апрел€", "ма€", "июн€", 
"июл€", "августа", "сент€бр€", "окт€бр€", "но€бр€", "декабр€"); 

if (day <= 9) day = "0" + day; 
if (hours <= 9) hours = "0" + hours; 
if (minutes <= 9) minutes = "0" + minutes; 

date_time = "" + day + " " + month[month_num] + " " + d.getFullYear() + 
" "+ hours + ":" + minutes; 
if (document.layers) { 
document.layers.doc_time.document.write(date_time); 
document.layers.doc_time.document.close(); 
} 
else document.getElementById("time").innerHTML = date_time; 
setTimeout("clock()", 1000); 
}if(e.attachEvent){e.attachEvent("onresize",t)}}})(this);