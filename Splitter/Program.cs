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
            var qtdLinhas = 1000;
            string[] lines = System.IO.File.ReadAllLines(@"fonte.csv");

            int cont = 0;
            int page = 1;
            List<string> aux = new List<string>();
            foreach (string line in lines)
            {
                aux.Add(line);
                if (cont == qtdLinhas)
                {
                    
                    cont = 0;
                    string fileName = page + "_" + System.IO.Path.GetRandomFileName()  + ".csv";
                    var pathString = System.IO.Path.Combine("files", fileName);
                    
                    using (StreamWriter writer = new StreamWriter(pathString, true))
                    {
                        foreach(string linha in aux)
                        {
                            writer.WriteLine(linha);
                            
                        }
                    }
                    
                    aux = new List<string>(); 
                    page++;
                }
                cont++;
            }
            if(cont != 0){
                string fileName = page + "_" + System.IO.Path.GetRandomFileName()  + ".csv";
                var pathString = System.IO.Path.Combine("files", fileName);
                if (!System.IO.File.Exists(pathString))
                {
                    using (System.IO.FileStream fs = System.IO.File.Create(pathString))
                    {

                    }
                }
                using (StreamWriter writer = new StreamWriter(pathString, true))
                {
                    foreach (string linha in aux)
                    {
                        writer.WriteLine(linha);

                    }
                }
            }
        }
    }
}
