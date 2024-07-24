namespace RomanNumberConvertor
{
    public class RomanNumberConvertorTest
    {
        private readonly RomanNumberConvertor _romanToDecimal;
        public RomanNumberConvertorTest() {
            _romanToDecimal = new RomanNumberConvertor();
        }
        [Fact]
        public void Should_Exist_Convertor()
        {
            // Arrange
            //var convertor = new RomanNumberConvertor();
            //Act
            //Assert
            Assert.NotNull(_romanToDecimal);

        }

        [Theory]
        [InlineData("I", 1)]
        [InlineData("II", 2)]
        [InlineData("III", 3)]
        [InlineData("V", 5)]
        [InlineData("IV", 4)]
        [InlineData("VI", 6)]
        [InlineData("XX", 20)]
        [InlineData("vi", 6)]
        public void Should_Return_Valid_Value_With_Roman_Input(string roman,int expected) { 
        
        Assert.Equal(expected,_romanToDecimal.ConvertRomanToInt(roman));
        
        }


        [Theory]
        [InlineData("")]
        [InlineData("FF")]
        [InlineData("IIII")]
        [InlineData("VV")]
        [InlineData("VX")]
        public void Should_Throw_Error_If_Not_valid(string input)
        {

            Assert.Throws<ArgumentException>(() => _romanToDecimal.ConvertRomanToInt(input));

        }



    }
}