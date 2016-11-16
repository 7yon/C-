using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
    class Program
    {
        static IEnumerable<string> ReadCsv1()
        {
            using (var reader = new StreamReader(File.OpenRead("D:\\C_Sharp\\Files\\Files\\airquality.csv")))
                while (true)
                {
                    var str = reader.ReadLine();
                    if (str == null)
                    {
                        reader.Close();
                        yield break;
                    }

                    var values = str.Split(',');
                    foreach(String value in values)
                    {
                        if (value == "NA")
                            yield return null;
                        else yield return value;
                    }
                }
        }

        static void Main(string[] args)
        {
            foreach (var value in ReadCsv1())
                Console.WriteLine(value);
        }
    }
}
