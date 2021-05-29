let request = new XMLHttpRequest(); // Об'єкт для створення запитів

const key = prompt("Введіть ключ");
const urlConstRequest = 'https://cloud.iexapis.com/v1/stock/market/batch?symbols=MSFT,INTC,ATVI,EA,GOOGL,AMD,NFLX,TSLA&types=quote&filter=symbol,companyName,latestPrice,change&token=' + key;
const urlDinamicRequest = 'https://cloud.iexapis.com/v1/stock/market/batch?symbols=MSFT,INTC,ATVI,EA,GOOGL,AMD,NFLX,TSLA&types=quote&filter=latestPrice,change&token=' + key;
let latestUpdate_Table = 0;

request.open('GET', urlConstRequest, true); // Перший запит на отримання всіх необхідних данних
request.onreadystatechange = function() // Отримання відповіді
{
	if (request.readyState === XMLHttpRequest.DONE && request.status === 200){ //ReadyState DONE - операція повністю виконана , status 200 - без помилок
		creat_table(JSON.parse(request.response));
		latestUpdate_Table = Date.now();
	}
}
request.send('');


rxjs.interval(20000) //Виклик оновлення данних
.subscribe(() => {
	request.open('GET', urlDinamicRequest, true); // запити для оновлення всіх необхідних данних
	request.onreadystatechange = function() 		// Отримання відповіді
	 {
		if (request.readyState === 4 && request.status === 200) {
				update_table(JSON.parse(request.response),Date.now());
			latestUpdate_Table = Date.now();
		}
	}
	request.send('');
});

rxjs.interval(100) //Таймер часу останнього оновлення
.subscribe(() => { document.getElementById('latestUpdate').textContent = ((Date.now() - latestUpdate_Table) / 1000).toFixed(1); });

function creat_table(data) //Загальне створення таблиці
{
	let table = document.getElementById("TableData");

	for (i in data)
	{
		let tr = document.createElement('tr');
		let z = 0;
		for (j in data[i].quote)
		{
			let td = document.createElement('td');
			td.textContent = data[i].quote[j] + ((z>1)?" $":"");
			tr.appendChild(td);
			z++;
		}
		table.appendChild(tr);
	}
	document.getElementById('Table').appendChild(table);
}
function update_table(data)
{
	const rows =  document.getElementById('TableData').rows;
	let x = 0;
	for (i in data)
	{
		let z = 2;
		for (j in data[i].quote)
		{
			rows[x].cells[z].textContent = data[i].quote[j] + " $";
			z++;
		}
		x++;
	}
}
