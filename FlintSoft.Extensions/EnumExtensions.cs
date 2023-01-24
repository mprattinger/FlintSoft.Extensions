using System.ComponentModel;

namespace FlintSoft.Extensions;

public static class EnumExtensions
{
    public static string GetDescription<T>(this T enumValue) where T : struct
    {
        Type type = enumValue.GetType();
        if (!type.IsEnum)
        {
            throw new ArgumentException("Enumerationvalue must be of type enum!", "enumValue");
        }

        var fi = enumValue.GetType().GetField(enumValue.ToString() ?? "");
        if (fi == null)
        {
            throw new NullReferenceException("Fieldinfo");
        }

        var attributes = (DescriptionAttribute[])fi!.GetCustomAttributes(typeof(DescriptionAttribute), false);

        if (attributes != null && attributes.Length > 0)
        {
            return attributes[0].Description;
        }
        else
        {
            return enumValue.ToString() ?? "";
        }
    }
}
