using System.Collections.Generic;
using Discrete_Event_Simulator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Discrete_Event_Simulator.Events;

namespace DES_Tests
{
    
    
    /// <summary>
    ///This is a test class for CalendarTest and is intended
    ///to contain all CalendarTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CalendarTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

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

        public List<Event> CreateTestList()
        {
            List<Event> testList = new List<Event>
                {
                    new Event {EventTime = 3},
                    new Event {EventTime = 2},
                    new Event {EventTime = 2},
                    new Event {EventTime = 1}
                };
            return testList;
        }

        /// <summary>
        ///A test for SortEvents
        ///</summary>
        [TestMethod()]
        public void SortEventsTest()
        {
            Calendar target = new Calendar(); // TODO: Initialize to an appropriate value
            List<Event> expected = CreateTestList();
            target.EventList = new List<Event>
                {
                    new Event {EventTime = 3},
                    new Event {EventTime = 2},
                    new Event {EventTime = 1},
                    new Event {EventTime = 2}
                };
            target.SortEvents();
            CollectionAssert.AreEqual(expected, target.EventList);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddEvent
        ///</summary>
        [TestMethod()]
        public void AddEventTest()
        {
            Calendar target = new Calendar(); // TODO: Initialize to an appropriate value
            Event e = null; // TODO: Initialize to an appropriate value
            target.AddEvent(e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetNextEvent
        ///</summary>
        [TestMethod()]
        public void GetNextEventTest()
        {
            Calendar target = new Calendar(); // TODO: Initialize to an appropriate value
            Event expected = null; // TODO: Initialize to an appropriate value
            Event actual;
            actual = target.GetNextEvent();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for RemoveEvent
        ///</summary>
        [TestMethod()]
        public void RemoveEventTest()
        {
            Calendar target = new Calendar(); // TODO: Initialize to an appropriate value
            Event e = null; // TODO: Initialize to an appropriate value
            target.RemoveEvent(e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
