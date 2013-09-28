using System;
using ExifLib;

namespace PhotoUtil.Helpers
{
	public static class DateHelper
	{
		public static string DateTaken(DateTime dateTimeOriginal, string separator)
		{
			var format = string.Format("yyyy{0}MM{0}dd", separator);

			var dateTaken = dateTimeOriginal.Date.ToString(format);
			return dateTaken;
		}

		public static string TimeTaken(DateTime dateTimeOriginal)
		{
			var timeTaken = string.Format(dateTimeOriginal.TimeOfDay.ToString("hhmmss"));
			return timeTaken;
		}

		public static DateTime DateTimeOriginal(string filePath)
		{
			var reader = new ExifReader(filePath);
			DateTime datePictureTaken;

			if (reader.GetTagValue(ExifTags.DateTimeOriginal, out datePictureTaken))
			{
				reader.Dispose();
				return datePictureTaken;
			}

			throw new ArgumentNullException("DateTimeOriginal", "Unable to read date picture taken");
		}
	}
}