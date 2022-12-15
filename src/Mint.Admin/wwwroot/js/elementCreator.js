let i = 1;
let j = 1;
let categoryList = [];

function addCategoryField() {
    var div = document.createElement("div");
    div.className = "mb-3 px-2";
    div.id = "categoryCardId";

    div.appendChild(createLabel("form-label", "Категория", "categoryName" + i));
    div.appendChild(createInput("form-control", "Категория", "CategoryName", "categoryName" + i, "text"));
    div.appendChild(createLabel("form-label", "Фото для Категории", "categoryFile" + i));
    div.appendChild(createInput("form-control", "", "CategoryFile", "categoryFile" + i, "file"));

    categoryCard.appendChild(div);
    categoryList.push(div);

    i++;
}

//div.appendChild(createLabel("form-label", "Категория", "categoryName" + i));
//div.appendChild(createInput("form-control", placeholder, name, `${id}${i}`, type));
//div.appendChild(createLabel("form-label", "Фото для Категории", "categoryFile" + i));
//div.appendChild(createInput("form-control", placeholder, name, `${id}${i}`, type));

function removeLastCategoryField() {
    if (i > 0) {
        document.querySelector("#categoryCardId").remove();
        i--;
    }
}

function createInput(className, placeholder, name, id, type) {
    var categoryInput = document.createElement("input");
    categoryInput.className = className;
    categoryInput.placeholder = placeholder;
    categoryInput.name = name;
    categoryInput.id = id;
    categoryInput.type = type;
    categoryInput.required = true;
    return categoryInput;
}

function createLabel(className, textContent, htmlFor) {
    var categoryLabel = document.createElement("label");
    categoryLabel.className = className;
    categoryLabel.textContent = textContent;
    categoryLabel.htmlFor = htmlFor;
    return categoryLabel;
}