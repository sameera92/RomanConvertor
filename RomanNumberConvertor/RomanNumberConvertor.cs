using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanNumberConvertor
{
    public class RomanNumberConvertor
    {
        public int ConvertRomanToInt(string? input)
        {
            Dictionary<char, int> Roman = new Dictionary<char, int>() {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000},
            };

            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException($"{nameof(input)} is null or empty");
            }

            string roman = input.ToUpper();
            if (roman.Any(c => !Roman.ContainsKey(c)))
            {
                throw new ArgumentException("Invalid Roman Numeral character");
            }

            int repeatCount = 1;
            int number = 0;
            int prevValue = Roman[roman[0]];

            for (int i = 1; i < roman.Length; i++)
            {
                int currentValue = Roman[roman[i]];

                // Validate repetition and subtraction
                repeatCount = ValidateRoman(roman, repeatCount, prevValue, i, currentValue);

                if (currentValue > prevValue)
                {
                    number -= prevValue;
                }
                else
                {
                    number += prevValue;
                }

                prevValue = currentValue;
            }

            // Add the last value
            number += prevValue;

            return number;
        }

        private bool IsValidSubtraction(char previousChar, char currentChar)
        {
            return (previousChar == 'I' && (currentChar == 'V' || currentChar == 'X')) ||
                   (previousChar == 'X' && (currentChar == 'L' || currentChar == 'C')) ||
                   (previousChar == 'C' && (currentChar == 'D' || currentChar == 'M'));
        }

        private int ValidateRoman(string s, int repeatCount, int prevValue, int i, int currentValue)
        {
            if (currentValue == prevValue)
            {
                repeatCount++;
                if ((repeatCount > 3 && "IXCM".Contains(s[i])) ||
                    (repeatCount > 1 && "VLD".Contains(s[i])))
                {
                    throw new ArgumentException($"Invalid Roman numeral sequence: {s}");
                }
            }
            else
            {
                repeatCount = 1;
            }

            // Check valid subtraction
            if (currentValue > prevValue && !IsValidSubtraction(s[i - 1], s[i]))
            {
                throw new ArgumentException($"Invalid Roman numeral sequence: {s}");
            }

            return repeatCount;
        }
    }
}
