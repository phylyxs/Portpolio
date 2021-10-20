/* This function check the user input by the conditions. For instance, the userName should not be null, the userEmail should be the form of email and userMessage should not be null as well */

function chekcInfo() {
    var userName = document.getElementById("name").value;
    var userEmail = document.getElementById("email").value;
    var userMessage = document.getElementById("message").value;
    var pattern = /.@./;
    var letters = /^[A-Za-z\s]+$/; //for letters-only validation
    var errorCheck = 0; //To check correct information forms and to next step

    if (userName =="") {
            document.getElementById("nameerror").innerHTML = "We need your name to help you";
    }
    else {
        if(userName.match(letters)){
            document.getElementById("nameerror").innerHTML = "";
            errorCheck ++; // This is set as 1 here
        } else {
            document.getElementById("nameerror").innerHTML = "Please enter your name (letters-only)"; 
            return false;
        }
    }


    if (userEmail == "") {
        document.getElementById("emailerror").innerHTML = "We need your email address to contact you.";
    }
    else {
        if (!userEmail.match(pattern)) {
            document.getElementById("emailerror").innerHTML = "This should be email form.";
            return false;
            }
            else {
                document.getElementById("emailerror").innerHTML = "";
                errorCheck ++; // This is set as 2 here
            }
    }
    if (userMessage == "") {    
        document.getElementById("messageerror").innerHTML = "Don't be shy. Just let us know what you think";
        return false;
    }
    else {
        document.getElementById("messageerror").innerHTML ="";
        errorCheck ++; // This is set as the 3 here
           
    }
    if (errorCheck == 3) { // Now we can call the function showpop2
        showpop2(); /* This showpop2 shows confirm popup message to the user to choose 'OK' or 'Cancle'*/
    }
    
}




/* This resetInfo function makes all message as NULL so every error message and user message disappear */
function resetInfo() {
    document.getElementById("name").value = "";
    document.getElementById("email").value = "";
    document.getElementById("message").value = "";
    document.getElementById("nameerror").innerHTML = "";
    document.getElementById("emailerror").innerHTML = "";
    document.getElementById("messageerror").innerHTML = "";
}

/* This popup message shows user 'Thank you' */
function showpop() {
    var popup = document.getElementById('popup');
    popup.classList.toggle('active');
}

/* For the reset button */
function showpop1() {
    var popup1 = document.getElementById('popup1');
    var userName = document.getElementById("name").value;
    var userEmail = document.getElementById("email").value;
    var userMessage = document.getElementById("message").value;

    if (userName == "" && userEmail == "" && userMessage == ""){
        return; //since it's empty, there's no point of showing the pop-up.
    } else {
        popup1.classList.toggle('active');  
    }
    
}

/* For the send button */
function showpop2() {
    var popup2 = document.getElementById('popup2');
    popup2.classList.toggle('active');
}
