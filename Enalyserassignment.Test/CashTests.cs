using EnalyserAssignment.BAL;
using EnalyserAssignment.Controllers;
using NUnit.Framework;
using Moq;
using Castle.Core.Configuration;
using System.Collections.Generic;
using EnalyserAssignment.DAL.Models;
using EnalyserAssignment;
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.AspNetCore.Mvc;

namespace Enalyserassignment.Test
{
    [TestFixture()]
    public class CashTests
    {
        private CashController cashController;
        private Mock<ICash> cash;
        private readonly Mock<IConfiguration> mockConfig;
        public CashTests()
        {
            mockConfig = new Mock<IConfiguration>();
            cash = new Mock<ICash>();
            cashController = new CashController(cash.Object);
        }
              [Test]
        public void TestGetAllNotes()
        {
            cash.Setup(x => x.GetAllNotesDetails()).Returns(GetExpectedNotesDetails);
            var testCashController = cashController.GetAllNotes();
            Assert.IsNotNull(testCashController);
            Assert.AreEqual(((ObjectResult)testCashController).StatusCode, StatusCodes.Status200OK);
            Assert.AreEqual(((CustomResponse)((ObjectResult)testCashController).Value).Success.Count, 2);

            //Exception case
            cash.Setup(x => x.GetAllNotesDetails()).Throws(new Exception());
            testCashController = cashController.GetAllNotes();
            Assert.IsNotNull(testCashController);
            Assert.AreEqual(((ObjectResult)testCashController).StatusCode, StatusCodes.Status400BadRequest);
        }

        [Test]
        public void TestGetCash()
        {
            int amount = 1501;
            cash.Setup(x => x.GetCash(amount)).Returns(GetExpectedCashDetails);
            var testCashController = cashController.GetCash(amount);
            Assert.IsNotNull(testCashController);
            Assert.AreEqual(((ObjectResult)testCashController).StatusCode, StatusCodes.Status200OK);
            Assert.AreEqual(((CustomResponse)((ObjectResult)testCashController).Value).Success.Count, 3);

            //Exception case
            cash.Setup(x => x.GetAllNotesDetails()).Throws(new Exception());
            testCashController = cashController.GetAllNotes();
            Assert.IsNotNull(testCashController);
            Assert.AreEqual(((ObjectResult)testCashController).StatusCode, StatusCodes.Status400BadRequest);
        }

        #region Test Data Setup
        public static List<Notes> GetExpectedNotesDetails()
        {
            Notes note1 = new Notes
            {
                Amount = 100,
                Id = 1,
                NoteType = true,
                Size = null
            };

            Notes note2 = new Notes
            {
                Amount = 20,
                Id = 2,
                NoteType = false,
                Size = 40
            };
            List<Notes> notesDetails = new List<Notes> { note1, note2 };

            return notesDetails;
        }

        public static List<CashWithdrawal> GetExpectedCashDetails()
        {
            CashWithdrawal cash1 = new CashWithdrawal
            {
                Amount = 1000,
                Count = 1,
                NoteType = true,
                Size = null
            };

            CashWithdrawal cash2 = new CashWithdrawal
            {
                Amount = 500,
                Count = 1,
                NoteType = true,
                Size = null
            };

            CashWithdrawal cash3 = new CashWithdrawal
            {
                Amount = 1,
                Count = 1,
                NoteType = false,
                Size = 10
            };
            List<CashWithdrawal> notesDetails = new List<CashWithdrawal> { cash1, cash2, cash3 };

            return notesDetails;
        }
        #endregion
    }
}