using System;

[assembly: CLSCompliant(true)]

namespace ExpressionTreeVisualizer {
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;

    internal static class ExpressionTreeExtention {
        public static String ObtainOriginalMethodName(this MethodInfo method) {
            if (!method.IsGenericMethod) {
                return method.Name;
            }
            return ExtractName(method.Name) + ExtractGenericArguments(method.GetGenericArguments());
        }

        public static String ObtainOriginalName(this Type type) {
            if (!type.IsGenericType) {
                return type.Name;
            }
            return ExtractName(type.Name) + ExtractGenericArguments(type.GetGenericArguments());
        }

        static String ExtractGenericArguments(IEnumerable<Type> names) {
            var builder = new StringBuilder("<");
            foreach (Type genericArgument in names) {
                if (builder.Length != 1) {
                    builder.Append(", ");
                }
                builder.Append(ObtainOriginalName(genericArgument));
            }
            builder.Append(">");
            return builder.ToString();
        }

        static String ExtractName(String name) {
            Int32 i = name.LastIndexOf("`", StringComparison.Ordinal);
            if (i > 0) {
                name = name.Substring(0, i);
            }
            return name;
        }
    }
}