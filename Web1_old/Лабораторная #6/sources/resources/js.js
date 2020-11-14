
let full_screen = false;
let last_img_style = NaN;

class gallery extends HTMLElement{
	constructor()
	{
		super()
		const shadow = this.attachShadow({mode:'open'}); //Создание тиневого рута

		const styles = document.createElement("style"); //Добавление стиля под тэги кастумного елемента
		styles.innerHTML = `
			#photo-gallery
			{
				display: flex;
				flex-wrap: wrap;
				justify-content: center;
			}
			#photo-gallery div
			{
				margin:10px;
				width: 300px;
				height: 300px;
				overflow: hidden;
				transition: all 0s;
				display: flex;
				justify-content: center;
				align-items: center;
			}
			#photo-gallery div#spec
			{
				z-index:1;
				top: 0;
				position: fixed;
				margin:0;
				height: 100vh;
				width: 100vw;
				transition: all 1.5s;
			}
		`;
		shadow.appendChild(styles); //Добавление стиля в кастумный елемент

		const div = document.createElement("div");	//Пространство галереи
		div.setAttribute("id","photo-gallery");
		shadow.appendChild(div);

		if(this.hasAttribute('list-img'))						//Проверка на наличие атрибута со списком ссылок на изображения галереи
		{
			let list = this.getAttribute('list-img').split(';');
			for(let i of list)																		//Добавления каждого изображения
			{
				const el = document.createElement("div");
				el.setAttribute("onclick", "click_image(this)")

				const img = document.createElement("img");
				img.setAttribute("onerror",'this.src = "resources/gallery/error.png"');
				img.setAttribute("src",i);
				el.appendChild(img);
				div.appendChild(el);
			}
		}else{																			//Случай отсутствия необходимого атрибута
			const img = document.createElement("img");
			img.setAttribute("style","width:100%;height:100%;")
			img.setAttribute("src","resources/gallery/error.png");
			div.appendChild(img);
		}
		window.addEventListener('load', (event) => {			//Добавление форматирования изображений галерее после полной загрузки страницы
  		formating_image(shadow);
		});
	}
}

 window.onload = function () {										//Preloaded Анимация
   document.body.classList.add('loaded');
 }
customElements.define('photo-gallery', gallery);	//Определения кастумного елемента в html

function click_image(image) 			//Увеличение изображений на весь экран 
{
	if(full_screen)
	{
		image.setAttribute("id", "")
		image.firstChild.setAttribute("style",last_img_style)
		full_screen = false;
	}
	else
	{
		image.setAttribute("id","spec");
		const img = image.firstChild;
		last_img_style = img.getAttribute("style");


		if(document.documentElement.clientWidth > document.documentElement.clientHeight){
			img.setAttribute("style","height:98vh;border: 0.5vh solid white; margin:0.5vh");
		}
		else{
			if(img.getBoundingClientRect().height <= img.getBoundingClientRect().width){
			img.setAttribute("style","width:96vw;border: 0.5vw solid white; ");
			}else
			{
				img.setAttribute("style","height:98vh;border: 0.5vh solid white; margin:0.5vh");
			}
		}
		full_screen = true;
	}
}
function formating_image(sh) //Форматирования размера изображений, для коректного отображения в обрезаном ввиде галереи
{
 const photo_gallery = 	sh.getElementById("photo-gallery");
 for (let i of photo_gallery.childNodes)
 {
 	const img = i.firstChild;
 	if(img.getBoundingClientRect().height > img.getBoundingClientRect().width)
 		img.setAttribute("style","width:100%");
 	else
 		img.setAttribute("style","height:100%");
 }
}