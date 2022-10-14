$(".login-btn-w").click((e) => {
    e.preventDefault();
    $(".login-btn-w").html("");
    $(".login-btn-w").append("<span class='loader'/>")
    $(".loader").removeClass("hidden");
    setTimeout(function() {
        $("form").submit();
    }, 1);
});