const dropdownItem = document.querySelector(".drop-down-menu");
const rotateDropdownIco = document.querySelector(".header-top-dropdown-ico");
const mList = document.querySelector("#menuList");
// const userBox = document.querySelector("#userBox");
// const userMenuList = document.querySelector(".signed-user-func");

// userBox.addEventListener("click", () => {
//     userMenuList.classList.toggle("signed-user-func-active");
// });

dropdownItem.addEventListener("click", () => {
    rotateDropdownIco.classList.toggle("header-top-dropdown-ico-active");
    mList.classList.toggle("menu-dropdown-childs-active");
});

window.addEventListener("click", event => {
    // if (!event.target.matches("#userBox")) {
    //     var list = document.getElementsByClassName("signed-user-func");
    //     for (var i = 0; i < list.length; i++) {
    //         if (list[i].classList.contains("signed-user-func-active")) {
    //             list[i].classList.remove("signed-user-func-active");
    //         }
    //     }
    // }

    if (!event.target.matches("#activeDropDownMenu")) {
        var list = document.getElementsByClassName("header-top-child-list");
        for (var i = 0; i < list.length; i++) {
            if (list[i].classList.contains("menu-dropdown-childs-active")) {
                list[i].classList.remove("menu-dropdown-childs-active");
                rotateDropdownIco.classList.remove("header-top-dropdown-ico-active");
            }
        }
    }
});



const buttons = document.querySelectorAll("a[class^=abubakr-c");
buttons.forEach(button => {
    button.addEventListener("click", event => {
        event.preventDefault();

        var tabContent = document.getElementsByClassName("tb-content");
        var tablinks = document.getElementsByClassName("abubakr-c");

        for (var i = 0; i < tabContent.length; i++) {
            tabContent[i].style.display = "none";
        }

        for (var i = 0; i < tabContent.length; i++) {
            tablinks[i].className = tablinks[i].className.replace(" cnt-a-active", "");
        }

        const x = document.querySelector("." + button.id);
        x.style.display = "block";
        event.currentTarget.className += " cnt-a-active";
    });
});