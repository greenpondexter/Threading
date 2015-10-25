using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ThreadApplication
{
    class ReaderWriter
    {

        string path = "";
        int lines = 1000; 
        StreamWriter writer = new StreamWriter("C:\\Users\\christopher.workman\\Desktop\\test.txt");

        public ReaderWriter()
        {

        }

        public void writeToFile()
        {
            for (int i = 0; i < lines; i++)
            {
                writer.WriteLine("Line "+i+": My first file");
            }
            writer.Close();
        }
    }
}
