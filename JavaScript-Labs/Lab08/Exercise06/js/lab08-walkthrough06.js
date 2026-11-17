/* add code below this */

/* Exercise 8.6 - Built-in JavaScript Objects */

// Step 2: Create a String object
var stringOne = new String("Test");
document.write(stringOne);

// Step 3: Compare data types
var stringTwo = "Test";
var stringThree = "Test";
var stringFour = new String("Test");

document.write("<br>typeof stringOne=" + typeof stringOne);
document.write("<br>typeof stringThree=" + typeof stringThree);

// Step 4: Compare strings
if (stringOne == stringTwo)
    document.write("<br>stringOne has = value to stringTwo");

if (stringOne == stringFour)
    document.write("<br>stringOne has = value to stringFour");

if (stringOne === stringTwo)
    document.write("<br>stringOne has = value and = type to stringTwo");

if (stringTwo === stringThree)
    document.write("<br>stringTwo has = value and = type to stringThree");

if (stringTwo === stringFour)
    document.write("<br>stringTwo has = value and = type to stringFour");

// Step 5: Date object
var dateOne = new Date();
document.write("<p>" + dateOne + "</p>");

// Step 6: Math object
document.write(Math.PI + "<br/>");
document.write(Math.sqrt(4) + "<br/>");
document.write(Math.random() + "<br/>");

