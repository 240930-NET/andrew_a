using System;
using Project0.Program;
using Xunit;

namespace Project0.Tests
{
    public class WordTranslationTester
    {   
        private readonly WordTranslator translator;

        public WordTranslationTester() {
            translator = new WordTranslator();
        }

        [Theory]
        [InlineData("the")]
        [InlineData("the")]
        [InlineData("the")]
        public void TestTheToThy(string word)
        {   
            string translated = translator.TranslateWord(word);
            Assert.True(translated == "thy", $"{word} should translate to thy");
        }
    }
}
