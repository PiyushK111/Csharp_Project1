$(document).ready(function() {



    var pass = document.getElementById("password");
    var address = document.getElementById("address");
    var dob = document.getElementById("dob");
    var ssc_total_mark = document.getElementById("ssc_total_mark");
    var ssc_obtain_mark = document.getElementById("ssc_obtained_mark");
    var getButton1 = document.getElementById("get1");
    var percentage_ssc = document.getElementById("percentage");
    var submitBtn = document.getElementById("submitBtn");



    

    password.addEventListener('input', function () {
        var pass_value = pass.value;
        var passCheck = validatePass(pass_value);
        if (passCheck) {

            pass.nextElementSibling.innerHTML = "";

            /*            submitBtn.disabled = false;
            */
        }

        else {

            pass.nextElementSibling.innerHTML = `Password Should contain an upper case(A,B,C)
                                                    and lower case (a, b, c) and special character(@,#, $,%)
                                                and minimum length shuold be 8`;
            /*            submitBtn.disabled = true;
            */
        }
    })





    

    getButton1.addEventListener('click', function () {


        var temp = (ssc_obtain_mark.value / ssc_total_mark.value) * 100;

        percentage_ssc.value = temp;

    });

    /*function getSscPercentage(ssc_total_mark, ssc_obtain_mark) {


        return percentage.toFixed(2);

    }
*/

    function validateTotal() {
        var value1 = Number(ssc_total_mark.value);
        
        if (value1 < 0) {
            alert("in negative :" + value1);
            this.value1 = "";
            ssc_total_mark.nextElementSibling.innerHTML = "Marks cannot be negative";

        }
        else {
            ssc_total_mark.nextElementSibling.innerHTML = "";

        }
/*
        if (this.value1.length > 4) {
            alert("in > 4:" + value1);

            this.value = this.value.slice(0, 4);
            alert("total length :" + value1.length)
            ssc_total_mark.nextElementSibling.innerHTML = "length exceeded should be less than 9999";
        }
        else {
            ssc_total_mark.nextElementSibling.innerHTML = "";

        }*/
    }


    function validateSscTotal() {



        const value1 = Number(ssc_total_mark.value);

        const value2 = Number(ssc_obtain_mark.value);

        /*alert("ssc total "+value1 + "   ssc obtain  " + value2)*/

       
        if (value2.length > 4) {
            alert("obtain length :" + value2.length)

            ssc_obtain_mark.nextElementSibling.innerHTML = "length exceeded";
        }
        else {
            ssc_obtain_mark.nextElementSibling.innerHTML = "";

        }

        if (value2 < 0) {

            ssc_obtain_mark.nextElementSibling.innerHTML = "Marks cannot be negative";
        }
        else {
            ssc_obtain_mark.nextElementSibling.innerHTML = "";

        }

        if (value1 < value2) {

            /*alert("in ssc if demo ");*/

            ssc_obtain_mark.nextElementSibling.innerHTML = "Obtained mark should be less than total marks";

            /*document.getElementById('getButton1').disabled = 'true';*/

        }

        else {

/*            alert("in else ssc")*/

            ssc_obtain_mark.nextElementSibling.innerHTML = "";

            /*document.getElementById('getButton1').disabled = 'false';*/

        }

    }


    dob.addEventListener('change', function () {

        const dob_value = dob.value;

        var age = calculateAge(dob_value);

        if (age == -1) {

            document.getElementById('age').value = "below 1";

        } else {

            document.getElementById('age').value = age;

        }

    });
    function calculateAge(dob_value) {

        // Parse the date string into a Date object

        var dob = new Date(dob_value);



        // Calculate the age based on the current date

        var today = new Date();

        var age = today.getFullYear() - dob.getFullYear();

        if (today.getMonth() < dob.getMonth() || (today.getMonth() == dob.getMonth() && today.getDate() < dob.getDate())) {

            age--;

        }

        // Return the age in years

        return age;

    }



    function validatePass(pass_value) {

        const minPasswordLength = 8;

        const uppercaseRegex = /[A-Z]/;

        const lowercaseRegex = /[a-z]/;

        const specialCharRegex = /[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]/;



        if (pass_value.length < minPasswordLength) {

            return false;

        }



        if (!uppercaseRegex.test(pass_value)) {

            return false;

        }



        if (!lowercaseRegex.test(pass_value)) {

            return false;

        }



        if (!specialCharRegex.test(pass_value)) {

            return false;

        }




        return true;

    }

    

    address.addEventListener('input', function () {
        const specialCharRegex = /[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]/;

        if (!(specialCharRegex.test(address.value))) {

            address.nextElementSibling.innerHTML = "";
            /*submitBtn.disabled = 'false';*/
        }

        else {
            address.nextElementSibling.innerHTML = "No special character are alowed";

            /*submitBtn.disabled = 'true';*/
        }

    })


    
    ssc_obtain_mark.addEventListener('input', validateSscTotal);
    ssc_total_mark.addEventListener('input', validateTotal);

    


    document.getElementById("next1").addEventListener("click", function () {
        var div1 = document.getElementById("div1");
        var div2 = document.getElementById("div2");

        /*	div1.style.display = "none";
          div2.style.display = "block";
          */
        if (div1.style.display === "none") {
            div1.style.display = "none";
            div2.style.display = "block";
        } else {
            div1.style.display = "none";
            div2.style.display = "block";
        }
    });
    document.getElementById("prev2").addEventListener('click', function () {
        var div1 = document.getElementById("div1");
        var div2 = document.getElementById("div2");
        if (div2.style.display === "none") {
            div2.style.display = "none";
            div1.style.display = "block";
        } else {
            div2.style.display = "none";
            div1.style.display = "block";
        }
    })
    document.getElementById("next2").addEventListener('click', function () {
        var div2 = document.getElementById("div2");
        var div3 = document.getElementById("div3");
        if (div2.style.display === "none") {
            div2.style.display = "none";
            div3.style.display = "block";
        } else {

            div2.style.display = "none";
            div3.style.display = "block";
        }
    })
    document.getElementById("prev3").addEventListener('click', function () {
        var div2 = document.getElementById("div2");
        var div3 = document.getElementById("div3");
        if (div2.style.display === "none") {
            div3.style.display = "none";
            div2.style.display = "block";
        } else {
            div3.style.display = "none";
            div2.style.display = "block";
        }
    })
   /* var input = document.getElementById('searchQuery');
    var clearButton = document.querySelector('.clear-button');

    input.addEventListener('input', function () {
        clearButton.style.display = input.value ? 'block' : 'none';
    });

    clearButton.addEventListener('click', function () {
        input.value = '';
        clearButton.style.display = 'none';
    });*/

});

  
    




