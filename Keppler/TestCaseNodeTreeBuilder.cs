#region

using Terminal.Gui;

#endregion

namespace Keppler;

public class TestCaseNodeTreeBuilder : ITreeBuilder<TestCaseNode>
{
    public bool CanExpand(TestCaseNode node)
    {
        return node.IsPackage;
    }

    public IEnumerable<TestCaseNode> GetChildren(TestCaseNode node)
    {
        List<TestCaseNode> result = new List<TestCaseNode>();
        if (node.IsPackage)
        {
            if (node.TestCases.Any())
            {
                result.AddRange(node.TestCases);
            }

            result.AddRange(node.Packages);
        }

        return result;
    }

    public bool SupportsCanExpand => true;
}