const plus = document.querySelector("#addNewField");
const card = document.querySelector(".card");

plus.addEventListener("click", (event) => {
    event.preventDefault();

    let i = 1;

    var div = document.createElement("div");
    div.className = "mb-3 px-2";

    var nameLabel = document.createElement("label");
    nameLabel.textContent = "Бренд";
    nameLabel.className = "form-label";
    nameLabel.htmlFor = "BrandName";

    var nameInput = document.createElement("input");
    nameInput.className = "form-control";
    nameInput.placeholder = "Название";
    nameInput.name = "BrandName";
    nameInput.id = "name" + i;

    var fileLabel = document.createElement("label");
    fileLabel.className = "form-label";
    fileLabel.textContent = "Фото для - ";
    fileLabel.htmlFor = "file" + i;

    var fileInput = document.createElement("input");
    fileInput.type = "file";
    fileInput.className = "form-control";
    fileInput.name = "BrandImage";
    fileInput.id = "file" + i;

    div.appendChild(nameLabel);
    div.appendChild(nameInput);
    div.appendChild(fileLabel);
    div.appendChild(fileInput);

    card.appendChild(div);

    i++;
});