namespace ExpressionTreeVisualizer {
    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.Serialization;
    using System.Windows.Forms;

    [Serializable]
    public class ExpressionTreeNode : TreeNode {
        protected ExpressionTreeNode(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }

        public ExpressionTreeNode(Object value) {
            Type type = value.GetType();
            Text = type.ObtainOriginalName();

            if (value is Expression) {
                ImageIndex = 2;
                SelectedImageIndex = 2;

                PropertyInfo[] propertyInfos = null;
                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Expression<>)) {
                    if (type.BaseType != null) {
                        propertyInfos = type.BaseType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    }
                } else {
                    propertyInfos = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                }

                if (propertyInfos != null) {
                    foreach (PropertyInfo propertyInfo in propertyInfos) {
                        if ((propertyInfo.Name != "nodeType")) {
                            Nodes.Add(new AttributeNode(value, propertyInfo));
                        }
                    }
                }
            } else {
                ImageIndex = 4;
                SelectedImageIndex = 4;
                Text = "\"" + value + "\"";
            }
        }
    }
}