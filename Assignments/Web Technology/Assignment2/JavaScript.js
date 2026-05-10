/*
1. Program to find the area of a triangle 
   with sides 5, 6, and 7 using Heron's formula
*/
let a = 5, b = 6, c = 7;
let s = (a + b + c) / 2;
let triangleArea = Math.sqrt(s * (s - a) * (s - b) * (s - c));

console.log("1. Area of the triangle:", triangleArea);



/*
2. Program to print the pattern using nested for loop
*/
console.log("2. Star Pattern:");
for (let i = 1; i <= 5; i++) {
    let pattern = "";
    for (let j = 1; j <= i; j++) {
        pattern += "* ";
    }
    console.log(pattern);
}



/*
3. Program to check whether a given year is a leap year
*/
let year = 2024;

if ((year % 4 === 0 && year % 100 !== 0) || year % 400 === 0) {
    console.log("3. " + year + " is a Leap Year");
} else {
    console.log("3. " + year + " is not a Leap Year");
}



/*
4. Program to calculate the number of days left 
   until Independence Day (August 15)
*/
let today = new Date();
let currentYear = today.getFullYear();
let independenceDay = new Date(currentYear, 7, 15); // August is month 7

// If today is after August 15, calculate for next year
if (today > independenceDay) {
    independenceDay = new Date(currentYear + 1, 7, 15);
}

let oneDay = 24 * 60 * 60 * 1000;
let daysLeft = Math.ceil((independenceDay - today) / oneDay);

console.log("4. Days left until Independence Day:", daysLeft);