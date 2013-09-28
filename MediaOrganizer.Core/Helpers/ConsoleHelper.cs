using System;

namespace MediaOrganizer.Core.Helpers
{
    internal static class ConsoleHelper
    {
        internal static void WriteMove(string fileName, string newFolderPath)
        {
            var output = string.Format("Moved {0} => {1}", fileName, newFolderPath);
            Console.WriteLine(output);
        }

        public static void WriteMoveStatistics(Statistics statistics)
        {
            var text = string.Format("Moved {0} files into {1} directories",
                                     statistics.Processed,
                                     statistics.Directories);
            Console.WriteLine(text);

            WriteProblems(statistics.Problems);
        }

        private static void WriteProblems(int problems)
        {
            if (problems > 0)
            {
                Console.WriteLine("{0} errors occured", problems);
            }
        }

        public static void WriteRename(string oldFileName, string newFileName)
        {
            var output = string.Format("Renamed {0} => {1}",
                oldFileName,
                newFileName);
            Console.WriteLine(output);
        }

        public static void WriteRenameStatistics(Statistics statistics)
        {
            var text = string.Format("Renamed {0} files",
                                    statistics.Processed);

            Console.WriteLine(text);

            WriteProblems(statistics.Problems);
        }
    }
}