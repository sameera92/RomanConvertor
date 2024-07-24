# Roman Numeral Converter with TDD

Test-Driven Development (TDD) is a software development process that involves writing tests before writing the corresponding code. The process typically follows these steps:

1. Red Phase: Write a Failing Test
Write a test: Start by writing a test for the next bit of functionality you want to add.
Ensure the test fails: Run the test to ensure it fails, which confirms that the feature doesn't exist yet or the implementation is incorrect.

3. Green Phase: Write the Minimum Code to Pass the Test
Write the code: Write just enough code to make the test pass. The focus is on simplicity and correctness.
Run the test: Ensure that the test passes with the new code.

5. Refactor Phase: Improve the Code
Refactor the code: Clean up the code while keeping the functionality the same. Improve the design, remove duplication, and ensure code quality.
Run all tests: Ensure that all tests still pass after the refactoring.

**Steps **

1. create class with unit test
//Arrange //Act //Assert
var convertor = new RomanNumberConvertor();
generate New file
UT Name - Should_Exist_Convertor-> 
var convertor = new RomanNumberConvertor();
Assert.NotNull(convertor);

2. create method with unit test
Should_Take_String_Return_Int->
// Arrange
var convertor= new RomanNumberConvertor();
string roman = "I";
// Act
var result = convertor.ConvertRomanToInt(roman);
//Assert
Assert.IsType<int>(result);

3. Convert_I_To_1
UT Name -  Should_Return_1_For_Roman_I -> 
//Arrange
var convertor= new RomanNumberConvertor();
string roman = "I";
// Act
var result = convertor.ConvertRomanToInt(roman);
// Assert
Assert.Equal(1, _romanToDecimal.RomanToInteger(roman));

4. Convert_II_To_2
UT Name -  Should_Return_2_For_Roman_II -> 
//Arrange
var convertor= new RomanNumberConvertor();
string roman = "II";
// Act
var result = convertor.ConvertRomanToInt(roman);
// Assert
Assert.Equal(2, _romanToDecimal.RomanToInteger(roman));

5. Convert_III_To_3 and V

REFACTOR

I. create another project
** make public the class you created

II. generate Dictionary "RomanMap"
        private static readonly Dictionary<char, int> 
RomanMap = new()
{{ 'I', 1 },{ 'V', 5 },{ 'X', 10 },
{ 'L', 50 },{ 'C', 100 },{ 'D', 500 },{ 'M', 1000 }};

for loop with map
   
	    int number = 0;
            for (int i = 0; i < roman.Length; i++)
            {
                    number += RomanMap[roman[i]];
            }
            return number;

III. Unit Test refactor

        [Theory]
        [InlineData("I", 1)]
        [InlineData("II", 2)]
        [InlineData("III", 3)]
        [InlineData("V", 5)]
        public void Should_Return_Valid_Value_With_Roman_Input(string roman,int expected) { 
        
        Assert.Equal(expected,_romanToDecimal.ConvertRomanToInt(roman));
        
        }

6. Convert_IV_To_4 // for loop from 1

          int prevValue = Roman[roman[0]];
            for (int i = 1; i < roman.Length; i++)
            {
	        int currentValue = Roman[roman[i]];
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
            number += prevValue;

            return number;
            }

7. Convert_VI_To_6
 Should Work

8. Convert_Lower_case_roman - before upper need to check null or empty
   
	 	 roman = roman.ToUpper();
   
9. Validations - Empty String or Null
Run Unit Test with Empty Value
UT->  Assert.Throws<ArgumentException>(() => _romanToDecimal.RomanToInteger(roman));

	    if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException($"{nameof(input)} is null or empty");
            }

10. Should_Throw_ArgumentException_When_Input_Not_RomanNumeral
    
            if (roman.Any(c => !RomanMap.ContainsKey(c)))
            {
                throw new ArgumentException("Invalid Roman numeral character.");
            }

11. Should_Throw_ArgumentException_When_Input_Not_RomanNumeral
	1. IIII,XXXX,CCCC,MMMM
	2. VV,LL,DD
    
	            	int repeatCount = 1;
                if (currentValue == prevValue)
                {
                    repeatCount++;
                    if ((repeatCount > 3 && "IXCM".Contains(roman[i])) ||
                        (repeatCount > 1 && "VLD".Contains(roman[i])))
                    {
                        throw new ArgumentException($"Invalid Roman numeral sequence: {roman}");
                    }
                }
                else
                {
                    repeatCount = 1;
                }

12. Should_Throw_ArgumentException_When_Input_Not_RomanNumeral
    1. VX,XM,XD
// I and v or x - valid
// x and l or c - valid
// c and d or m - valid

            if (currentValue > prevValue)
            {
                if (!(
                    (prevValue == RomanMap['I'] && (currentValue == RomanMap['V'] 
            || currentValue == RomanMap['X'])) ||
                    (prevValue == RomanMap['X'] && (currentValue == RomanMap['L'] 
            || currentValue == RomanMap['C'])) ||
                    (prevValue == RomanMap['C'] && (currentValue == RomanMap['D'] 
            || currentValue == RomanMap['M']))
                ))
                {
                    throw new ArgumentException("Invalid subtractive combination.");
                }
            }

// Code should be like this so far

        public int RomanToInt(string roman)
        {
            if (string.IsNullOrEmpty(roman))
            {
                throw new ArgumentException($"{nameof(roman)} is null or empty");

            }
            roman = roman.ToUpper();
            if (roman.Any(c => !RomanMap.ContainsKey(c)))
            {
                throw new ArgumentException($"{nameof(roman)} is null or empty");
            }

            int number = 0;
            int repeatCount = 1;
            int prevValue = RomanMap[roman[0]];
            for (int i = 1; i < roman.Length; i++)
            {
                int currentValue = RomanMap[roman[i]];

                if (currentValue == prevValue)
                {
                    repeatCount++;
                    if ((repeatCount >3 && "IXCM".Contains(roman[i])) ||
                        (repeatCount>1 && "VLD".Contains(roman[i]))) { 
                             throw new ArgumentException("Invalid");
                    }

                }
                else {
                    repeatCount = 1;
                }


                if (currentValue > prevValue)
                {
                    if (!(
                        (prevValue == RomanMap['I'] && (currentValue == RomanMap['V'] || currentValue == RomanMap['X'])) ||
                        (prevValue == RomanMap['X'] && (currentValue == RomanMap['L'] || currentValue == RomanMap['C'])) ||
                        (prevValue == RomanMap['C'] && (currentValue == RomanMap['D'] || currentValue == RomanMap['M']))
                    ))
                    {
                        throw new ArgumentException("Invalid subtractive combination.");
                    }
             
                }

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
            number += prevValue;
            return number;
        }
13. Refactor code by decouple validations
