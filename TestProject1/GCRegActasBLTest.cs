using BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Entidades;
using System.Collections.Generic;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for GCRegActasBLTest and is intended
    ///to contain all GCRegActasBLTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GCRegActasBLTest
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


        /// <summary>
        ///A test for GetRutaActas
        ///</summary>
        [TestMethod()]
        public void GetRutaActasTest()
        {
           /* GCRegActasBL target = new GCRegActasBL(); // TODO: Initialize to an appropriate value
            string cod_con = string.Empty; // TODO: Initialize to an appropriate value
            IList<ESTADOS> expected = null; // TODO: Initialize to an appropriate value
            IList<ESTADOS> actual;
            actual = target.GetRutaActas(cod_con);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
            * */
        }
    }
}
