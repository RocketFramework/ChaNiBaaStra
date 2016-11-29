using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ChaNiBaaStra.Utilities
{
    public static class EnumToList
    {
        public static List<string> GetListOfDescription<T>() where T : struct
        {
            List<String> returnArray = new List<string>();
            Type t = typeof(T);
            IEnumerable<Enum> result = !t.IsEnum ? null : Enum.GetValues(t).Cast<Enum>();
            foreach (Enum item in result)
                returnArray.Add(item.ToString());
            return returnArray;
        }

        public static string GetDescription(this Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    DescriptionAttribute attr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return name;
        }
    }
}
