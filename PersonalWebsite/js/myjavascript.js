window.onload = start();


function start() {
        doMax.addEventListener("click", findMax());

}

function findMax() {
    var num1 = document.getElementById(num1);
    var num2 = document.getElementById(num2);
    var num3 = document.getElementById(num3);
    var num4 = document.getElementById(num4);
    var num5 = document.getElementById(num5);
    if (num1 + num2 + num3 + num4 + num5 == NaN) {
        document.getElementById("highest") = "Please fill out all of the number spaces.";
    }
    else {
        document.getElementById("highest") = Math.max(num1, num2, num3, num4, num5);
    }
}