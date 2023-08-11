# Virtuoso

## Structure
The approach I've modeled is the onion architecture. At the core is the domain that contains the interfaces and domain service implementations
that everything points to. In the middle sits the infrastrucure layer which, for now, has the implementation for filesystem access for the console
program. Ideally, anything touching the infrastrucure should be using dependency injection and getting the inerface from the Domain but I didn't
want to over-complicate the console application which should technically sit on the last layer. There was a Web project, but I removed it for the
sake of time. 

## Problem Statement
You can provide you solution however you see fit.

Some options that we have used in the past are BitBucket, GitHub, https://dotnetfiddle.net/, or a zip file emailed.

Create a C# program that solves the following dependency problem:

A person needs to figure out which order his/her clothes need to be put on. 

The person creates a file that contains the dependencies.

This input is a declared array of dependencies with the [0] index being the dependency and the [1] index being the item. 

A simple input would be:

```c#
   var input = new string[,]
   {
      //dependency    //item
      {"t-shirt", "dress shirt"},
      {"dress shirt", "pants"},
      {"dress shirt", "suit jacket"},
      {"tie", "suit jacket"},
      {"pants", "suit jacket"},
      {"belt", "suit jacket"},
      {"suit jacket", "overcoat"},
      {"dress shirt", "tie"},
      {"suit jacket", "sun glasses"},
      {"sun glasses", "overcoat"},
      {"left sock", "pants"},
      {"pants", "belt"},
      {"suit jacket", "left shoe"},
      {"suit jacket", "right shoe"},
      {"left shoe", "overcoat"},
      {"right sock", "pants"},
      {"right shoe", "overcoat"},
      {"t-shirt", "suit jacket"}
   }; 
```

In this example, it shows that they must put on their left sock before their pants. Also, 
they must put on their pants before their belt.

From this data, write a program that provides the order that each object needs to be put on.

The output should be a line-delimited list of objects. If there are multiple objects that
can be done at the same time, list each object on the same line, alphabetically 
sorted, comma separated.

Therefore, the output for this sample file would be:

left sock, right sock, t-shirt
dress shirt
pants, tie
belt
suit jacket
left shoe, right shoe, sun glasses
overcoat

Evaluation Criteria

You will be evaluated on the following criteria:

1. Correctness of the solution
2. Algorithmic, logic, and programming skills
3. Performance considerations
4. Design and code structure (modular, etc)
5. Coding style
6. Usability
7. Testability
8. Documentation