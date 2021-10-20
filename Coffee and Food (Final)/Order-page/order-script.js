var currentTab = 0; // Current tab is set to be the first tab (0)
showTab(currentTab); // Display the current tab

function showTab(n) {
  // This function will display the specified tab of the form ...
  var x = document.getElementsByClassName("tab");
  x[n].style.display = "block"; //it's displaying it its own "block"
  // ... and fix the Previous/Next buttons:
  if (n == 0) { //the currentTab is at the very first tab.
    document.getElementById("prevBtn").style.display = "none"; //not showing the prevBtn
  } else {
    document.getElementById("prevBtn").style.display = "inline"; //showing the prevBtn
  }
  if (n == (x.length - 1)) {
    document.getElementById("nextBtn").innerHTML = "Submit"; //if it's the last last one
  } else {
    document.getElementById("nextBtn").innerHTML = "Next"; //else, it's next.
  }
  // ... and run a function that displays the correct step indicator:
  fixStepIndicator(n)
}

function nextPrev(n) {
  // This function will figure out which tab to display
  var x = document.getElementsByClassName("tab");
  // Exit the function if any field in the current tab is invalid:
  if (n == 1 && !validateForm()) return false; //n == 1 means we want to get to the next tab to the right.
  // Hide the current tab:
  x[currentTab].style.display = "none";
  // Increase or decrease the current tab by 1:
  currentTab = currentTab + n;
  // if you have reached the end of the form... :
  if (currentTab >= x.length) {
    //...the form gets submitted:
    document.getElementById("regForm").submit();
    return false; //it just basically re-loads back to the very first tab.
  }
  // Otherwise, display the correct tab:
  showTab(currentTab);
  
}

