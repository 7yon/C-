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

        static object ConvertToObject(Type type, string value)
        {
            object currentValue = null;

            if (value != null)
            {
                if (type == typeof(int) || (type == typeof(int?)))
                    currentValue = Convert.ToInt32(value);
                if (type == typeof(double) || (type == typeof(double?)))
                    currentValue = Convert.ToDouble(value.Replace('.', ','));
                if (type == typeof(string))
                    currentValue = value;
            }
            return currentValue;
        }

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
            List<string> fields = null;
            List<string> currentString = new List<string>();

            int column = 0;
            foreach (string value in ReadCsv1())
            {
                if (currentString.Count != 7)
                {
                    currentString.Add(value);
                    column++;                 
                }
                else
                {
                    column = 0;

                    if (firstString)
                    {
                        fields = new List<string>(currentString);
                        firstString = false;

                        currentString.Clear();
                        currentString.Add(value);                    
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
         
                            if ((currentString[index] == null) && ((properties[i].PropertyType == typeof(int)) || (properties[i].GetType() == typeof(double))))
                            {
                                throw new ArgumentException("Поле " + fields[i] + " не может быть null!");
                            }
                            else
                            {
                                object currentValue = null;
                                Type currentType = properties[i].PropertyType;

                                currentValue = ConvertToObject(currentType, currentString[i]);

                                myObjectType.GetProperty(currentProperty).SetValue(myObject, currentValue);
                            }
                        }
                        currentString.Clear();
                        currentString.Add(value);
                        yield return myObject;
                    }                    
                }                            
            }
        }

        static IEnumerable<Dictionary<string, object>> ReadCsv3()
        {
            bool firstString = true;
            List<string> fields = null;
            List<string> currentString = new List<string>();

            int column = 0;
            foreach (string value in ReadCsv1())
            {
                if (currentString.Count != 7)
                {
                    currentString.Add(value);
                    column++;
                }
                else
                {
                    column = 0;

                    if (firstString)
                    {
                        fields = new List<string>(currentString);
                        firstString = false;

                        currentString.Clear();
                        currentString.Add(value);
                    }
                    else
                    {
                        Dictionary<string, object> myDictionary = new Dictionary<string, object>();

                        MyObject myObject = new MyObject();
                        Type myObjectType = typeof(MyObject);
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

                            if ((currentString[index] == null) && ((properties[i].PropertyType == typeof(int)) || (properties[i].GetType() == typeof(double))))
                            {
                                throw new ArgumentException("Поле " + fields[i] + " не может быть null!");
                            }
                            else
                            {
                                object currentValue = null;
                                Type currentType = properties[i].PropertyType;

                                currentValue = ConvertToObject(currentType, currentString[i]);
                                
                                myDictionary.Add(currentProperty, currentValue);
                            }
                        }
                        currentString.Clear();
                        currentString.Add(value);
                        yield return myDictionary;
                    }
                }
            }
        }

        static IEnumerable<LinkedList<MyObject>> ReadCsv4(string filename)
        {
            bool firstString = true;
            string[] fields = null;

            using (var reader = new StreamReader(File.OpenRead(filename)))

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
                        LinkedList<MyObject> myDictionary = new LinkedList<MyObject>();

                        MyObject myObject = new MyObject();
                        Type myObjectType = typeof(MyObject);

                        for (int i = 0; i < values.Length; i++)
                        {
                            PropertyInfo currentInfo = myObjectType.GetProperty(fields[i]);

                            if ((values[i] == "NA") && ((fields[i] == "Name") || (fields[i] == "Wind") || (fields[i] == "Temp") || (fields[i] == "Month") || (fields[i] == "Day")))
                            {
                                throw new ArgumentException("Поле " + fields[i] + " не может быть null!");
                            }
                            else
                            {
                                object currentValue = null;
                                Type currentType = currentInfo.PropertyType;

                                currentValue = ConvertToObject(currentType, values[i]);

                                //myDictionary.Add(fields[i], currentValue);
                            }
                        }
                        yield return myDictionary;
                    }
                }
        }

        static void Main(string[] args)
        {
            //foreach (var value in ReadCsv1())
                //Console.WriteLine(value);
            foreach (var value in ReadCsv3()) { }
                //Console.WriteLine(value.Name);

        }
    }
}
