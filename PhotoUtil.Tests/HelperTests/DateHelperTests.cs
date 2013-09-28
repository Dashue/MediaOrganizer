using System;
using MediaOrganizer.Core.Helpers;
using Xunit;

namespace PhotoUtil.Tests.HelperTests
{
    public class DateHelperTests
    {
        private readonly DateTime _date = new DateTime(2005, 12, 4, 12, 24, 15, 45);

        [Fact]
        public void Date_taken_should_return_expected()
        {
            var dateString = DateHelper.DateTaken(_date, "_");

            Assert.Equal("2005_12_04", dateString);
        }

        [Fact]
        public void Time_taken_should_return_expected()
        {
            var timeString = DateHelper.TimeTaken(_date);

            Assert.Equal("122415", timeString);
        }
    }
}
