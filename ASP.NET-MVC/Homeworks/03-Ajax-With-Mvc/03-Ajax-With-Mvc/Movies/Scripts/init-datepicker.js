$(function () {
    initDatepickers();
});

function initDatepickers() {
    ApplyValidation();
    $(".datefield").datepicker({ dateFormat: "mm/dd/yy", changeYear: true, yearRange: "-150:+0" });
}

function ApplyValidation() {
    $("form").removeData("validator");
    $("form").removeData("unobtrusiveValidation");
    $.validator.unobtrusive.parse("form");
}