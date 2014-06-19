namespace ExpressionTreeVisualizer {
    using System;
    using System.Collections;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.Serialization;
    using System.Windows.Forms;

    [Serializable]
    public class AttributeNode : TreeNode {
        protected AttributeNode(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }

        public AttributeNode(Object attribute, PropertyInfo propertyInfo) {
            Text = propertyInfo.Name + " : " + propertyInfo.PropertyType.ObtainOriginalName();
            ImageIndex = 3;
            SelectedImageIndex = 3;

            Object value = propertyInfo.GetValue(attribute, null);
            if (value != null) {
                if (value.GetType().IsGenericType && value.GetType().GetGenericTypeDefinition() == typeof(ReadOnlyCollection<>)) {
                    if ((Int32)value.GetType().InvokeMember("get_Count", BindingFlags.InvokeMethod, null, value, null, CultureInfo.InvariantCulture) == 0) {
                        Text += " : Empty";
                    } else {
                        foreach (Object tree in (IEnumerable)value) {
                            if (tree is Expression) {
                                Nodes.Add(new ExpressionTreeNode(tree));
                            } else if (tree is MemberAssignment) {
                                Nodes.Add(new ExpressionTreeNode(((MemberAssignment)tree).Expression));
                            }
                        }
                    }
                } else if (value is Expression) {
                    Text += ((Expression)value).NodeType;
                    Nodes.Add(new ExpressionTreeNode(value));
                } else if (value is MethodInfo) {
                    var minfo = value as MethodInfo;
                    Text += " : \"" + minfo.ObtainOriginalMethodName() + "\"";
                } else if (value is Type) {
                    var type = value as Type;
                    Text += " : \"" + type.ObtainOriginalName() + "\"";
                } else {
                    Text += " : \"" + value + "\"";
                }
            } else {
                Text += " : null";
            }
        }
    }
}