using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
    public static class Converter
    {
        public static object Convert(Type type, string value)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(type);
            return converter.ConvertFrom(null, CultureInfo.InvariantCulture, value);
        }
    }
}
