using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PPCRental.Controllers;
using PPCRental.Models;
using PPCRental.UnitTests.Support;

namespace PPCRental.UnitTests
{
    [TestClass]
    public class BookValidationTests
    {
        /// <summary>
        /// Purpose of TC: 
        /// - Validate whether with valid input data, a book record is created and saved into database, 
        ///     and then the user is redirected to the Index action
        /// </summary>
        [TestMethod]
        public void ValidateRegisterAccountModel_WithValidModel()
        {
            //Arrange
            using (ppcrental3119Entities db = new ppcrental3119Entities())
            {
            var controller = new UserController();
                Random random = new Random();
                string address = string.Format("qa{0:0000}@test.com", random.Next(10000));
                string password = "123456";
                USERMetadata user = new USERMetadata { 
                    Email = address,
                    Password = password,
                    ConfirmPassword = password,
                    FullName = "Nguyen Van A",
                    Phone = "0903771612",
                    Address = "Tp. HCM",
                    SecretQuestion_ID = 1,
                    Answer = "AbcXyz",
                };
                var validationResults = TestModelHelper.ValidateModel(controller, user);

                //Act
                //var redirectRoute = controller.Register(user) as RedirectToRouteResult;

                ////Assert
                //Assert.IsNotNull(redirectRoute);
                //Assert.AreEqual("Index", redirectRoute.RouteValues["action"]);
                //Assert.AreEqual("Catalog", redirectRoute.RouteValues["controller"]);
                var result = controller.Register(user) as ViewResult;
                Assert.AreEqual(0, validationResults.Count);
                Assert.AreEqual("Successful Register", result.ViewBag.SuccessMessage);
            }
                
        }

    }
}
