namespace ExpressionTreeVisualizer
{
    using System;
    using System.IO;
    using System.Linq.Expressions;
    using Microsoft.VisualStudio.DebuggerVisualizers;

    public class ExpressionTreeVisualizerObjectSource : VisualizerObjectSource
    {
        public override void GetData(Object target, Stream outgoingData)
        {
            var expr = (Expression)target;
            var browser = new ExpressionTreeNode(expr);
            var container = new ExpressionTreeContainer(browser, expr.ToString());

            Serialize(outgoingData, container);
        }
    }
}