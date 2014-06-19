namespace ExpressionTreeVisualizer {
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class TreeWindow : Form {
        readonly TreeBrowser _browser;
        readonly string _errors;
        TextBox _errorMessageBox;

        public TreeWindow(TreeBrowser browser, String expression) {
            this._browser = browser;
            this._errors = expression;
            InitializeComponent();
        }

        void InitializeComponent() {
            this._errorMessageBox = new TextBox();

            this.SuspendLayout();

            // 
            // errorMessageBox
            // 
            this._errorMessageBox.Anchor = ((AnchorStyles.Top | AnchorStyles.Left)
                                           | AnchorStyles.Right);
            this._errorMessageBox.Location = new Point(8, 8);
            this._errorMessageBox.Multiline = true;
            this._errorMessageBox.Name = "_errorMessageBox";
            this._errorMessageBox.ReadOnly = true;
            this._errorMessageBox.ScrollBars = ScrollBars.Both;
            this._errorMessageBox.Size = new Size(280, 56);
            this._errorMessageBox.TabIndex = 1;
            this._errorMessageBox.TabStop = false;
            this._errorMessageBox.Text = this._errors;

            // 
            // browser
            // 
            this._browser.Anchor = (((AnchorStyles.Top | AnchorStyles.Bottom)
                                     | AnchorStyles.Left)
                                    | AnchorStyles.Right);
            this._browser.Location = new Point(8, 72);
            this._browser.Size = new Size(280, 192);
            this._browser.TabIndex = 2;
            this._browser.ExpandAll();

            // 
            // TreeWindow
            // 
            this.AutoScaleBaseSize = new Size(5, 13);
            this.ClientSize = new Size(292, 266);
            this.Controls.AddRange(
                new Control[] {
                                  this._browser,
                                  this._errorMessageBox
                              });
            this.Name = "TreeWindow";
            this.Text = "Expression Tree Viewer";
            this.ResumeLayout(false);

            this.Size = new Size(600, 800);
        }
    }
}