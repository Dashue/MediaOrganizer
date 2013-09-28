using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PhotoUtil.Tests
{
    public class TestHelper : IDisposable
    {
        public string PhotoPath { get; private set; }
        private readonly string _testDataPath;

        private string TempDataFolder = @"c:\tmp\photoutiltestdata\";

        public TestHelper()
            : this("")
        {

        }

        public TestHelper(params string[] fileNames)
        {
            Directory.SetCurrentDirectory(Path.GetDirectoryName(AppDomain.CurrentDomain.
                                                                    BaseDirectory) + @"\..");

            _testDataPath = string.Format(TempDataFolder + "{0}", Guid.NewGuid());
            Directory.CreateDirectory(_testDataPath);

            if (fileNames.Any() && false == string.IsNullOrWhiteSpace(fileNames[0]))
            {
                foreach (var fileName in fileNames)
                {
                    File.Copy(FullPathToTestImages() + @"\" + fileName, _testDataPath + @"\" + fileName);
                }
            }

            PhotoPath = _testDataPath;
        }

        public void Dispose()
        {
            Directory.Delete(_testDataPath, true);
        }

        public static List<string> GetTestFilePaths()
        {
            Directory.SetCurrentDirectory(Path.GetDirectoryName(AppDomain.CurrentDomain.
                                                                    BaseDirectory) + @"\..");
            var fullPathToTestImages = FullPathToTestImages();

            var files = Directory.GetFiles(fullPathToTestImages).Select(Path.GetFileName);

            return files.ToList();
        }

        private static string FullPathToTestImages()
        {
            return Path.GetFullPath(@"TestData");
        }
    }
}