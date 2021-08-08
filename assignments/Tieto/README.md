        Ilze's job is to distribute advertising messages. The company uses postal services for these purposes.
        Payment for postal services is made individually, with postage stamps attached to each item.
        Depending on the location of the recipient, the delivery fee and, accordingly, the number of postage stamps also vary.

## Problem

Make a purchase of stamps in such a way that both the delivery costs of the parcel are covered and the money is not wasted.

## Goal

- Develop a program that helps solve the problem.

## Requirements
---

- The program is written in Ruby or JavaScript programming language
- The program is called from the command line
  - (CRuby v2.5 +) - "ruby markas.rb `<input>`"
  - JavaScript (Node.js v8.11 +) - "node markas.js `<input data>`"
- Raise an exception if you do not receive any input data or if you receive invalid input data
- Output data must be displayed in the command line interface - puts (Ruby) or console.log (JavaScript).

## Additional requirements
---

- Optimized (reduced) number of purchase objects. (For example, 0.15 EUR for a shipment, it is wiser to buy 3x0.05 EUR stamps than 5x0.03 EUR)
- A set of test cases. Ruby - Unit, Minitest, RSpec or other, JavaScript -  Mocha, Nodeunit, QUnit or other
- Useful source code comments.

 ## What gets evaluated
 ---

- Accuracy of output data (verification with unit tests);
- Source code style and neatness (both subjectively and with tools).

 
The task has two levels of complexity, "Warming up" / 0. and level 1.
At first try to cope with the "Warm-up" task, and if there are serious difficulties, it is better to keep learning.

## "Warm-up", or level 0.
---

#### Requirements

- One denomination of stamps is available in the post office - 0.02 EUR
- The minimum shipping cost is 0.01 EUR

Input data:

- Whole number - Shipping costs in EUR cents.

Output data:

- Number of stamps that cover the cost of the shipment.

Example (1):

     Call: "ruby markas.rb 10"

     Output: "5"

Example (2):

     Call: "ruby markas.rb 5"

     Output: "3"

 
## 1. Level

Requirement:

- There are two denominations of stamps available in the post office - 0.03 and 0.05 EUR
- The minimum shipping cost is 0.08 EUR

Input data:

- Whole number - Shipping costs in EUR cents.

 
Output data:

- A string of symbols - a grammatically correct sentence in Latvian, in which the necessary purchase is mentioned.
- The output must answer the question "What to buy?". Noun inflection - nominative.

Example (1):

    Call: "ruby markas.rb 25"
    Output: "5 five-cent marks."

Example (2):

    Call: "ruby markas.rb 111"
    Output: "21 five-cent mark, 2 three-cent mark."