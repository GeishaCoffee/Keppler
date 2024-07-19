namespace Keppler;

public static class TestCaseNodeTreeProvider
{
    public static TestCaseNode Provide()
    {
        TestCaseNode comLevel = new TestCaseNode()
        {
            PackageName = "com",
            IsPackage = true
        };

        TestCaseNode andrasCsanyiLevel = new TestCaseNode()
        {
            PackageName = "andrascsanyi",
            IsPackage = true
        };
        comLevel.Packages.Add(andrasCsanyiLevel);

        TestCaseNode egLevel = new TestCaseNode
        {
            PackageName = "encyclopediagalactica",
            IsPackage = true
        };
        andrasCsanyiLevel.Packages.Add(egLevel);

        TestCaseNode documentLevel = new TestCaseNode
        {
            PackageName = "document",
            IsPackage = true
        };
        egLevel.Packages.Add(documentLevel);

        TestCaseNode e2eLevel = new TestCaseNode
        {
            PackageName = "e2e",
            IsPackage = true
        };
        documentLevel.Packages.Add(e2eLevel);

        TestCaseNode environmentCheckSmokeTest1 = new TestCaseNode()
        {
            TestCaseName = "environmentCheckSmokeTest1",
            PackageName = "e2e",
            ExecutionResult = ExecutionResultEnum.Success
        };
        e2eLevel.TestCases.Add(environmentCheckSmokeTest1);
        TestCaseNode environmentCheckSmokeTest2 = new()
        {
            TestCaseName = "environmentCheckSmokeTest2",
            PackageName = "e2e",
            ExecutionResult = ExecutionResultEnum.Ignored
        };
        e2eLevel.TestCases.Add(environmentCheckSmokeTest2);

        TestCaseNode restLevel = new TestCaseNode
        {
            PackageName = "rest",
            IsPackage = true,
        };
        e2eLevel.Packages.Add(restLevel);

        TestCaseNode documentEndpointLevel = new TestCaseNode
        {
            PackageName = "documentEndpoint",
            IsPackage = true
        };
        restLevel.Packages.Add(documentEndpointLevel);

        TestCaseNode getMethodShouldReturn200 = new TestCaseNode()
        {
            TestCaseName = "getShouldReturn200",
            PackageName = "documentEndpoint",
            ExecutionResult = ExecutionResultEnum.Fail
        };
        documentEndpointLevel.TestCases.Add(getMethodShouldReturn200);
        TestCaseNode postMethodShouldReturn200 = new TestCaseNode()
        {
            TestCaseName = "postMethodShouldReturn200",
            PackageName = "documentEndpoint",
            ExecutionResult = ExecutionResultEnum.Success
        };
        documentEndpointLevel.TestCases.Add(postMethodShouldReturn200);
        TestCaseNode putMethodShouldReturn200 = new TestCaseNode()
        {
            TestCaseName = "putMethodShouldReturn200",
            PackageName = "documentEndpoint",
            ExecutionResult = ExecutionResultEnum.Success
        };
        documentEndpointLevel.TestCases.Add(putMethodShouldReturn200);
        TestCaseNode deleteMethodShouldReturn200 = new TestCaseNode()
        {
            TestCaseName = "deleteMethodShouldReturn200",
            PackageName = "documentEndpoint",
            ExecutionResult = ExecutionResultEnum.Fail
        };
        documentEndpointLevel.TestCases.Add(deleteMethodShouldReturn200);

        return comLevel;
    }
}