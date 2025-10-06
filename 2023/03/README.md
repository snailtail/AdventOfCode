# Advent of Code 2023 Day03  

## Step 1  

Allright! A bit of parsing, and a bit of checking neighbors, and then a sum. Should be easy enough right?  
WRONG! Not if you like me write a method that imports the numbers from the input, but fails to import the numbers which appear at the very end of a line.  
Making a nice little bug that allows the test input to run fine, but the real input to fail.  
I got to the point where I almost gave up my career in development, but then I took a bit out of the sour apple as we say in Sweden and started checking that I actually imported all the numbers. Which i didn't. And when I found my _stoopid_ bug Step 1 was easily fixed.  
I made a really big testcase for this in the end :D Check out [TestAllNumbersImportedFromRealData()](../tests/03-test/Day03Tests.cs)

## Step 2  

Not a lot to add to get this working, although I had some bad luck while thinking and again introduced a bug while scanning the matrix. I had added an extra +1 to a for loop in one place, which I was sure I needed. But alas, I did not. Spent less time hunting that bug down, than the one in step 1 at least.  
Once again tried to use TDD. I cheated a bit, should have tested more stuff this way and hence probably broken down some things into smaller or more testable bits.  
Anywho, I'll do better tomorrow ;)

