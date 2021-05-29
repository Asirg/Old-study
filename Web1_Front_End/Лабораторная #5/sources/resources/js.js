let Name = 'Asir';
let Surname = "Muminov";

let isMale = true;

let day_OfBirth = "13";
let month_OfBirth = "2";
let year_OfBirth = "2000";

let asced = 0;

class Persona
{
	constructor(Name,Surname,isMale,day_OfBirth, month_OfBirth,year_OfBirth,fisc){
		this.Name = Name;
		this.Surname = Surname;

		this.isMale = isMale;

		this.day_OfBirth = day_OfBirth;
		this.month_OfBirth = month_OfBirth;
		this.year_OfBirth = year_OfBirth;
		this.fisc = fisc;
	}
	calculation_fiscal_code()
	{
		return (this.NameSur_fiscal_code(this.Surname, 1) + this.NameSur_fiscal_code(this.Name, 0) + this.DataGen_fiscal_code());
	}
	NameSur_fiscal_code(NameSur, type)
	{
	 	const array_vowels = 'aiueoyауоыиэяюёеії'; 
	 	NameSur = NameSur.toLowerCase();
	 	let text = '';

		let k = 0;
		for (let i of NameSur)
		{
			let NOTvowels = true;
			for(let j of array_vowels)
			{ 
				if(i == j)
				NOTvowels = false;
			}
			if(NOTvowels)
			{
				if (type != 0 || k < 3)
					text += i;
				else{
					text = text.replace(text[2], i);
				}
				k++;
			}
			if((k==3 && type != 0) || k == 4)
				break;
		}
		if(k <3)
		{
			for(let i of NameSur)
			{
				for(let j of array_vowels)
				{
					if(i == j)
					{ 
						text += i;
						k++;
					}
				}
				if(k == 3)
					break;
			}
		}
		if(k < 3)
		{
			for(let i = 0; i < (3-NameSur.length); i++)
				text += "X";
		}
		return text.toUpperCase();
	}
	DataGen_fiscal_code ()
	{
		const array_vowels = 'aiueoyауоыиэяюёеії'; 
	 	const months = { 1: "A", 2: "B", 3: "C", 4: "D", 5: "E", 6: "H", 7: "L", 8: "M", 9: "P", 10: "R", 11: "S", 12: "T" }
	 	let text = '';
	 	text += this.year_OfBirth[2] + this.year_OfBirth[3] + months[month_OfBirth]
	 	+((isMale)?(this.day_OfBirth.length <2)?"0" + this.day_OfBirth:this.day_OfBirth:40+Number(this.day_OfBirth));
	 	return text;
	}

}
function output_fiscal_code ()
 {
	let per = new Persona(Name,Surname,isMale,day_OfBirth,month_OfBirth,year_OfBirth);
	let code = document.getElementById('fiscal-code-output').innerHTML = per.calculation_fiscal_code();
}

function Output_harshard(num)
{
	if(!isNaN(num))
	{
		let sum = 0;
		const num_div = num;
		for (; num >= 1; num = Math.trunc(num/10))
			sum += num%10;
		document.getElementById('harshard-output').innerHTML = (num_div%sum == 0)?"Так":"Ні";
	}else
		document.getElementById('harshard-output').innerHTML = "<span style='color:red'>Введіть число</span>";
}
function ascending()
{
	document.getElementById('console').innerHTML = "";
	num = asced;
  if(!isNaN(num))
	{
	 	let asc = false;
	 	for(let i = 1; i <= Math.trunc(num.length/2); i++)
	 	{
	 		let s = 0;
	 		asc = true;
	 		for(let j = i; s<num.length-j;)
	 		{
	 			if(Number(num.slice(s+j,s+j+j))- Number(num.slice(s,s+j)) == 1)
	 		 		s+=j;
	 			else if(Number(num.slice(s+j,s+j+j+1)) - Number(num.slice(s,s+j)) == 1)
	 		 	{
	 		 		s+=j;
	 		 		j++;
	 		 	}
	 		 	else
	 		 	{
	 		 		asc=false;
	 		 		break;
	 		 	}
	 		}
	 		if(asc)
	 			break;
	 	}
	 	document.getElementById('ascending-output').innerHTML = (asc)?"Так":"Ні";
	}else
	 	document.getElementById('ascending-output').innerHTML = "<span style='color:red'>Введіть число</span>";
}