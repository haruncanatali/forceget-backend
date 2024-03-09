using System.ComponentModel;
using System.Reflection;

namespace FORCEGET.Application.Common.Helpers;

public static class EnumExtentions
{
    public static string GetDescription<T>(this T source)
    { 
        try
        {
            if(source == null) return string.Empty;
            FieldInfo fi = source.GetType().GetField(source.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);
            if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }
        catch
        {
            return string.Empty;
        }
    }
}