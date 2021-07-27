using System.Linq;
using System.Reflection;


namespace ValidationAttributes
{
    public static class Validator 
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();

            foreach (var prop in properties)
            {
                var propAttributes = prop.GetCustomAttributes()
                    .Where(a => a is MyValidationAttribute)
                    .Cast<MyValidationAttribute>();

                foreach (var attr in propAttributes)
                {
                    bool result = attr.IsValid(prop.GetValue(obj));

                    if (!result)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
