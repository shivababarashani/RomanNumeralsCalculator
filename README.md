Roman Numerals
Write a function which allow the user to enter two valid roman numbers and request the computation of their sum, which the system then also displays in its roman representation as well.
The Romans were a clever bunch. They conquered most of Europe and ruled it for hundreds of years. They invented concrete and straight roads and even bikinis. One thing they never discovered though was the number zero. This made writing and dating extensive histories of their exploits slightly more challenging, but the system of numbers they came up with is still in use today. For example the BBC uses Roman numerals to date their programmes.
The Romans wrote numbers using letters - I, V, X, L, C, D, M. (notice these letters have lots of straight lines and are hence easy to hack into stone tablets).
 1   => I
 10  => X
 7   => VII
There is no need to be able to convert numbers larger than about 3000. (The Romans themselves didn't tend to go any higher)
Wikipedia says: Modern Roman numerals ... are written by expressing each digit separately starting with the left most digit and skipping any digit with a value of zero.
To see this in practice, consider the example of 1990.
In Roman numerals 1990 is MCMXC:
1000=M 900=CM 90=XC
2008 is written as MMVIII:
2000=MM 8=VIII




References
1. https://en.wikipedia.org/wiki/Roman_numerals
2. https://www.math-only-math.com/rules-for-formation-of-roman-numerals.html
3. http://www.novaroma.org/via_romana/numbers.html


About My Project
I have implemented this project in ASP.net Core MVC. It contains following features
1. Application is implemented on Onion architecture
2. Expection handling
3. Unit testing via XUnit
4. Test-first Approach

Conclusion
This challenge is a useful exercise in understanding the relationship between how we represent our data and the actions we want to perform on it—a dynamic you'll see at play in almost every piece of software you write. How did we decide to represent the relationship between a Roman numeral and its number equivalent (e.g., X to 10)? Was it easy to map from one to the other? Were all the mappings organized together? Did our representation of the relationship make it easier or harder when it came time to switch to modern Roman numerals?

