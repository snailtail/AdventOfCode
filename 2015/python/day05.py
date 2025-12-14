"""
    Day 5: Doesn't He Have Intern-Elves For This?
"""
import string


class NiceString:
    """
A nice string is one with all of the following properties:

It contains at least three vowels (aeiou only), like aei, xazegov, or aeiouaeiouaeiou.
It contains at least one letter that appears twice in a row, like xx, abcdde (dd), or aabbccdd (aa, bb, cc, or dd).
It does not contain the strings ab, cd, pq, or xy, even if they are part of one of the other requirements.

For example:

ugknbfddgicrmopn is nice because it has at least three vowels (u...i...o...), a double letter (...dd...), and none of the disallowed substrings.
aaa is nice because it has at least three vowels and a double letter, even though the letters used by different rules overlap.
jchzalrnumimnmhp is naughty because it has no double letter.
haegwjzuvuyypxyu is naughty because it contains the string xy.
dvszwmarrgswjxmb is naughty because it contains only one vowel.
"""
    def __init__(self, text: str):
        self.text = text

    def contains_forbidden_strings(self) -> bool:
        forbidden_strings=["ab","cd","pq","xy"]
        if any(forbidden in self.text for forbidden in forbidden_strings):
            return True
    
        return False
    def count_distinct_vowels(self) -> int:
        legal_vowels="aeiou"
        count = sum([1 for vowel in legal_vowels if vowel in self.text])
        return count
    
    def count_legal_vowels(self) -> int:
        legal_vowels="aeiou"
        count = sum(self.text.count(vowel) for vowel in legal_vowels)
        return count
    
    def contains_double_letters(self) -> bool:
        for c in string.ascii_lowercase:
            if c*2 in self.text:
                return True
        
        return False
    
    def has_double_pair_not_overlapping(self) -> bool:
        # slow version - scan string 2 chars at a time.
        #check if .find starting from a good index finds this muthafuckah
        for i in range(1,len(self.text)-1,2):
            chunk = self.text[i-1:i+1]
            if self.text.find(chunk,i+1) > -1:
                return True
        return False
    
    def has_letter_repeating_with_other_letter_inbetween(self) -> bool:
        index = 0
        for i in range(len(self.text)-2):
            letter_1 = self.text[index]
            letter_2 = self.text[index+1]
            letter_3 = self.text[index+2]
            if letter_1 == letter_3 and letter_1 != letter_2:
                return True
            index += 1

            print("".join([letter_1, letter_2, letter_3]))
        return False
    
    def is_nice(self, part2:bool=False) -> bool:
        if not part2:
            if self.contains_forbidden_strings():
                return False
            
            if self.count_legal_vowels() < 3:
                return False
            
            if not self.contains_double_letters():
                return False
            
            return True
        elif part2:
            if self.has_double_pair_not_overlapping() and self.has_letter_repeating_with_other_letter_inbetween():
                return True
            
            return False

def setup(path="input_day05.dat"):
    with open(path,'r') as f:
        return [NiceString(line.strip()) for line in f.readlines()]
    

if __name__ == "__main__":
    data = setup()
    #p1 = sum(1 for ns in data if ns.is_nice())
    p2 = sum(1 for ns in data if ns.is_nice(part2=True))
    #print("Part 1:", p1)
    print("Part 2:", p2)

    