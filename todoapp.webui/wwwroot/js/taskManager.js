
// All Works.
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
        
        if(taskHeader.value.length != 0 && taskDescription.value.length != 0)
        {
            ToDoS.push({"id" : ToDoS.length + 1, "task":taskHeader.value, "completed":"pending", "description":taskDescription.value});
            document.querySelector("#form-controls").innerHTML = "";
            
        }
        // to run backend, submit form would not go to home/addTask if this action is not completed.
        //document.querySelector("#submit-form").submit();
       
    }
    clearInputs();
    managerButton.textContent = "Add";
    localStorage.setItem("ToDoS",JSON.stringify(ToDoS));
    renderTasks("all");
}

// Done.
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

// Done.
function deleteTask(taskId)
{
    ToDoS.splice(ToDoS.findIndex(i=>i.id == taskId),1);
    localStorage.setItem("ToDoS",JSON.stringify(ToDoS));
    renderTasks("all");
}


function finishTask(taskId)
{
    let task = ToDoS.find(i=>i.id == taskId);
    task.completed == "pending" ? task.completed = "completed" : task.completed = "pending";
    localStorage.setItem("ToDoS",JSON.stringify(ToDoS));
    renderTasks("all");

}