function validateForm() {
    //if the return value = true ...the form is valid (no problem with the user input)
    //if the return value = false.. the form is invalid (meaning there are problems with the user input)

    //CurrentTab == 0 is the very first tab (drop-down menus and total price)    
    if(currentTab == 0){
        if (grandPrice.innerText == "0.00"){
            alert("There are no items in your cart!");
            return false; //because it doesn't satisfy the if statement at nextPrev()...it will not move to the next tab.
        } else {
            return true; //it will move to the next tab.
        }
    }
    //CurrentTab == 1 is where the First Name, Email, Contact number is at.
    if(currentTab == 1){
        var validForm = 0;
        var letters = /^[A-Za-z\s]+$/; //for letters-only validation
        //First Name validation
        firstname = document.getElementById("firstname").value;
        if(firstname.match(letters)){
            document.getElementById("fnameerror").innerHTML = "";
            validForm++;
        } else {
            document.getElementById("fnameerror").innerHTML = "Please enter your first name (letters-only)";
            
        }

        //Last Name validation 
        lastname = document.getElementById("lastname").value;
        if(lastname.match(letters)){
            document.getElementById("lnameerror").innerHTML = "";
            validForm++;
        } else {
            document.getElementById("lnameerror").innerHTML = "Please enter your last name (letters-only)";  
        }

        //Phone Number validation 
        phoneNo = document.getElementById("phoneNo").value;
        var phoneno = /^\d{10}$/;
        if (phoneNo.match(phoneno)){
            document.getElementById("phoneerror").innerHTML = "";
            validForm++;
        }
        else {
            document.getElementById("phoneerror").innerHTML = "Must be 10-digits phone number.";
        }
        

        //Email validation 
        email = document.getElementById("email").value;
        var mailformat = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
        if(email.match(mailformat)){
            //e.g. felix@gmail.com
            document.getElementById("emailerror").innerHTML = "";
            validForm++;
        }else if(email == ""){ //forces the user to put email because it's required
            document.getElementById("emailerror").innerHTML = "Please enter your email";
        } else { //e.g. felix, felix@
            document.getElementById("emailerror").innerHTML = "Must have '@'";
        }

        if(validForm == 4){
            return true; //meaning all of the 4 inputs have no problems
        } else {
            return false; //meaning at least of the inputs have a problem, therefore it's not allowing 
            // the nextPrev() function to move you to the next tab. 
        }
    } 

    if(currentTab == 2){
        var cardno = /^\d{16}$/; // visa validation
        var letters = /^[A-Za-z\s]+$/; //for letters-only validation
        validForm = 0;
        //Card Number (Visa) validation
        cardnumber = document.getElementById("cardnumber").value;
        if(cardnumber.match(cardno)){
            document.getElementById("cardnumbererror").innerHTML = "";
            validForm++;
        } else {
            document.getElementById("cardnumbererror").innerHTML = "Enter 16-digit numbers";
        }

        //Card Holder Name (Visa and Mastercard)
         //Last Name validation 
        cardholdername = document.getElementById("cardholdername").value;
        if(cardholdername.match(letters)){
            document.getElementById("cardholdernameerror").innerHTML = "";
            validForm++;
        } else {
            document.getElementById("cardholdernameerror").innerHTML = "Letters-only";  
        }

        //CVC validation
        var numbers = /^\d{3}$/;
        cvc = document.getElementById("cvc").value;
        if(cvc.match(numbers)){
            document.getElementById("cvcerror").innerHTML = "";
            validForm++;
        } else {
            document.getElementById("cvcerror").innerHTML = "3-digit number only";  
        }

        
        
        //Date Until Validation 
        var validuntil = document.getElementById("validuntil").value;
        dateInput();
        
        function dateInput() {
            var validDate = validDateCheck(validuntil);
            if (validuntil === ""){
                document.getElementById("validuntilerror").innerHTML = "Date valid is required";
                return;
            }
            if (!validDate){
                //e.g. validDate = true ....therefore, not TRUE = false (so it will not read line 160)
                //e.g. validDate = false....therefore, not FALSE = true (so it will read line line 160)
                document.getElementById("validuntilerror").innerHTML = "Date expired";
                return;
            } else {
                document.getElementById("validuntilerror").innerHTML = "";
                validForm++;
                return;
            }
        }
        function validDateCheck(validuntil){
            // get current date code from: 
            var today = new Date(); //creating an instance
            var dd = today.getDate();
            var mm = today.getMonth() + 1; //just syntax
            var yyyy = today.getFullYear();
        
            if (dd < 10){ //e.g. 9 --> 09
                dd = '0' + dd;
            }
            if (mm < 10){ //e.g. 1 --> 01
                mm = '0' + mm;
            }

            today = yyyy + '-' + mm + '-' + dd;
        
            if (validuntil < today){
                return false;
            } else { 
                return true;
            }
        }

        if(validForm == 4){
            return true;
        } else {
            return false;
        }
        
    }

    //Order is Successful!
    if(currentTab == 3){
        return true;
    }
}


function fixStepIndicator(n) { //dots
  // This function removes the "active" class of all steps...
  var i, x = document.getElementsByClassName("step");
  for (i = 0; i < x.length; i++) {
    x[i].className = x[i].className.replace(" active", "");
  }
  //... and adds the "active" class to the current step:
  x[n].className += " active";
}


// coffee - A
let selection1A = document.querySelector("#coffeeListA");
let selection2A = document.querySelector("#coffee_quantityA");

//.toFixed(2) -- rounds it up to 2 decimal places

selection1A.addEventListener('change', () => {
    // if any changes are made to the #coffeeListA (selecting coffee)
    // it will automatically update the unitPrice of coffee.
    coffee_unitPriceA.innerText = selection1A.options[selection1A.selectedIndex].value;
    // it will automatically calculate and update the totalPrice of coffee
    coffee_totalPriceA.innerText = (selection1A.options[selection1A.selectedIndex].value * selection2A.options[selection2A.selectedIndex].value).toFixed(2);
});

selection2A.addEventListener('change', () => {
    // if any changes are made to the #coffee_quantityA (selecting how many coffee)
    // it will also automatically calculate and update the totalPrice of coffee.
    coffee_totalPriceA.innerText = (selection1A.options[selection1A.selectedIndex].value * selection2A.options[selection2A.selectedIndex].value).toFixed(2);
    if (isNaN(coffee_totalPriceA.innerText)){ // it could be that user only selected quantity and not chosen any coffee (therefore there is no item = should be 0 total price)
        coffee_totalPriceA.innerText = 0;
    }
});

