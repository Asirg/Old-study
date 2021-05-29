
var x1 = 0;
var y1 = 0;
var x2 = 0;
var y2 = 0;

var x = 0;
var y = 0;

var opr = [3,2,5,1,5,1];

var X = 0;
var Y = 0;

// ----------------
var v1 = 0;
var er1 = 0;

var v2 = 0;
var er2 = 0;
// ----------------
var vx = 0;
var vy = 0;

document.getElementById('op03').style.background = '#bdddf4';
document.getElementById('op12').style.background = '#bdddf4';

document.getElementById('op25').style.background = '#bdddf4';
document.getElementById('op31').style.background = '#bdddf4';

document.getElementById('op45').style.background = '#bdddf4';
document.getElementById('op51').style.background = '#bdddf4';

function round(delta,num)
{
	var power = Math.pow(10,Math.floor(Math.abs(Math.log10(delta)))+num);
	return Math.ceil(delta*power)/power;
}

function butt_radio (num, op){
	document.getElementById(('op'+ num) + opr[num]).style.background = '#fff';
	document.getElementById(('op' + num) + op).style.background = '#bdddf4';
	opr[num]=op;
}
function result1(){
	switch (opr[0]) {
		case 1: X = x1*x2; break;
		case 2: X = x1/x2; break;
		case 3: X = Math.pow(x1,(1/x2)); break;
		case 4: X = Math.pow(x1,x2); break;
	}

	switch (opr[1]) {
		case 1: Y = y1*y2; break;
		case 2: Y = y1/y2; break;
		case 3: Y = Math.pow(y1,(1/y2)); break;
		case 4: Y = Math.pow(y1,y2); break;
	}

	document.getElementById('res1-X').innerHTML = X;
	document.getElementById('res1-Y').innerHTML = Y;

	var delta_x =Math.abs(x-X);
	var delta_y =Math.abs(y-Y);

	document.getElementById('res1-dx').innerHTML = delta_x;
	document.getElementById('res1-dy').innerHTML = delta_y;

	document.getElementById('res1-bdx').innerHTML = round(delta_x,2);
	document.getElementById('res1-bdy').innerHTML = round(delta_y,2);


	var relativ_x=round(delta_x,2)/x;
	var relativ_y=round(delta_y,2)/y;

	document.getElementById('res1-rx').innerHTML = relativ_x;
	document.getElementById('res1-ry').innerHTML = relativ_y;

	document.getElementById('res1-orx').innerHTML = round((round(relativ_x,2)*100),2) + '%';
	document.getElementById('res1-ory').innerHTML = round((round(relativ_y,2)*100),2) + '%';
}

function round_border(type,er){
	var power = Math.floor(Math.abs(Math.log10(er)))+1
	var border_absolute = type/(Math.pow(10,power));
	if (border_absolute > er)
		return border_absolute;
	return border_absolute*10;
}
function round_num(num,er){
	var power = Math.pow(10,Math.floor(Math.abs(Math.log10(er))));
	return Math.round(num*power)/power;
}
function result2(val,er,type,html){

	if(val != 0 && er != 0)
	{
		alert(val);
		String(er);
		if(er[er.length-1] === '%')
			er = val*Number(er.replace('%','')/100);
		else
			er = Number(er);
		var border_absolute = round_border(type,er);
		for(;; border_absolute*=10)
		{
			var round_val = round_num(val,border_absolute);
			var estimate = er + Math.abs(round_val - val);
			if(estimate < border_absolute )
			{
				document.getElementById('res2-'+html).innerHTML = round_val;
				break;
			}
		}
	}
}

function result3(val,type,html){
	if (val != 0) {
		var delta = type/Math.pow(10, String(val).length-String(val).indexOf('.'));
		if(type == 1)
			delta*=10;
		document.getElementById('res3-d'+html).innerHTML = round(delta,2);
		document.getElementById('res3-r'+html).innerHTML = round((round(delta/val,2)*100),2) + '%';
	}
}

