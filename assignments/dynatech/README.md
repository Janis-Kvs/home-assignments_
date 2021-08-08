Welcome!  This is one of the standard problem sets for candidates applying to
development positions in our company.  Thanks in advance for the time you spend
solving these problems!  We hope you have fun doing it.

# GENERAL REQUIREMENTS

This is a somewhat lengthy document, but the problems herein are not intended to be
particularly challenging, you're supposed to be able to come up with a good
solution for any of the problems below within an hour or so.

Note that examples provided for each problem are illustrative, not exhaustive.  The
fact that your solution works on example inputs does not guarantee its correctness.

All problems must be solved in PHP 7.0 or higher.

Your solution should consist of a single file called e.g. "solutions.php".  The
file should contain three top-level function or class definitions corresponding to
the three problems stated below.

All definitions must be in the root namespace.  You may use auxiliary definitions
of functions and classes in your solutions if you feel the need to do so.  Please
keep all auxiliary definitions in the same file.

Your solutions will be tested using error_reporting(E_ALL).  If your solutions emit
errors (of any level, including E_STRICT, E_NOTICE and E_DEPRECATED) during
testing, these will be counted as flaws in your solutions.

If you're unable or unwilling to solve one or more of the problems, please keep the
corresponding functions in your solution file, and make them return nonsensical
results or throw an exception (as in the solution template below).

Solution template file:

```
=== begin solutions.php ===========================================================
<?php

function findOddEvenPair(array $numbers): int
{
    throw new \Exception('Not implemented.');
}

class SummationService
{
    public function __construct(array $data)
    {
        throw new \Exception('Not implemented.');
    }

    public function sum(int $a, int $b): int
    {
        throw new \Exception('Not implemented.');
    }
}

function longestSubstr(string $text): string
{
    throw new \Exception('Not implemented.');
}
=== end solutions.php =============================================================
```

Your solutions will be tested automatically.  Correctness will be checked by a
bunch of hand-crafted tests including various corner cases.  Both correctness and
efficiency will also be evaluated by separate property-based tests against
reference solutions with strict time limits.  This round of tests will include
large randomly-generated inputs.  Naive solutions are likely to pass the simple
correctness tests but not the efficiency tests.

Readability and style consistency will be taken into account when evaluating your
solutions.

## PROBLEM 1

Implement a function findOddEvenPair with the following signature:

```
    function findOddEvenPair(array $numbers): int
```

The function should accept a non-empty array of positive integer numbers, with an
additional invariant that the first and last elements of the array have different
parity (i.e., if the first element is odd, the last one is going to be even, and
vice versa), and return an index $ix such that $numbers[$ix] and $numbers[$ix + 1]
also have different parity.  You may return any index such that the above condition
holds, in case there are multiple valid answers, all will be accepted by the
automated grader.

For example, findOddEvenPair([1, 2]) should always return 0 ($numbers[0] and
$numbers[1] have different parity, and no other index would even produce a valid
pair, while findOddEvenPair([1, 2, 4, 3, 7]) may return either 0 (1 and 2 have
different parity) or 2 (4 and 3 also have different parity).

You may assume that the inputs provided to your function will always satisfy the
invariants described above, so you do not need to perform any input validation.

Your solution should be fairly efficient even on pathological inputs, being able to
produce a correct answer in a fraction of a second on an input array of a few
hundred thousand elements with just a few possible answers.  Brute force search for
the answer is unlikely to pass the efficiency test.

## PROBLEM 2

Implement a class called SummationService, with a constructor accepting a non-empty
array of integers as its single argument, and one public method sum() accepting
two non-negative integers $a and $b as arguments, and returning an integer
containing the sum of the array elements with indices from $a to $b (inclusive).

You may assume that the constructor will always be called with a non-empty array of
integers, that $a and $b will always lie between 0 and count($array) - 1
(inclusive), and that $a will always be less than or equal to $b.  You do not need
to validate the arguments, or ensure any kind of sane behavior in case these
constraints are violated.

You do not need to concern yourself with issues of integer precision.  All test
inputs will be constructed such that computing the answer will not involve integer
overflows.

The fundamental property your solution must satisfy is that for all valid values of
$array, $a and $b:

```
    (new \SummationService($array))->sum($a, $b) ===
    array_sum(array_slice($array, $a, $b - $a + 1))
```

For a more concrete example, using:

```
    $service = new \SummationService([-1, 0, 2, 7, -15]);
```

A call to $service->sum(0, 0) must evaluate to -1, a call to $service->sum(1, 3)
must evaluate to 9, and a call to $service->sum(2, 4) must evaluate to -6.

In case this sounds too easy, consider this: your solution must be very fast at
handling many repeated calls to sum() (with different arguments) for a single
instance of your class.

The benchmark here is being able to process within a few seconds several thousand
random calls to sum() on an array of a million elements.  A naive implementation is
likely to pass small correctness tests, but will fail this stress test.

## PROBLEM 3

Implement a function with the following signature:

```
    function longestSubstr(string $text): string
```

Given a string of lower- and upper-case Latin letters and digits as an input, the
function should return its longest substring that does not include any
two-character sequence more than once.  In case there are several such substrings
with the same number of characters in them, your function should return the
leftmost one.

Treat the input string in case-sensitive fashion.

You may assume that the input is always valid, so you do not need to concern
yourself with input validation.

A few simple examples:

```
    longestSubstr('aaa') === 'aa'
```

The only longer substring is 'aaa' itself, and that includes the 'aa' digraph twice
(starting from first and second characters of the string).

```
    longestSubstr('aZaZaZ') === 'aZa'
```

'ZaZ' is also a substring that has the same property and same length, but 'aZa'
first occurs to the left of it, starting with the very first character of the input
string.  Longer substrings of this string do not have the required property, e.g.
'aZaZ' includes the two-letter sequence 'aZ' twice.

```
    longestSubstring('aZAzaz') === 'aZAzaz'
```

The digraphs 'aZ', 'ZA', 'Az', 'za' and 'az' are all distinct when treated
case-sensitively.

Your solution must be fairly efficient, as it will be expected to process inputs
consisting of several thousand characters over the course of several hundred
separate tests within a few seconds.  Any solution with superlinear asymptotic time
complexity is unlikely to pass the efficiency tests.

Good luck and have fun!
