using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Globalization;
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
            bool firstString = true;
            using (var reader = new StreamReader(File.OpenRead("D:\\C_Sharp\\Files\\Files\\airquality.csv")))
                while (true)
                {
                    var str = reader.ReadLine();
                    if (str == null)
                    {
                        yield break;
                    }

                    var values = str.Split(',');                   

                    for (int i=0; i < values.Length; i++)
                    {
                        values[i] = values[i].Trim('"');

                        if (firstString)
                        {
                            values[i] = values[i].Replace(".", "");                            
                        }
                        
                        if (values[i] == "NA")
                            values[i] = null;
                    }
                    firstString = false;

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
                            var currentValue = Converter.Convert(currentType, values[index]);

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
            string[] columnsName = null;

            Type[] types = new Type[] { typeof(double), typeof(int), typeof(string)};            

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
                            if (((columnsName[i] != "Ozone") && (columnsName[i] != "SolarR")) && (values[i] == null))
                                throw new Exception();

                            object value = null;

                            if (values[i] != null)
                            {
                                for (int j = 0; j < types.Length; j++)
                                {
                                    try
                                    {
                                        value = Converter.Convert(types[j], values[i]);
                                        break;
                                    }
                                    catch (Exception e) { }                                   
                                }  

                                char a = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

                                if ((!value.ToString().Contains(a)) && (value.GetType() == typeof(double)))
                                    myDictionary.Add(columnsName[i], Convert.ToInt32(value));
                                else
                                    myDictionary.Add(columnsName[i], value);                                                                                                
                            }
                            else
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

        static List<dynamic> ReadCsv4()
        {
            Type[] types = new Type[] { typeof(double), typeof(int), typeof(string) };
            List<dynamic> list = new List<dynamic>();

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
                    dynamic myObject = new ExpandoObject();
                    for (int i = 0; i < values.Length; i++)
                    {
                        try
                        {
                            if (((fields[i] != "Ozone") && (fields[i] != "SolarR")) && (values[i] == null))
                                throw new Exception();

                            object value = null;

                            if (values[i] != null)
                            {
                                for (int j = 0; j < types.Length; j++)
                                {
                                    try
                                    {
                                        value = Converter.Convert(types[j], values[i]);
                                        break;
                                    }
                                    catch (Exception e)
                                    {

                                    }
                                }
                                char a = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

                                if ((!value.ToString().Contains(a)) && (value.GetType() == typeof(double)))
                                    ((IDictionary<string, object>)myObject).Add(fields[i], Convert.ToInt32(value));
                                else
                                    ((IDictionary<string, object>)myObject).Add(fields[i], value);
                            }
                            else
                                ((IDictionary<string, object>)myObject).Add(fields[i], value);
                        }
                        catch (Exception e)
                        {
                            throw new ArgumentException("Поле " + fields[i] + " не может быть null!");
                        }
                    }
                    list.Add(myObject);                                     
                }
            }
            return list;
        }

        static void Main(string[] args)
        {
            foreach (var value in ReadCsv1())
            {
                Console.WriteLine(value);
            }
                
            foreach (var value in ReadCsv3())
            {
            }

            var list = ReadCsv4().Where(z => z.Ozone > 10).Select(z => z.Wind);
        }
    }
}
