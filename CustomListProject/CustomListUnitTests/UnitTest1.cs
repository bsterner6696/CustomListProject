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
            CustomList<string> basicList = new CustomList<string>(5);
            int length = basicList.GetLength();
            Assert.AreEqual(5, length);

        }
    }
}
