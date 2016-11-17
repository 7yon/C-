using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
    public static class Converter
    {
        public static T Convert<T>(string value)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));

            if (value != null)
            {
                return (T)converter.ConvertFrom(value);
            }
            else
                return default(T);
        }
    }
}
