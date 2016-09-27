using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Seggu.Helpers
{
    public static class TypeExtensions
    {
        public static IEnumerable<PropertyInfo> GetCollectionProperties(this Type type)
        {
            return type.GetProperties().Where(p => p.IsNonStringEnumerable());
        }

        public static IEnumerable<PropertyInfo> GetNonVirtualProperties(this Type type)
        {
            return type.GetProperties().Where(p => p.GetMethod.IsVirtual);
        }

        public static bool IsNonStringEnumerable(this PropertyInfo pi)
        {
            return pi != null && pi.PropertyType.IsNonStringEnumerable();
        }

        public static bool IsNonStringEnumerable(this Type type)
        {
            if (type == null || type == typeof(string))
                return false;
            return typeof(IEnumerable).IsAssignableFrom(type);
        }
    }
}
