﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const select = document.querySelector(".attr-selected");
$(document).ready(function () {
    $('.js-example-basic-multiple').select2();
    select.removeAttribute("multiple");
});
