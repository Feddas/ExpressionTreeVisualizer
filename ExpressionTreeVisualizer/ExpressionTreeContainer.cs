namespace ExpressionTreeVisualizer {
    using System;

    [Serializable]
    public class ExpressionTreeContainer {
        public String Expression { get; set; }

        public ExpressionTreeNode TreeNode { get; set; }

        public ExpressionTreeContainer(ExpressionTreeNode treeNode, String expression) {
            this.TreeNode = treeNode;
            this.Expression = expression;
        }
    }
}