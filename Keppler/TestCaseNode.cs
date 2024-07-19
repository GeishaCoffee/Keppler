namespace Keppler;

public class TestCaseNode
{
    public string TestCaseName { get; set; }
    public string PackageName { get; set; }
    public ExecutionResultEnum ExecutionResult { get; set; } = ExecutionResultEnum.None;

    /// <summary>
    ///     Test cases belong to the package.
    /// </summary>
    public List<TestCaseNode> TestCases { get; set; } = new List<TestCaseNode>();

    /// <summary>
    ///     Packages under the given package.
    /// </summary>
    public List<TestCaseNode> Packages { get; set; } = new List<TestCaseNode>();

    public bool IsPackage { get; set; }

    public override string ToString()
    {
        return IsPackage ? PackageName : TestCaseName;
    }
}