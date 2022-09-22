const filters = document.querySelector(".list-group");
for(let filter of filters.children)
{   
    filter.addEventListener("click", function(){
        renderTasks(filter.innerText.toLowerCase())
    });
}
