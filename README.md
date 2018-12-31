# advent of code 2017

https://adventofcode.com/

This challenge is to use c# with jetbrains rider. With unit testing where possible.

Like usual, no third party libraries if i can help it

## 1: https://adventofcode.com/2017/day/1

### pt a:

The captcha requires you to review a sequence of digits (your puzzle input) and find the sum of all digits that match the next digit in the list. The list is circular, so the digit after the last digit is the first digit in the list.

### pt b:

Same as above but instead of them next to each other, use the ones on the opposite side of the arrat

### notes
This is going to be much slower than when I used python. Python has a lot of very convenient short cuts particularly because of it's dynamic typing. 

Need to find some nice short cuts as I go along. 


## 2: https://adventofcode.com/2017/day/2

### pt a:

Given a grid of numbers from the total from findin the min/max of each row and diffing them.

### pt b:

Each line only has two numbers that evenly divide. find the total of those divisions

## 3: https://adventofcode.com/2017/day/3

### pt a:

You have a grid with the numbers spiriling out. How many steps are required to carry the data from the square identified in your puzzle input all the way to the access port?

### pt b:

Same above but now each number is the sum of it's adjacent values (if calculated yet).

### notes:
Answered the first one using math but found that wouldn't be very feasible (but theortically possible stil??) for part 2. So i generated the damned thing. very finicky.

Original converted the coords to strings for the dictionary but turns out C# has tuples.. very clunky tuples. Used those instead to be a little less dirty.

## 4: https://adventofcode.com/2017/day/4

### pt a:

How many phrases in the list do not have duplicates?

### pt b:

How many phrases in the list do not have anagrams