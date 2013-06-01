using Discrete_Event_Simulator.Events;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DES_Tests
{
    
    
    /// <summary>
    ///This is a test class for Event_SortTimeAscendingHelperTest and is intended
    ///to contain all Event_SortTimeAscendingHelperTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EventSortTimeAscendingHelperTest
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Compare
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Discrete Event Simulator.exe")]
        public void Compare_X_greater_than_Y_Test()
        {
            Event_Accessor.SortTimeAscendingHelper target = new Event_Accessor.SortTimeAscendingHelper();
            Event x = new Event {EventTime = 10};
            Event y = new Event {EventTime = 5};
            const int expected = 1;
            int actual = target.Compare(x, y);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DeploymentItem("Discrete Event Simulator.exe")]
        public void Compare_X_less_than_Y_Test()
        {
            Event_Accessor.SortTimeAscendingHelper target = new Event_Accessor.SortTimeAscendingHelper();
            Event x = new Event {EventTime = 5};
            Event y = new Event {EventTime = 10};
            const int expected = -1;
            int actual = target.Compare(x, y);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DeploymentItem("Discrete Event Simulator.exe")]
        public void Compare_X_equals_Y_Test()
        {
            Event_Accessor.SortTimeAscendingHelper target = new Event_Accessor.SortTimeAscendingHelper();
            Event x = new Event { EventTime = 10 };
            Event y = new Event { EventTime = 10 };
            const int expected = 0;
            int actual = target.Compare(x, y);
            Assert.AreEqual(expected, actual);
        }
    }
}
