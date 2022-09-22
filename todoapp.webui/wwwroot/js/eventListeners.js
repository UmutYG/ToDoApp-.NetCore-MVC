

if(loggedInfo == 0)
{
    const accountControl = document.querySelector("#register");
    accountControl.addEventListener("click", ()=>{

        form.action = accountControl.textContent == "Login" ? "account/login" : "account/register";
        alert.textContent = accountControl.textContent == "Login" ? "Have an account? Log In." : "Register and join the community!";
        accountControl.textContent = accountControl.textContent == "Login" ? "Register" : "Login";
        document.querySelector("#control").textContent = accountControl.textContent == "Login" ? "Register" : "Login";
        
    });
}

