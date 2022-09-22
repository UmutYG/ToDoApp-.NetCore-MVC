const request = new XMLHttpRequest();
request.open("GET",'https://programming-quotes-api.herokuapp.com/quotes/random');
request.send();

// callback
request.addEventListener('load', ()=>{
    const data = JSON.parse(request.responseText);
    quoteText.textContent = data.en;
    author.textContent = data.author;
});

function drawBorder(taskDiv)
{
    if(!taskDiv.classList.contains("collapsed"))
    {
        taskDiv.nextElementSibling.classList.add("bordered");
    }
    
}

accountControl.addEventListener("click", ()=>{

    form.action = accountControl.textContent == "Login" ? "account/login" : "account/register";
    alert.textContent = accountControl.textContent == "Login" ? "Have an account? Log In." : "Register and join the community!";
    accountControl.textContent = accountControl.textContent == "Login" ? "Register" : "Login";
    document.querySelector("#control").textContent = accountControl.textContent == "Login" ? "Register" : "Login";
    console.log(form);
    
});

renderTasks("all");




