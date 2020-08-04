using LispParenthesesCheckerLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LispParenthesesCheckerTest
{
    [TestClass]
    public class LispParenthesesCheckerTest
    {
        [TestMethod]
        public void TestEmpty()
        {
            var testInput = "";
            var isValid = LispParentheseChecker.Validate(testInput);

            Assert.AreEqual(isValid, true);
        }

        [TestMethod]
        public void TestSuccess_SinglePair()
        {
            var testInput = "()";
            var isValid = LispParentheseChecker.Validate(testInput);

            Assert.AreEqual(isValid, true);
        }

        [TestMethod]
        public void TestSuccess_Nested()
        {
            var testInput = "((()))";
            var isValid = LispParentheseChecker.Validate(testInput);

            Assert.AreEqual(isValid, true);
        }

        [TestMethod]
        public void TestSuccess_ManyPairs()
        {
            var testInput = "((()) () ()(())  )";
            var isValid = LispParentheseChecker.Validate(testInput);

            Assert.AreEqual(isValid, true);
        }

        [TestMethod]
        public void TestFailure_OnlyOpens()
        {
            var testInput = "(((";
            var isValid = LispParentheseChecker.Validate(testInput);

            Assert.AreEqual(isValid, false);
        }

        [TestMethod]
        public void TestFailure_OpenCloseMismatch()
        {
            var testInput = "((( ))";
            var isValid = LispParentheseChecker.Validate(testInput);

            Assert.AreEqual(isValid, false);
        }

        [TestMethod]
        public void TestFailure_OpenCloseOrder()
        {
            var testInput = ")) ((";
            var isValid = LispParentheseChecker.Validate(testInput);

            Assert.AreEqual(isValid, false);
        }
    }
}
