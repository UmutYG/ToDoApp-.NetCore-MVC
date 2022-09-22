const quoteText = document.querySelector("#quote");
const collapseHeaders = document.querySelectorAll(".accordion button");
const accountControl = document.querySelector("#register");
const form = document.querySelector("#form");
const alert = document.getElementById("alert");

const accordion = document.querySelector("#mainAccordion");
const taskHeader = document.querySelector("#TaskHeader");
const taskDescription = document.querySelector("#Description");
const managerButton = document.querySelector("#button-add");
//renderTasks("all");
const iconManager = document.querySelector("#status");
const author = document.querySelector("#author");

let editingId;
let undo = ` <i class="fa-solid fa-rotate-left"></i>`
let ToDoS = [];