namespace AdventOfCode
{
    public class Day7
    {
        string[] lines;
        int directorySizeLimit = 100000;
        DirectoryObject rootDirectory;

        int totalRemovable = 0;

        public Day7()
        {
            //lines = File.ReadAllLines("F:\\HKU\\Jaar 3\\advent-of-code-2022\\Advent Of Code\\Day 6\\day6.txt"); //pc
            lines = File.ReadAllLines("C:\\Users\\rbech\\HKU\\advent-of-code-2022\\Advent Of Code\\Day 7\\day7.txt"); //laptop
            rootDirectory = new DirectoryObject("/");

            PopulateFiles();
            Part1();
        }

        ~Day7()
        {

        }

        private void PopulateFiles()
        {
            DirectoryObject curDir = rootDirectory;

            // map all directories based on commands
            foreach(string line in lines)
            {
                string[] info = line.Split(' ');
                
                // a command has been invoked
                if (info[0] == "$")
                {
                    if (info[1] == "cd")
                    {
                        // .. = move 1 directory to the upper level
                        if (info[2] == "..")
                        {
                            if (curDir.parentDirectory != null)
                            {
                                curDir = curDir.parentDirectory;
                            }
                        }
                        // / = move to root
                        else if (info[2] == "/")
                        {
                            curDir = rootDirectory;
                        }
                        // x = move 1 level deeper within current directory to a specific directory
                        else
                        {
                            foreach(DirectoryObject dir in curDir.directories)
                            {
                                if (dir.directoryName == info[2])
                                {
                                    curDir = dir;
                                    break;
                                }
                            }
                        }
                    }
                }
                // current directory contains a directory with name x
                else if (info[0] == "dir")
                {
                    // check if current directory contains x otherwise create x
                    if (!HasDirectory(curDir.directories, info[1]))
                    {
                        DirectoryObject newDir = new DirectoryObject(info[1]);
                        curDir.directories.Add(newDir);
                    }
                }
                // current directory contains a file with name x and size x
                else
                {
                    if (!HasFile(curDir.files, info[1]))
                    {
                        // can split info1 at . to get name[0] and extension[1]
                        FileObject newFile = new FileObject(info[1], int.Parse(info[0]));
                        curDir.files.Add(newFile);
                        curDir.directorySize += int.Parse(info[0]);
                    }
                }
            }
        }

        private void Part1()
        {
            UpdateDirSize(rootDirectory);
            CheckSizes(rootDirectory);
            Tree(rootDirectory, 1);
        }

        private void UpdateDirSize(DirectoryObject dir)
        {
            dir.directorySizeTotal += dir.directorySize;

            foreach (DirectoryObject dirChild in dir.directories)
            {
                UpdateDirSize(dirChild);
                dir.directorySizeTotal += dirChild.directorySizeTotal;
            }
        }

        private void CheckSizes(DirectoryObject dir)
        {
            if (dir.directorySizeTotal <= directorySizeLimit)
            {
                totalRemovable += dir.directorySizeTotal;
            }

            foreach (DirectoryObject dirChild in dir.directories)
            {
                CheckSizes(dirChild);
                if (dirChild.directorySizeTotal <= directorySizeLimit)
                {
                    totalRemovable += dirChild.directorySizeTotal;
                }
            }
        }

        private void Tree(DirectoryObject dir, int iteration)
        {
            string val = "";

            for(int i = 0; i < iteration; i++)
            {
                val += "-";
            }

            foreach (DirectoryObject dirChild in dir.directories)
            {
                Tree(dirChild, iteration + 1);
            }

            Console.WriteLine(val + dir.directoryName + "(" + dir.directorySizeTotal + ")");
        }

        private bool HasDirectory(List<DirectoryObject> directories, string directoryName)
        {
            foreach(DirectoryObject directory in directories)
            {
                if (directory.directoryName == directoryName)
                {
                    return true;
                }    
            }

            return false;
        }

        private bool HasFile(List<FileObject> files, string fileName)
        {
            foreach(FileObject file in files)
            {
                if (file.fileName == fileName)
                {
                    return true;
                }
            }
            return false;
        }

        public void PrintResult()
        {
            Console.WriteLine("Done: " + totalRemovable);
        }
    }

    public class FileObject
    {
        // File has a name
        // File has a size
        public string fileName = "";
        public int fileSize = 0;

        public FileObject(string name, int size)
        {
            fileName = name;
            fileSize = size;
        }
    }

    public class DirectoryObject
    {
        // Directory has a name
        // Directory can have files
        // Directory can have sub directories
        // Directory might have a parent directory
        public string directoryName = "";
        public List<FileObject> files = new List<FileObject>();
        public List<DirectoryObject> directories = new List<DirectoryObject>();
        public DirectoryObject parentDirectory = null;

        public int directorySize = 0;
        public int directorySizeTotal = 0;

        public DirectoryObject(string name)
        {
            directoryName = name;
        }
    }
}
