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

## 10: https://adventofcode.com/2017/day/10

### pt a:

Given a list of 'lengths', rotate that range of items (then move pos). Return ther results of multiplying first two items

### pt b:

Using the function from above, now use the input as a string of ascii characters. Convert those to integers, add a set of suffix numbers and then run the hash over it 64 times.
Then turn the resulting list into a string of Hexes (as the result of bitwise xor on each block of 16) 

## 11: https://adventofcode.com/2017/day/11

### pt a:

Given a hex grid and a string of directions, how far away is the final hex?

### pt b:

What is the furthest point the path gets?

### Notes

Very good resource of dealing with hex grids:

https://www.redblobgames.com/grids/hexagons/#distances

## 12: https://adventofcode.com/2017/day/12

### pt a:

Given groups of programs connected to each other, find the size of the group with program 0

### pt b:

How many groups are there in total?

## 13: https://adventofcode.com/2017/day/13

### pt a:

Given the details of the firewall you've recorded, if you leave immediately, what is the severity of your whole trip? 

Based on moving items per row, you need to make it to the end - record where you the items.

### pt b:

How much do you need to delay before you can get across with out a collision

### Notes:

First solution theortically won't work on all inputs as the math is wrong. Fixed on part b

Curious if this can be done faster. Takes a couple seconds to find a solution. To optimise it i suspect i'd need a way to simplify the loop further. I reckon it might be possible to Calculate it.

## 14: https://adventofcode.com/2017/day/14

### pt a:

Run the sol from part 2 10 on the given number incremementing the input string from 0 to 127 ("input-" + [0-127]). Convert each string to binary and count the zeroes.

### pt b:
Using the grid made above, group all the clusters of '1's into groups How many group are there?

## 15: https://adventofcode.com/2017/day/15

### pt a:

Using two lists of generating numbers, find out how many pairs have the final 16 bits (binary) match

### pt b:
Same as above, but now only compare when gena is divisible by 4 and genb is divisible by 8. 

### Notes:
Actually hit the integer limits on this one. Took a while to work out why the numbers were wonky :p


## 16: https://adventofcode.com/2017/day/16

### pt a:

You have a list of letters, rearrange them based on a list of commands.

### pt b:
Find the result after 1 billion.

### Notes:
Part B repeats after the 60th iteration. Solution just generates the first 60 and then uses 1 billion mod 60 to find the answer.


## 17: https://adventofcode.com/2017/day/17

### pt a:

What is the value after 2017 in your completed circular buffer?

### pt b:
What is the value after value 0 after 50,000,000 runs

### Notes:
Interesting note here, the build in dotnet linked list is surprisingly inefficient. It appears to be substantially slower than pythons deque (a first :p).

The more effecient solution for part b is to just keep track of the value after 0. Which c# can do in a second or so. 

## 18: https://adventofcode.com/2017/day/18

### pt a:

Another registry / run a program exercise. Find the first valid value for rcv

### pt b:
You have two programs running and sharing data (same input). How many times does program 1 send data to program 0

### Notes:
This problem is asking to be redone with proper multi theading. On my todo list.

Tired + not reading things properly is extremely painful - many infinite loops on this one thanks to a combination of missing little details in the instructions and / or refactoring code and forgetting to put things back in.

## 19: https://adventofcode.com/2017/day/19

### pt a:

You're given a path, find the letters (and order) that the letter a hit to get to the end

### pt b:

total number of steps to get to the end?

### notes:

Very trivial example of the early trolley example in the 2018 challenge.

## 20: https://adventofcode.com/2017/day/20

### pt a:

Given a set of points with 3d coords, velocity (on x,y,z) and aceleration (per x,y,z). Find the point that will be closest to 0,0,0 in the long run.

### pt b:

If you remove points that land in the same place at the same time, how much will ultimately be left in the long run

### notes:

Solved pt a using math - the point with both the lowest acceleration (add all three together using manhatten distance) and then lowest velocity (again manhatten distance) will be the remaining point.

Meant i actually had to implement the solution for pt 2. All collisions happen almost immediately, so just ran the simulation for about 40 iterations and returned the final count;

## 21: https://adventofcode.com/2017/day/21

### pt a:

You are given a 3x3 grid and a set of patterns each 2x2 or 3x3 and outputs for each 3x3 and 4x4 respectively. 

Split the grid up into 2x2 squares or 3x3 (what ever is doable first) and match them against the patterns. If they match the square becomes the output pattern.

Stitch the new squares back together. Repeat the process 5 times and report how many '#' there are.

One quirk of this is that the patterns can match on any combination of flipping and rotation.

### pt b:

Same as above but process it 18 times.

### notes:

Guessing 18 was picked because a super at this point the square would be huge and possibly hugely time consuming. My solution seemed quick enough - about 5 seconds. Room to be optimised though.

I suspect part 18 was to catch out those who are doing the rotations and flipping in real time - i preprocessed em :p

This was quite a fun exercise - though a little time consuming doing all the parts.

Looking at others solutions, turns out there is a math solution to this problem. Once you get to the third iteration you have everything you need to get more without running the full simulation. a possible @TODO.