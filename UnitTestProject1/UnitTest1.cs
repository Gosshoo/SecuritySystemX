using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Security_System_X_WebService;
using Security_System_X_WebService.Model;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestInsertMotion()
        {
            Service1 service1 = new Service1();
            Assert.AreEqual(1,service1.InsertMotion(new Motion() {DateTime = "2017-12-07 12:19:37.466541", MotionLevel = "High"}));
        }
        [TestMethod]
        public void TestInsertNoise()
        {
            Service1 service1 = new Service1();
            Assert.AreEqual(1, service1.InsertNoise(new Noise() { DateTime = "2017-12-07 12:19:37.466541", NoiseLevel = "High" }));
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestInsertNoiseException()
        {
            Service1 service1 = new Service1();
            service1.InsertNoise(new Noise() {});
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestInsertMotionException()
        {
            Service1 service1 = new Service1();
            service1.InsertMotion(new Motion() { });
        }
        [TestMethod]
        public void TestDelete()
        {
            Service1 service1 = new Service1();
            Assert.AreEqual(1,service1.DeleteNoise(service1.GetNoise().ID.ToString()));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestDeleteException()
        {
            Service1 service1 = new Service1();
            service1.DeleteNoise("785");
        }
        [TestMethod]
        public void TestGetMotions()
        {
            Service1 service1 = new Service1();
            service1.GetMotions();
        }
        [TestMethod]
        public void TestGetNoises()
        {
            Service1 service1 = new Service1();
            service1.GetNoises();
        }
        [TestMethod]
        public void TestGetMotion()
        {
            Service1 service1 = new Service1();
            service1.GetMotion();
        }
        [TestMethod]
        public void TestGetNoise()
        {
            Service1 service1 = new Service1();
            service1.GetNoise();
        }
        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void TestGetNoiseException()
        //{
        //    Service1 service1 = new Service1();
        //    service1.GetNoise();
        //}
        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void TestGetMotionException()
        //{
        //    Service1 service1 = new Service1();
        //    service1.GetMotion();
        //}
    }
}
