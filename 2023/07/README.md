# Advent of Code 2023 Day07  

# Part 1

Okay.. interesting...!  
Today we are basically playing poker. How to implement these rules? A lot of thinking about scenarios, and how to score a hand so that it is mathematically possible to see whether one hand is better than the other.  

I settled on building a type `CamelCardHand`, which "knows" what type of hand it is. _Full House_, _Four of a kind_, _One Pair_ etc.  
Besides that I calculate a weight for each hand, depending on the cards and their position in the hand. In the end I used hexadecimal number system, even though the values of the cards only go up to 14, but that could represent each card in it's place in the hand - and generate a weight which I could then use to rank hands of the same type against each other.  

I.E: the hand "T84Q2" would be represented by the hex number "0xA84C2" which in decimal is 689346, and that would differentiate it from the a hand with the same cards in another order: "8TQ24" (hex: "0x8AC24", decimal 568356). In this way it was very easy to see which hand was "worth more".  
After that it was just a matter of parsing the input, and some Linq queries to put together the final ranking array.  


# Part 2  

Holy Smokes Batman :bat: :man: , it's the :black_joker: Joker! :black_joker:  
Oh boy :exploding_head:    
Initially I panicked and thought that okay, this is where I drop out. But after working for a couple of hours, and while eating my lunch I started to think that this might not be that much harder than part 1.
This time my diligent work for Part 1 actually payed off really well for part 2.  
I had some methods which could easily be extended to do some extra calculations, and I added a method for recalculating the type of hand with J as jokercard - without touching the actual weight (apart from the J being worth only 1 this time).  
A bit of thinking about what the best cases would be for each type of hand, and then some more Regex and away we went.  
  
I'm actually proud of myself today, I did a lot of testing - and that payed off a lot, especially during Part 1 when I was trying out different ways to get the weights to work, so that a hand of "QJT987" would actually get a lower ranking than "22345" and so on. Lot's and lot's of edge cases rolled by, but I caught them due to the tests - and putting in some real amount of thinking about what would be good to test.  
