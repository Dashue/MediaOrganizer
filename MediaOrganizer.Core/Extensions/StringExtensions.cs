using System;
using System.Linq;
using MediaOrganizer.Core.Helpers;

namespace MediaOrganizer.Core.Extensions
{
    public static class StringExtensions
    {
        public static string GetFileExtension(this string value)
        {
            return value.Substring(value.LastIndexOf(".", StringComparison.InvariantCultureIgnoreCase) + 1);
        }

        public static bool IsSupportedImage(this string extension)
        {
            return ConfigHelper.SupportedImages.Any(x => x.Equals(extension, StringComparison.InvariantCultureIgnoreCase));
        }

        public static bool IsSupportedVideo(this string extension)
        {
            return ConfigHelper.SupportedVideos.Any(x => x.Equals(extension, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}