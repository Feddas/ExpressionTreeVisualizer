namespace ExpressionTreeVisualizer {
    using System.Windows.Forms;

    public class TreeBrowser : TreeView {
        public TreeBrowser() {
        }

        public void Add(TreeNode root) {
            Nodes.Add(root);
        }
    }
}