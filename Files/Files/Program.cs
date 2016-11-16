using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
                        yield break;
                    }

                    var values = str.Split(',');
                    foreach(String value in values)
                    {
                        if (value == "NA")
                            yield return null;
                        else
                            yield return value;
                    }
                }
        }

        static IEnumerable<T> ReadCsv2<T>() where T : new()
        {
            bool firstString = true;
            string[] fields = null;

            using (var reader = new StreamReader(File.OpenRead("D:\\C_Sharp\\Files\\Files\\airquality.csv")))          

                while (true)
                {
                    var str = reader.ReadLine();
                    if (str == null)
                    {
                        yield break;
                    }

                    var values = str.Split(',');

                    if (firstString)
                    {
                        fields = values;
                        firstString = false;
                    }
                    else
                    {
                        T myObject = new T();
                        Type myObjectType = typeof(T);

                        for (int i = 0; i < values.Length; i++)
                        {                           
                            PropertyInfo currentInfo = myObjectType.GetProperty(fields[i]);

                            if((values[i] == "NA") && ((fields[i] == "Name") || (fields[i] == "Wind") || (fields[i] == "Temp") || (fields[i] == "Month") || (fields[i] == "Day")))
                            {
                                throw new ArgumentException("Поле " + fields[i] + " не может быть null!");
                            }
                            else
                            {
                                object currentValue = null;
                                Type currentType = currentInfo.PropertyType;

                                if (values[i] != "NA")
                                {
                                    if (currentType == typeof(int) || (currentType == typeof(int?)))
                                        currentValue = Convert.ToInt32(values[i]);
                                    if (currentType == typeof(double) || (currentType == typeof(double?)))
                                        currentValue = Convert.ToDouble(values[i].Replace('.', ','));
                                }
                                                               
                                myObjectType.GetProperty(fields[i]).SetValue(myObject, currentValue);
                                yield return myObject;
                            }
                        }
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
