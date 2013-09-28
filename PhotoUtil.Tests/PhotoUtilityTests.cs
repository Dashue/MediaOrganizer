using System.IO;
using System.Linq;
using System.Management.Automation.Runspaces;
using Xunit;

namespace PhotoUtil.Tests
{
    public class PhotoUtilityTests
    {
        [Fact]
        public void Move_photos()
        {
            using (var testHelper = new TestHelper("IMG_20111005_171340.jpg"))
            {
                var myRunSpace = RunspaceFactory.CreateRunspace();
                myRunSpace.Open();

                var pipeline = myRunSpace.CreatePipeline(string.Format("{0} '{1}'", "set-Location", testHelper.PhotoPath));
                pipeline.Invoke();

                pipeline = myRunSpace.CreatePipeline("Import-Module PhotoUtil");
                pipeline.Invoke();

                pipeline = myRunSpace.CreatePipeline("Move-Photos");
                pipeline.Invoke();

                Assert.True(Directory.Exists(testHelper.PhotoPath));
                Assert.Equal(0, Directory.GetFiles(testHelper.PhotoPath).Count());

                var newPath = testHelper.PhotoPath + @"\" + "2011_10_05";
                Assert.True(Directory.Exists(newPath));
            }
        }

        [Fact]
        public void Move_videos()
        {
            using (var testHelper = new TestHelper("GOPR0945.MP4"))
            {
                var myRunSpace = RunspaceFactory.CreateRunspace();
                myRunSpace.Open();

                var pipeline = myRunSpace.CreatePipeline(string.Format("{0} '{1}'", "set-Location", testHelper.PhotoPath));
                pipeline.Invoke();

                pipeline = myRunSpace.CreatePipeline("Import-Module PhotoUtil");
                pipeline.Invoke();

                pipeline = myRunSpace.CreatePipeline("Move-Photos");
                pipeline.Invoke();

                Assert.True(Directory.Exists(testHelper.PhotoPath));
                Assert.Equal(0, Directory.GetFiles(testHelper.PhotoPath).Count());

                var newPath = testHelper.PhotoPath + @"\" + "2012_08_03";
                Assert.True(Directory.Exists(newPath), newPath);
            }
        }

        [Fact]
        public void Rename_photos()
        {
            using (var testHelper = new TestHelper("IMG_20111005_171340.jpg"))
            {
                var myRunSpace = RunspaceFactory.CreateRunspace();
                myRunSpace.Open();

                var pipeline = myRunSpace.CreatePipeline(string.Format("{0} '{1}'", "set-Location", testHelper.PhotoPath));
                pipeline.Invoke();

                pipeline = myRunSpace.CreatePipeline("Import-Module PhotoUtil");
                pipeline.Invoke();

                pipeline = myRunSpace.CreatePipeline("Rename-Photos");
                pipeline.Invoke();

                pipeline.Commands.Clear();

                Assert.True(Directory.Exists(testHelper.PhotoPath));
                var files = Directory.GetFiles(testHelper.PhotoPath);
                Assert.Equal(testHelper.PhotoPath + @"\" + "20111005_171340.jpg", files[0]);
            }
        }
    }
}