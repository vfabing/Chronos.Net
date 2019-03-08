using Chronos.Abstractions;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleWebSample.Controllers;
using System;

namespace SimpleWebSample.UnitTests
{
    [TestClass]
    public class DateTimeDependentControllerTests
    {
        [TestMethod]
        public void GetProductsIfStoreIsOpen_ShouldReturnProducts_WhenCurrentTimeIsDuringStoreOpenedHours()
        {
            // Arrange
            var dateTimeInStoreOpenedHours = new DateTime(2019, 3, 6, 9, 0, 0);
            var expected = new string[] { "Apples", "Bananas", "Strawberries" };

            var dateTimeProvider = A.Fake<IDateTimeProvider>();
            A.CallTo(() => dateTimeProvider.Now).Returns(dateTimeInStoreOpenedHours);

            var controller = new DateTimeDependentController(dateTimeProvider);

            // Act
            var result = controller.GetProductsIfStoreIsOpen();

            // Assert
            CollectionAssert.AreEquivalent(expected, result.Value);
        }

        [TestMethod]
        public void GetProductsIfStoreIsOpen_ShouldReturnAnErrorMessage_WhenCurrentTimeIsOutsideStoreOpenedHours()
        {
            // Arrange
            var dateTimeInStoreOpenedHours = new DateTime(2019, 3, 6, 23, 0, 0);
            var expected = new string[] { "store is not opened" };

            var dateTimeProvider = A.Fake<IDateTimeProvider>();
            A.CallTo(() => dateTimeProvider.Now).Returns(dateTimeInStoreOpenedHours);

            var controller = new DateTimeDependentController(dateTimeProvider);

            // Act
            var result = controller.GetProductsIfStoreIsOpen();

            // Assert
            CollectionAssert.AreEquivalent(expected, result.Value);
        }
    }
}
