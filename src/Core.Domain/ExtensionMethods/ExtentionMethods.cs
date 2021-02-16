using System;

namespace Core.Domain.ExtensionMethods
{
    public static class ExtentionMethods
    {
        /// <summary>
        /// Extension method to check that an object can be converted into a specified type
        /// </summary>
        /// <param name="obj">The object to be converted</param>
        /// <param name="type">The type to convert the object into</param>
        /// <param name="result">The converted object if the conversion is successful</param>
        /// <returns></returns>
        public static bool TryCast(this string obj, Type type, out object result)
        {
            result = default;
            try
            {
                if (string.IsNullOrEmpty(obj))
                    return false;

                result = Convert.ChangeType(obj, type);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
