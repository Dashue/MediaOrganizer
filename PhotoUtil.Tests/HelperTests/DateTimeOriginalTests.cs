using System;
using PhotoUtil.Helpers;
using Xunit;

namespace PhotoUtil.Tests.HelperTests
{
    public class DateTimeOriginalTests
    {
        [Fact]
        public void Should_return_date_time_original()
        {
            using (var testHelper = new TestHelper("IMG_20111005_171340.jpg"))
            {
                var dateTimeOriginal =
                    DateHelper.DateTimeOriginal(testHelper.PhotoPath + @"\" + @"IMG_20111005_171340.jpg");

                Assert.Equal(new DateTime(2011, 10, 5, 17, 13, 40), dateTimeOriginal);
            }
        }
    }
}