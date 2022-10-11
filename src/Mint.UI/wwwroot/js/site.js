const dropdownItem = document.querySelector(".drop-down-menu");
const rotateDropdownIco = document.querySelector(".header-top-dropdown-ico");

dropdownItem.addEventListener("click", () => {
    rotateDropdownIco.classList.toggle("header-top-dropdown-ico-active");
    document.querySelector("#menuList").classList.toggle("menu-dropdown-childs-active");
});

window.addEventListener("click", event => {
    if (!event.target.matches("#activeDropDownMenu")) {
        var list = document.getElementsByClassName("header-top-child-list");
        for (var i = 0; i < list.length; i++) {
            var openList = list[i];
            if (openList.classList.contains("menu-dropdown-childs-active")) {
                openList.classList.remove("menu-dropdown-childs-active");
                rotateDropdownIco.classList.remove("header-top-dropdown-ico-active");
            }
        }
    }
});