// food - A
let food_selection1A = document.querySelector("#foodListA");
let food_selection2A = document.querySelector("#food_quantityA");

food_selection1A.addEventListener('change', () => {
    // if any changes are made to the #foodListA (selecting food)
    // it will automatically update the unitPrice of food.
    food_unitPriceA.innerText = food_selection1A.options[food_selection1A.selectedIndex].value;
    // it will automatically calculate and update the totalPrice of food
    food_totalPriceA.innerText = (food_selection1A.options[food_selection1A.selectedIndex].value * food_selection2A.options[food_selection2A.selectedIndex].value).toFixed(2);
});


food_selection2A.addEventListener('change', () => {
    food_totalPriceA.innerText = (food_selection1A.options[food_selection1A.selectedIndex].value * food_selection2A.options[food_selection2A.selectedIndex].value).toFixed(2);
    // if any changes are made to the #food_quantityA (selecting how many food)
    // it will also automatically calculate and update the totalPrice of food.
    if (isNaN(food_totalPriceA.innerText)){ // it could be that user only selected quantity and not chosen any food (therefore there is no item = should be 0 total price)
        food_totalPriceA.innerText = 0;
    }
});

var numTo2DP;

//grandPrice = the sum of totalPrices of coffee and food
selection1A.addEventListener('change', () => { //when changes are made to #coffeeListA, it will automatically calcualate the grandPrice
    numTo2DP = parseFloat(coffee_totalPriceA.innerText) + parseFloat(food_totalPriceA.innerText);
    grandPrice.innerText = numTo2DP.toFixed(2); //rounds it 2 decimal places
    if(grandPrice.innerText == 0){
        grandPrice.innerText = "0.00";
    }
});
    
food_selection1A.addEventListener('change', () => { //when changes are made #foodListA, it will automatically calcualate the grandPrice
    numTo2DP = parseFloat(coffee_totalPriceA.innerText) + parseFloat(food_totalPriceA.innerText);
    grandPrice.innerText = numTo2DP.toFixed(2);
    if(grandPrice.innerText == 0){
        grandPrice.innerText = "0.00";
    }
});

selection2A.addEventListener('change', () => { //when changes are made to #coffee_quantityA, it will automatically calcualate the grandPrice
    numTo2DP = parseFloat(coffee_totalPriceA.innerText) + parseFloat(food_totalPriceA.innerText);
    grandPrice.innerText = numTo2DP.toFixed(2);
    if(grandPrice.innerText == 0 || isNaN(grandPrice.innerText)){
        //isNaN(grandPrice.innerText) means...is it non-numerical? (if yes, then it should output "0.00") 
        grandPrice.innerText = "0.00"; 
    }
});

food_selection2A.addEventListener('change', () => { //when changes are made to #food_quantityA, it will automatically calcualate the grandPrice
    numTo2DP = parseFloat(coffee_totalPriceA.innerText) + parseFloat(food_totalPriceA.innerText);
    grandPrice.innerText = numTo2DP.toFixed(2);
    if(grandPrice.innerText == 0 || isNaN(grandPrice.innerText)){
        grandPrice.innerText = "0.00";
    }
});

    
function Reset() {  
    // Coffee - A
    var dropDownCoffeeA = document.getElementById("coffeeListA"); 
    var dropDownQtyA = document.getElementById("coffee_quantityA"); 
    // Food - A
    var dropDownFoodA = document.getElementById("foodListA"); 
    var food_dropDownQtyA = document.getElementById("food_quantityA"); 

    if(grandPrice.innerText != "0.00"){ //perform reset when grandPrice has value in it.
        if (confirm('Are you sure you want to reset all your order?')){ //otherwise, what is the point of confirming resetting if the customer has not chosen any items yet.
            dropDownCoffeeA.selectedIndex = 0;  
            dropDownQtyA.selectedIndex = 0;
            coffee_unitPriceA.innerText = "";
            coffee_totalPriceA.innerText = 0;
            dropDownFoodA.selectedIndex = 0;  
            food_dropDownQtyA.selectedIndex = 0;
            food_unitPriceA.innerText = "";
            food_totalPriceA.innerText = 0;
            grandPrice.innerText = "0.00";
        }
    } 
}     

