using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
    public static class Program
    {     
        static IEnumerable<string[]> ReadCsv1()
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
                    for(int i=0; i < values.Length; i++)
                    {
                        if (values[i] == "NA")
                            values[i] = null;
                    }
                    yield return values;
                }
        }

        static IEnumerable<T> ReadCsv2<T>() where T : new()
        {
            bool firstString = true;
            List<string> fields = null;

            foreach (string[] values in ReadCsv1())
            {
                if (firstString)
                {
                    fields = new List<string>(values);
                    firstString = false;
                }
                else
                {                                                      
                    T myObject = new T();
                    Type myObjectType = typeof(T);
                    PropertyInfo[] properties = myObjectType.GetProperties();

                    for (int i = 0; i < properties.Length; i++)
                    {
                        string currentProperty = properties[i].Name;

                        int index;
                        for (index = 0; index < fields.Count; index++)
                        {
                            if (fields[index] == currentProperty)
                                break;
                        }
         
                        if ((values[index] == null) && ((properties[i].PropertyType == typeof(int)) || (properties[i].GetType() == typeof(double))))
                        {
                            throw new ArgumentException("Поле " + fields[i] + " не может быть null!");
                        }
                        else
                        {
                            Type currentType = properties[i].PropertyType;

                            var currentValue = Converter.SimpleConvert(currentType, values[index]);

                            myObjectType.GetProperty(currentProperty).SetValue(myObject, currentValue);
                        }
                    }
                    yield return myObject;                                      
                }                            
            }
        }

        static IEnumerable<Dictionary<string, object>> ReadCsv3()
        {
            bool firstString = true;

            Type[] types = new Type[] {typeof(string), typeof(int?), typeof(int?), typeof(double), typeof(int), typeof(int), typeof(int) };
            string[] columnsName = null;

            foreach (string[] values in ReadCsv1())
            {
                if (firstString)
                {
                    firstString = false;
                    columnsName = values.ToArray();
                }
                else
                {                 
                    Dictionary<string, object> myDictionary = new Dictionary<string, object>();

                    for (int i = 0; i < values.Length; i++)
                    {
                        try
                        {
                            var value = TypeDescriptor.GetConverter(types[i]).ConvertFrom(values[i].Replace('.', ','));
                            myDictionary.Add(columnsName[i], value);
                        }
                        catch (Exception e)
                        {
                            throw new ArgumentException("Поле " + columnsName[i] + " не может быть null!");
                        }
                    }
                    yield return myDictionary;                   
                }
            }
        }

        static void Main(string[] args)
        {
            //foreach (var value in ReadCsv1())
            //{
            //    Console.WriteLine(value);
            //}
                
            foreach (var value in ReadCsv2<MyObject>())
            {
            }
        }
    }
}
