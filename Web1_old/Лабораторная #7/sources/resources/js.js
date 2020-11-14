const form_name = document.getElementById("Name_form");
const form_email = document.getElementById("Email_form");


form_name.nm.value = ((!localStorage.getItem("nm"))?"":localStorage.getItem("nm"));
form_email.em.value = ((!localStorage.getItem("em"))?"":localStorage.getItem("em"));

function save(me)
{
	localStorage.setItem(me.id,me.value);
}
form_name.addEventListener('submit', function(e) {
  e.preventDefault();
  alert("Збережено");
 	localStorage.setItem(nm.id,nm.value);
});
form_email.addEventListener('submit', function(e) {
  e.preventDefault();
  alert("Збережено");
  localStorage.setItem(em.id,em.value);
});
