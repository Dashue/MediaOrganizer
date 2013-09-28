using System;
using PhotoUtil.Helpers;
using Xunit;

namespace PhotoUtil.Tests.HelperTests
{
	public class DirectoryHelperTests
	{
		private readonly DateTime _date = new DateTime(2005, 12, 4, 12, 24, 15, 45);

		[Fact]
		public void New_file_path_should_return_expected()
		{
			var filePath = DirectoryHelper.NewFileName(_date, ".jpg");

			Assert.Equal(@"20051204_122415.jpg", filePath);
		} 
	}
}