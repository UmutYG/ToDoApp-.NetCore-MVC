
// THIS SCRIPT WON'T BE USED FOR NEXT VERSIONS.


function renderTasks(filter)
{
    accordion.innerHTML = "";
    let rendererHtml = ``;
    if(ToDoS.length == 0)
    {
        rendererHtml += `
        <div class="alert alert-primary" role="alert">
            No Tasks!
        </div>
`
    }
    for(let task of ToDoS)
    { 
        let completed = task.completed == "completed" ? "done" : "";
        let statusIcon = task.completed == "pending" ? "fa-solid fa-check" : "fa-solid fa-rotate-left";
        if(filter == "all" || task.completed == filter)
        {
            rendererHtml += `
                <div class="accordion-item">
                    <h2 class="accordion-header" id="headingOne">
                        <button class="accordion-button ${completed}" type="button" data-bs-toggle="collapse" data-bs-target="#a${task.id}" aria-expanded="true" aria-controls="collapseOne">
                        ${task.task}
                        </button>
                        <div class="icons">
                            <a href="#" onclick="editTask(${task.id})"><i class="fa-solid fa-pen-to-square fa-sm"></i></a>
                            <a href="#" onclick="deleteTask(${task.id})"><i class="fa-solid fa-trash fa-sm"></i></a>
                            <a href="#" id="status" onclick="finishTask(${task.id})"><i class="${statusIcon}"></i></a>
                            
                        </div>
                    </h2>
                    <div id="a${task.id}" class="accordion-collapse collapse show" aria-labelledby="headingOne" data-bs-parent="#accordionExample">
                        <div class="accordion-body">
                            
                        ${task.description}
                        </div>
                    </div>
                </div>
                `
        }
        
    }
    accordion.insertAdjacentHTML("beforeend", rendererHtml);
}

"use strict"

const accordion = document.querySelector("#mainAccordion");
const taskHeader = document.querySelector("#input");
const taskDescription = document.querySelector("#inputDesc");
const managerButton = document.querySelector("#button-add");
//renderTasks("all");
const iconManager = document.querySelector("#status");
const author = document.querySelector("#author");

let editingId;
let undo = ` <i class="fa-solid fa-rotate-left"></i>`


function clearInputs()
{
    taskHeader.value = "";
    taskDescription.value = "";
}

function manageTasks()
{
    if(managerButton.textContent == "Edit")
    {
        let onEditingTask = ToDoS.find(toDo=>toDo.id == editingId);
        onEditingTask.description = taskDescription.value;
        onEditingTask.task = taskHeader.value;
    }
    else
    {
        ToDoS.push({"id" : ToDoS.length + 1, "task":taskHeader.value, "completed":"pending", "description":taskDescription.value});
    }
    clearInputs();
    managerButton.textContent = "Add";
    renderTasks("all");
    localStorage.setItem("ToDoS",JSON.stringify(ToDoS));
}



function editTask(taskId)
{
    let editTask;
    managerButton.textContent = "Edit";
    for(let task of ToDoS)
    {
        if (task.id == taskId)
        {
            editTask = task;
            break;
        }
            
    }
    taskHeader.value = editTask.task;
    taskDescription.value = editTask.description;
    editingId = taskId;
   
}

function deleteTask(taskId)
{
    ToDoS.splice(ToDoS.findIndex(i=>i.id == taskId),1);
    renderTasks("all");
}


function finishTask(taskId)
{
    let task = ToDoS.find(i=>i.id == taskId);
    task.completed == "pending" ? task.completed = "completed" : task.completed = "pending";
    renderTasks("all");

    
}


const filters = document.querySelector(".list-group");
for(let filter of filters.children)
{   
    filter.addEventListener("click", function(){
        renderTasks(filter.innerText.toLowerCase())
    });
}

let ToDoS = [];
if(localStorage.getItem("ToDoS") != null)
{
    ToDoS = JSON.parse(localStorage.getItem("ToDoS"));
}








