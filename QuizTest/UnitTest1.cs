using System;
using Xunit;
using SkylarBorwieckSite.Models;

namespace QuizTest
{
    public class QuizAnswerTests
    {
        [Fact]
        public void QuizCorrectTest()
        {
            Assert.Equal(true, QuizModel.CheckAnswer("1975", "1975"));
        }
        [Fact]
        public void QuizIncorrectTest()
        {
            Assert.Equal(false, QuizModel.CheckAnswer("1975", "1999"));
        }

        [Theory]
        [InlineData("1998","1998")]
        [InlineData("1997", "1997")]
        [InlineData("1996", "1996")]
        public void QuizCorrect(string input, string solution)
        {
            Assert.True(QuizModel.CheckAnswer(input,solution));
        }

        [Theory]
        [InlineData("1998", "1984")]
        [InlineData("1997", "199")]
        [InlineData("1996", "19967")]
        public void QuizIncorrectCorrect(string input, string solution)
        {
            Assert.False(QuizModel.CheckAnswer(input, solution));
        }
    }
}
