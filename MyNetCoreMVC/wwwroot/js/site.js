// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(document).ready(function () {
    $(".btnDelete").click(function () {
        var currentbtn = $(this);
        if (confirm("Do yo want to delete this student")) {
            $.ajax({
                url: "/Product/Delete?id=" + currentbtn.attr("id"),
                method: "DELETE",
                success: function () {
                    $("alert-success").text("Delete Success")
                    currentbtn.closest("li").remove();
                },
                error: function () {
                    $("alert-danger").text("Delete Failed")
                }
            });
        }
    });
})