$.validator.addMethod("cellphone", function (value, element, param) {
    2
    if (value == false) return true;//not input
    3
    return (/\d{4}-\d{6}/.test(value)) //has input
    4
});
5
$.validator.unobtrusive.adapters.addSingleVal("cellphone", "input");
