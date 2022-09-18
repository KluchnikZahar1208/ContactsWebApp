let form = document.getElementById("form");
let inputName = document.getElementById("inputName");
let inputPhone = document.getElementById("inputPhone");

form.setAttribute("required", "")

inputName.setAttribute("maxLength", 30)
inputName.addEventListener('keyup', () => { inputName.value = inputName.value.replace(/[^a-zA-Z\.]/g, ''); });

inputPhone.setAttribute("maxLength", 18)
inputPhone.addEventListener('keyup', () => { inputPhone.value = inputPhone.value.replace(/[^0-9\.]/g, ''); });