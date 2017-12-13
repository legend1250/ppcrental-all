//using System;
//using System.Web.Mvc;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using PPCRental.Controllers;
//using PPCRental.Models;
//using PPCRental.UnitTests.Support;

//namespace PPCRental.UnitTests
//{
//    [TestClass]
//    public class BookValidationTests
//    {
//        /// <summary>
//        /// Purpose of TC: 
//        /// - Validate whether with valid input data, a book record is created and saved into database, 
//        ///     and then the user is redirected to the Index action
//        /// </summary>
//        [TestMethod]
//        public void ValidateCreateBookModel_WithValidModel_ExpectValidNavigation()
//        {
//            //Arrange
//            var controller = new UserController();
//            var book = new 
//            {
//                Title = "The Cucumber Book",
//                Author = "Matt Wynne and Aslak Hellesoy",
//                Price = Convert.ToDecimal(18.00)
//            };
//            var validationResults = TestModelHelper.ValidateModel(controller, book);

//            //Act
//            var redirectRoute = controller.Create(book) as RedirectToRouteResult;

//            //Assert
//            Assert.IsNotNull(redirectRoute);
//            Assert.AreEqual("Index", redirectRoute.RouteValues["action"]);
//            Assert.AreEqual("Catalog", redirectRoute.RouteValues["controller"]);
//            Assert.AreEqual(0, validationResults.Count);
//        }

//        /// <summary>
//        /// Purpose of TC:
//        /// - Validate whether with invalid input data (required field 'Title' is null), 
//        ///     the book record cannot be created and an error message should be shown.
//        /// </summary>
//        [TestMethod]
//        public void ValidateCreateBookModel_WithTitleIsNull_ExpectValidationError()
//        {
//            //Arrange
//            var controller = new CatalogController();
//            var book = new Book
//            {
//                Title = "",
//                Author = "David Chelimsky",
//                Price = Convert.ToDecimal(17.50)
//            };
//            var validationResults = TestModelHelper.ValidateModel(controller, book);

//            //Act
//            var viewResult = controller.Create(book) as ViewResult;

//            //Assert
//            Assert.IsNotNull(viewResult);
//            Assert.IsFalse(viewResult.ViewData.ModelState.IsValid);
//            Assert.AreEqual(1, validationResults.Count);
//            Assert.IsTrue(validationResults[0].ErrorMessage.Equals("The Title field is required."));
//        }

//        /// <summary>
//        /// Purpose of TC:
//        /// - Validate whether with invalid input data (required field 'Title' contains space bar only), 
//        ///     the book record cannot be created and an error message should be shown.
//        /// </summary>
//        [TestMethod]
//        public void ValidateCreateBookModel_WithTitleContainsSpaceOnly_ExpectValidationError()
//        {
//            //Arrange
//            var controller = new CatalogController();
//            var book = new Book
//            {
//                Title = "     ",
//                Author = "David Chelimsky",
//                Price = Convert.ToDecimal(17.50)
//            };
//            var validationResults = TestModelHelper.ValidateModel(controller, book);

//            //Act
//            var viewResult = controller.Create(book) as ViewResult;

//            //Assert
//            Assert.IsNotNull(viewResult);
//            //Assert.AreEqual(string.Empty, viewResult.ViewName);
//            Assert.IsFalse(viewResult.ViewData.ModelState.IsValid);
//            Assert.AreEqual(1, validationResults.Count);
//            Assert.IsTrue(validationResults[0].ErrorMessage.Equals("The Title field is required."));
//        }

//        /// <summary>
//        /// Purpose of TC:
//        /// - Validate whether with invalid input data 
//        ///     (required field 'Title' exceeds the maxlength of 100 characters), 
//        ///     the book record cannot be created and an error message should be shown.
//        /// </summary>
//        [TestMethod]
//        public void ValidateCreateBookModel_WithTitleExceeds100Characters_ExpectValidationError()
//        {
//            //Arrange
//            var controller = new CatalogController();
//            var book = new Book
//            {
//                Title = new string('*', 101),
//                Author = "David Chelimsky",
//                Price = Convert.ToDecimal(17.50)
//            };
//            var validationResults = TestModelHelper.ValidateModel(controller, book);

//            //Act
//            var viewResult = controller.Create(book) as ViewResult;

//            //Assert
//            Assert.IsNotNull(viewResult);
//            Assert.IsFalse(viewResult.ViewData.ModelState.IsValid);
//            Assert.AreEqual(1, validationResults.Count);
//            Assert.IsTrue(validationResults[0].ErrorMessage.Equals("The field Title must be a string with a maximum length of 100."));
//        }
//    }
//}
