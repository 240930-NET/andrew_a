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
        [InlineData("the", "ye")]
        [InlineData("The", "Ye")]
        [InlineData("THE", "YE")]
        [InlineData("Here", "Hither")]
        [InlineData("never", "ne'er")]
        [InlineData("PLEASE", "PRITHEE")]
        public void TestWordTranslation(string word, string expected)
        {   
            string translated = translator.TranslateWord(word);
            Assert.True(translated == expected, $"Word translation failed: \"{word}\" should translate to \"{expected}\", got \"{translated}\" instead");
        }

        [Theory]
        [InlineData("Here", "Hither")]
        [InlineData("never", "ne'er")]
        [InlineData("PLEASE", "PRITHEE")]
        [InlineData("The bunny jumps up those hills often.", "Ye bunny jumps up yon hills oft.")]
        [InlineData("YOU ARE A CLOWN!", "THOU ART A JESTER!")]
        [InlineData("Hello and goodbye, sir!", "Good day and good day, sir!")]
        [InlineData("", "")]
        [InlineData(" ", " ")]
        [InlineData("     ", "     ")]
        [InlineData("!?!", "!?!")]
        [InlineData("! ? !", "! ? !")]
        public void TestSentenceTranslation(string word, string expected)
        {   
            string translated = translator.TranslateSentence(word);
            Assert.True(translated == expected, $"Sentence translation failed: \"{word}\" should translate to \"{expected}\", got \"{translated}\" instead");
        }
    }
}
