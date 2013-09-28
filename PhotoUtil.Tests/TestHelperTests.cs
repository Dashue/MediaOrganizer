using System.IO;
using System.Linq;
using Xunit;

namespace PhotoUtil.Tests
{
    public class TestHelperTests
    {
        [Fact]
        public void Get_test_file_paths_should_return_all_images_of_supported_types()
        {
            var fileNames = TestHelper.GetTestFilePaths();

            Assert.Equal(3, fileNames.Count);
            Assert.Equal("GOPR0945.MP4", fileNames[1]);
            Assert.Equal("IMG_20111005_171340.jpg", fileNames[2]);
        }

        [Fact]
        public void Setup_test_data_folder_should_create_folder_and_copy_content()
        {
            using (var testHelper = new TestHelper("ansoegningsskemaimp.pdf", "IMG_20111005_171340.jpg"))
            {
                var testFiles = Directory.GetFiles(testHelper.PhotoPath).ToList();

                Assert.True(testHelper.PhotoPath.StartsWith(@"c:\tmp\photoutiltestdata\"));
                Assert.Equal(2, testFiles.Count);
            }
        }

        [Fact]
        public void Tear_down_test_data_should_remove_test_folder()
        {
            string path;
            using (var testHelper = new TestHelper())
            {
                path = testHelper.PhotoPath;
            }

            Assert.False(Directory.Exists(path));
        }
    }
}