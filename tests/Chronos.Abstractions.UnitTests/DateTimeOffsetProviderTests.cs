using Chronos.Abstractions;
using FakeItEasy;
using System;
using Xunit;

namespace Chronos.UnitTests
{
    public class DateTimeOffsetProviderTests
    {
        [Fact]
        public void UtcNow_ShouldBeFakeable()
        {
            // Arrange
            var franceOffset = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time").BaseUtcOffset;
            var dateTimeOffsetProvider = A.Fake<IDateTimeOffsetProvider>();

            // Act
            A.CallTo(() => dateTimeOffsetProvider.UtcNow).Returns(new DateTimeOffset(4242, 7, 7, 13, 37, 7, franceOffset));

            // Assert
            Assert.Equal(new DateTimeOffset(4242, 7, 7, 13, 37, 7, franceOffset), dateTimeOffsetProvider.UtcNow);
        }

        [Fact]
        public void Now_ShouldBeFakeable()
        {
            // Arrange
            var franceOffset = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time").BaseUtcOffset;
            var dateTimeOffsetProvider = A.Fake<IDateTimeOffsetProvider>();

            // Act
            A.CallTo(() => dateTimeOffsetProvider.Now).Returns(new DateTimeOffset(4242, 7, 7, 13, 37, 7, franceOffset));

            // Assert
            Assert.Equal(new DateTimeOffset(4242, 7, 7, 13, 37, 7, franceOffset), dateTimeOffsetProvider.Now);
        }
    }
}
