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

## 5: https://adventofcode.com/2017/day/5

### pt a:

given a list of offsets find how many steps before they go over, upping the offset by 1 each time

### pt b:

Same as part two but if an offset is greather than 3 minus 1 

## 6: https://adventofcode.com/2017/day/6

### pt a:

Given the initial block counts in your puzzle input, how many redistribution cycles must be completed before a configuration is produced that has been seen before?

### pt b:

How many cycles are in the infinite loop that arises from the configuration in your puzzle input?


## 7: https://adventofcode.com/2017/day/7

### pt a:

Build the tree, return the name of the parent node

### pt b:

Find the unbalanced branch. Return the value that the bad node should be.

### Notes:

Abused the way advent of code works on this one a bit. Guessed that the input data won't have the unbalanced nodes appear with less than 3 children. Saved a little bit of time dealing with that edge case.

## 8: https://adventofcode.com/2017/day/8

### pt a:

What is the largest value in any register after completing the instructions in your puzzle input?

### pt b:

What is the highest value held in any register during this process

## 9: https://adventofcode.com/2017/day/9

### pt a:

Given a bunch of bracket types and rules, given a string What is the total score for all groups in your input?

### pt b:

How many non-canceled characters are within the garbage in your puzzle input?