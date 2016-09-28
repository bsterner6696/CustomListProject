using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomListProject;

namespace CustomListUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetLengthOfEmptyArrayLength5()
        {
            CustomList<string> basicList = new CustomList<string>();
            int length = basicList.Length;
            Assert.AreEqual(5, length);

        }

        [TestMethod]
        public void GetLengthOfEmptyArrayLength0()
        {
            CustomList<string> basicList = new CustomList<string> { "cow", "pig", " ", " ", " ", " " };
            int length = basicList.Length;
            Assert.AreEqual(12, length);
        }
    }
}
