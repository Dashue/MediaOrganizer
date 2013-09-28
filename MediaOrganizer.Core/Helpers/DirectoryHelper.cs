using System;

namespace MediaOrganizer.Core.Helpers
{
	internal static class DirectoryHelper
	{
		internal static string NewFileName(DateTime dateTimeTaken, string filetype)
		{
			return String.Format(@"{0}_{1}{2}",
			                     DateHelper.DateTaken(dateTimeTaken, ""),
			                     DateHelper.TimeTaken(dateTimeTaken),
			                     filetype);
		}
	}
}