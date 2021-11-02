using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Splitter
{
    class Program
    {
        static void Main(string[] args)
        {
            var qtdLinhas = 100;
            string[] lines = System.IO.File.ReadAllLines(@"fonte.csv");
            int cont = 0;
            int page = 1;
            string fileName = page + "_" + System.IO.Path.GetRandomFileName()  + ".csv";
            foreach (string line in lines)
            {
                if (cont == qtdLinhas)
                {
                    page++;
                    fileName = page + "_" + System.IO.Path.GetRandomFileName() + ".csv";
                    cont = 0;
                }
                var pathString = System.IO.Path.Combine("files", fileName);
                using (StreamWriter writer = new StreamWriter(pathString, true))
                {
                    writer.WriteLine(line);
                }
                cont++;
            }
        }
    }
}
