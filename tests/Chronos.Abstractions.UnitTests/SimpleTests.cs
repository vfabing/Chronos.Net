using Chronos.Abstractions;
using FakeItEasy;
using System;
using Xunit;

namespace Chronos.UnitTests
{
    public class IDateTimeProviderTests
    {
        [Fact]
        public void UtcNow_ShouldBeFakeable()
        {
            // Arrange
            var dateTimeProvider = A.Fake<IDateTimeProvider>();

            // Act
            A.CallTo(() => dateTimeProvider.UtcNow).Returns(new DateTime(4242, 7, 7, 13, 37, 7));

            // Assert
            Assert.Equal(new DateTime(4242, 7, 7, 13, 37, 7), dateTimeProvider.UtcNow);
        }

        [Fact]
        public void Now_ShouldBeFakeable()
        {
            // Arrange
            var dateTimeProvider = A.Fake<IDateTimeProvider>();

            // Act
            A.CallTo(() => dateTimeProvider.Now).Returns(new DateTime(4242, 7, 7, 13, 37, 7));

            // Assert
            Assert.Equal(new DateTime(4242, 7, 7, 13, 37, 7), dateTimeProvider.Now);
        }
    }
}
