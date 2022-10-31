$("#categoryLi").click(() => {
    $(document).ready(() => {
        $(".progress-bar").show();
        $(".progress-bar").width("25%");
        $(".progress-bar").width("45%");
        $.ajax({
            url: "https://localhost:7190/api/category/getcategories",
            type: "GET",
            contentType: 'application/json',
            dataType: "JSON",
            success: function (data, textStatus, xhr) {
                $(".progress-bar").width("85%");
                console.log(data);
                console.log(textStatus);
                console.log(xhr);
                setTimeout(() => {
                    $(".progress-bar").hide();
                }, 1000);
            },
            error: function (xhr) {
                console.log("Error when fetchong");
                console.log(xhr);
            }
        });
    });
});