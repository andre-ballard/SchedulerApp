using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchedulerApp.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerApp.Tests.ScheduleLogic
{
    [TestClass]
    class Person
    {
        [TestMethod]
        public void PersonListTest()
        {
            var pl = new LogicBroker();
            var expected = 0;
            var actual = pl.Persons();

            Assert.IsTrue(actual.Count >= expected);
        }
    }
}
