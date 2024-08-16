using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace String_searcher.Tests
{
    [TestClass]
    public class Words_end_Ya
    {
        [TestMethod]
        public void Test_WordsEndingWithYa()
        {
            string text = "Сегодня я пошла в магазин и купила яблоко.";
            string expectedOutput = "Слова оканчивающиеся на букву 'я':\nСегодня\nя";

            string actualOutput = Words_ending_with.Words_end_letter(text);

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void Test_EmptyString()
        {
            string text = "";
            string expectedOutput = "Слова оканчивающиеся на букву 'я':";

            string actualOutput = Words_ending_with.Words_end_letter(text);

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void Test_SymbolsOnly()
        {
            string text = "!@#$%^&*()";
            string expectedOutput = "Слова оканчивающиеся на букву 'я':";
            string actualOutput = Words_ending_with.Words_end_letter(text);
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void Test_Many_Words_WithYa()
        {
            string text = "Мария, Татьяна, Ольга, Анастасия, Екатерина, Александрия, Юлия, Ксения, Дарья.";
            string expected = "Слова оканчивающиеся на букву 'я':\nМария\nАнастасия\nАлександрия\nЮлия\nКсения\nДарья";
            string actual = Words_ending_with.Words_end_letter(text);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Foreign_Language()
        {
            string text = "I am doing my homework right now. Please, don't disturb me!";
            string expectedOutput = "Слова оканчивающиеся на букву 'я':";
            string actualOutput = Words_ending_with.Words_end_letter(text);
            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
