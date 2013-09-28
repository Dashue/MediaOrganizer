using PhotoUtil.Enums;
using PhotoUtil.Extensions;
using PhotoUtil.Helpers;
using System;
using System.Collections.Generic;
using System.IO;

namespace PhotoUtil
{
    public static class PhotoUtility
    {
        private static bool ShowStatistics = false;

        public static void FixPhotos(string rootPath, PhotoAction photoAction)
        {
            var filePaths = Directory.GetFiles(rootPath);

            switch (photoAction)
            {
                case PhotoAction.Move:
                    MovePhotos(rootPath, filePaths);
                    break;
                case PhotoAction.Rename:
                    RenamePhotos(rootPath, filePaths);
                    break;
            }
        }

        private static void MovePhotos(string rootPath, IEnumerable<string> filePaths)
        {
            var statistics = new Statistics();

            foreach (var oldFilePath in filePaths)
            {
                try
                {
                    var extension = oldFilePath.GetFileExtension();
                    string newFolderName = null;

                    if (extension.IsSupportedImage())
                    {
                        var dateTimeOriginal = DateHelper.DateTimeOriginal(oldFilePath);
                        newFolderName = DateHelper.DateTaken(dateTimeOriginal, "_");

                    }
                    else if (extension.IsSupportedVideo())
                    {
                        var creationTime = File.GetLastWriteTime(oldFilePath);
                        newFolderName = DateHelper.DateTaken(creationTime, "_");
                    }

                    if (false == string.IsNullOrWhiteSpace(newFolderName))
                    {
                        var newFolderPath = Path.Combine(rootPath, newFolderName);
                        var fileName = Path.GetFileName(oldFilePath);

                        if (false == Directory.Exists(newFolderPath))
                        {
                            Directory.CreateDirectory(newFolderPath);
                            statistics.Directories++;
                        }

                        if (fileName != null)
                        {
                            File.Move(oldFilePath, Path.Combine(newFolderPath, fileName));
                            ConsoleHelper.WriteMove(fileName, newFolderPath);
                        }

                        statistics.Processed++;
                    }
                }
                catch (Exception)
                {
                    statistics.Problems++;
                }
            }

            if (ShowStatistics)
            {
                ConsoleHelper.WriteMoveStatistics(statistics);
            }
        }

        private static void RenamePhotos(string rootPath, IEnumerable<string> filePaths)
        {
            var statistics = new Statistics();

            foreach (var oldFilePath in filePaths)
            {
                try
                {
                    var dateTimeOriginal = DateHelper.DateTimeOriginal(oldFilePath);

                    var oldFileName = Path.GetFileName(oldFilePath);
                    var filetype = Path.GetExtension(oldFilePath);

                    var newFileName = DirectoryHelper.NewFileName(dateTimeOriginal, filetype);
                    var newPath = Path.Combine(rootPath, newFileName);
                    File.Move(oldFilePath, newPath);

                    statistics.Processed++;
                    ConsoleHelper.WriteRename(oldFileName, newFileName);
                }
                catch (Exception)
                {
                    statistics.Problems++;
                }
            }

            if (ShowStatistics)
            {
                ConsoleHelper.WriteRenameStatistics(statistics);
            }
        }
    }
}