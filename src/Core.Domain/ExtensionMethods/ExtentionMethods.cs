using System;

namespace Core.Domain.ExtensionMethods
{
    public static class ExtentionMethods
    {
        /// <summary>
        /// Extension method to check that an object can be case into a specified type
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <param name="result"></param>
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
