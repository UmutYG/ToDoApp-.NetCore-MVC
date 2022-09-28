const quoteText = document.querySelector("#quote");
const collapseHeaders = document.querySelectorAll(".accordion button");

const form = document.querySelector("#form");
const alert = document.getElementById("alert");

const accordion = document.querySelector("#mainAccordion");
const taskHeader = document.querySelector("#TaskHeader");
const taskDescription = document.querySelector("#Description");
const managerButton = document.querySelector("#button-add");
const donateButton = document.querySelector("#donate");
const donateDiv = document.querySelector(".donate-div");
//renderTasks("all");
const iconManager = document.querySelector("#status");
const author = document.querySelector("#author");
let loggedInfo = document.querySelector("#logged").children.length;

let editingId;
let undo = ` <i class="fa-solid fa-rotate-left"></i>`
let ToDoS = [];