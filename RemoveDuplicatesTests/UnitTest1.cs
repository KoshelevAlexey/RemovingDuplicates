using Microsoft.VisualStudio.TestTools.UnitTesting;
using RemovingDuplicates.JsonService;
using System;

namespace RemoveDuplicatesTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateObjectFromJsonFileTest()
        {
            var path = Properties.Settings.Default.TestJsonPath;
            var arr = JsonServ.CreateEntityFromJsonFile<JsonObj[]>(path);
            Assert.IsTrue(arr.Length == 4);
        }
        [TestMethod]
        public void RemoveDuplicatesFromJsonTest()
        {
            var path = Properties.Settings.Default.TestJsonPath;
            var arr = JsonServ.CreateEntityFromJsonFile<JsonObj[]>(path);
            var list = JsonServ.CreateNonDuplicatesList(arr);
            Assert.IsTrue(list.Count == 3);
        }
    }
}
