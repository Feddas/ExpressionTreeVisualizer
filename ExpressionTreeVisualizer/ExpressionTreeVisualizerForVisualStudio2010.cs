using System.Diagnostics;
using System.Linq.Expressions;
using ExpressionTreeVisualizer;

//attributes added by: http://sachabarbs.wordpress.com/2012/04/18/expression-tree-visualizer/
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizerForVisualStudio2010), typeof(ExpressionTreeVisualizerObjectSource), 
    Target = typeof(Expression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizerForVisualStudio2010), typeof(ExpressionTreeVisualizerObjectSource), 
    Target = typeof(BinaryExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizerForVisualStudio2010), typeof(ExpressionTreeVisualizerObjectSource), 
    Target = typeof(BlockExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizerForVisualStudio2010), typeof(ExpressionTreeVisualizerObjectSource), 
    Target = typeof(ConditionalExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizerForVisualStudio2010), typeof(ExpressionTreeVisualizerObjectSource), 
    Target = typeof(ConstantExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizerForVisualStudio2010), typeof(ExpressionTreeVisualizerObjectSource), 
    Target = typeof(DebugInfoExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizerForVisualStudio2010), typeof(ExpressionTreeVisualizerObjectSource), 
    Target = typeof(DefaultExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizerForVisualStudio2010), typeof(ExpressionTreeVisualizerObjectSource), 
    Target = typeof(DynamicExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizerForVisualStudio2010), typeof(ExpressionTreeVisualizerObjectSource), 
    Target = typeof(GotoExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizerForVisualStudio2010), typeof(ExpressionTreeVisualizerObjectSource), 
    Target = typeof(IndexExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizerForVisualStudio2010), typeof(ExpressionTreeVisualizerObjectSource), 
    Target = typeof(InvocationExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizerForVisualStudio2010), typeof(ExpressionTreeVisualizerObjectSource), 
    Target = typeof(LabelExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizerForVisualStudio2010), typeof(ExpressionTreeVisualizerObjectSource), 
    Target = typeof(LambdaExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizerForVisualStudio2010), typeof(ExpressionTreeVisualizerObjectSource), 
    Target = typeof(ListInitExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizerForVisualStudio2010), typeof(ExpressionTreeVisualizerObjectSource), 
    Target = typeof(LoopExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizerForVisualStudio2010), typeof(ExpressionTreeVisualizerObjectSource), 
    Target = typeof(MemberExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizerForVisualStudio2010), typeof(ExpressionTreeVisualizerObjectSource), 
    Target = typeof(MemberInitExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizerForVisualStudio2010), typeof(ExpressionTreeVisualizerObjectSource), 
    Target = typeof(MethodCallExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizerForVisualStudio2010), typeof(ExpressionTreeVisualizerObjectSource), 
    Target = typeof(NewArrayExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizerForVisualStudio2010), typeof(ExpressionTreeVisualizerObjectSource), 
    Target = typeof(NewExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizerForVisualStudio2010), typeof(ExpressionTreeVisualizerObjectSource), 
    Target = typeof(ParameterExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizerForVisualStudio2010), typeof(ExpressionTreeVisualizerObjectSource), 
    Target = typeof(RuntimeVariablesExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizerForVisualStudio2010), typeof(ExpressionTreeVisualizerObjectSource), 
    Target = typeof(SwitchExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizerForVisualStudio2010), typeof(ExpressionTreeVisualizerObjectSource), 
    Target = typeof(TryExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizerForVisualStudio2010), typeof(ExpressionTreeVisualizerObjectSource), 
    Target = typeof(TypeBinaryExpression), Description = "Expression Tree Visualizer")]
[assembly: DebuggerVisualizer(typeof(ExpressionTreeVisualizerForVisualStudio2010), typeof(ExpressionTreeVisualizerObjectSource), 
    Target = typeof(UnaryExpression), Description = "Expression Tree Visualizer")]

namespace ExpressionTreeVisualizer {
    using System;
    using Microsoft.VisualStudio.DebuggerVisualizers;

    public class ExpressionTreeVisualizerForVisualStudio2010 : DialogDebuggerVisualizer {
        IDialogVisualizerService modalService;

        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider) {
            modalService = windowService;
            if (modalService == null) {
                throw new NotSupportedException("This debugger does not support modal visualizers");
            }
            
            var container = (ExpressionTreeContainer)objectProvider.GetObject();
            var browser = new TreeBrowser();
            browser.Add(container.TreeNode);
            var treeForm = new TreeWindow(browser, container.Expression);
            modalService.ShowDialog(treeForm);
        }
    }
}