const request = new XMLHttpRequest();
request.open("GET",'https://programming-quotes-api.herokuapp.com/quotes/random');
request.send();
const quoteText = document.querySelector("#quote");
const collapseHeaders = document.querySelectorAll(".accordion button");

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




