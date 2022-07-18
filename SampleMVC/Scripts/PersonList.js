
$(document).ready(function () {
    //GetData();
    function GetData() {
        var data = " ";
        $.ajax({
            url: "/Person/List",
            type: "GET",
            success: function (result) {
                //result = JSON.parse(result);
                //Console.log(result);
                $(".perslon-list").html('');
                $(".perslon-list").html(result);
            },
            error: function (err) {
                Console.error(err);
            }
        });
    }
    $("#btnAjax").click(function () {
        GetData();
    });
});
