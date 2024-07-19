#region

using Terminal.Gui;
using Attribute = Terminal.Gui.Attribute;

#endregion

namespace Keppler;

internal class KepplerApp
{
    private MenuBar KepplerMenuBar;
    private Window TestCaseWindow;

    public KepplerApp(Toplevel toplevel)
    {
        KepplerMenuBar = new KepplerMenuBar().Menubar;
        TestCaseWindow = BuildTestCaseWindow();

        Console.WriteLine("Kepplermenubar " + KepplerMenuBar);
        Console.WriteLine("testcase window" + TestCaseWindow);
        toplevel.Add(KepplerMenuBar, TestCaseWindow);
    }

    private static int Main(string[] args)
    {
        KepplerTopLevel();
        return 0;
    }

    private static void KepplerTopLevel()
    {
        Terminal.Gui.Application.Init();
        Terminal.Gui.Application.Run<KepplerTopLevel>().Dispose();
        Terminal.Gui.Application.Shutdown();
        VerifyObjectsWereDisposed();
    }

    private static void VerifyObjectsWereDisposed()
    {
#if DEBUG_IDISPOSABLE
        foreach (Responder? inst in Responder.Instances)
        {
            Debug.Assert(inst.WasDisposed);
        }

        Responder.Instances.Clear();

        foreach (RunState? inst in RunState.Instances)
        {
            Debug.Assert (inst.WasDisposed);
        }

        RunState.Instances.Clear ();

#endif
    }

    private Window BuildTestCaseWindow()
    {
        Window testCaseWindow = new Window()
        {
            X = 0,
            Y = 0,
            Width = Dim.Fill(),
            Height = Dim.Fill() - 1
        };
        testCaseWindow.Title = "Test cases";
        TreeView<TestCaseNode> testCaseTreeView = BuildTestCaseTree();
        testCaseWindow.Add(testCaseTreeView);
        return testCaseWindow;
    }

    private TreeView<TestCaseNode> BuildTestCaseTree()
    {
        TestCaseTreeView testCaseTreeView = new TestCaseTreeView
        {
            X = 0,
            Y = 0,
            Width = Dim.Fill(),
            Height = Dim.Fill() - 1,
            TreeBuilder = new TestCaseNodeTreeBuilder()
        };
        testCaseTreeView.MultiSelect = false;
        testCaseTreeView.KeyBindings.Add(Key.T, Command.Accept);
        // testCaseTreeView.KeyDown += (keyDownEvent) =>
        // {
        // if (keyDownEvent.KeyEvent.Key == Key.Space)
        // {
        // try
        // {
        // Button okButton = new Button("Ok");
        // okButton.Clicked += () => { Application.RequestStop(); };
        // Dialog testCaseDialog = new Dialog(
        // "Test case name should come here",
        // testCaseNode.ActivatedObject.Name,
        // 50,
        // 50,
        // okButton);
        // Application.Run(testCaseDialog);
        // }
        // catch (Exception e)
        // {
        // Console.WriteLine(e);
        // throw;
        // }
        // }

        // if (keyDownEvent.KeyEvent.Key == Key.a)
        // {
        // }
        // };
        testCaseTreeView.ColorGetter += (node) =>
        {
            if (node.ExecutionResult == ExecutionResultEnum.Fail)
            {
                return new ColorScheme
                {
                    Normal = new Attribute(default, Color.Red),
                    Focus = new Attribute(default, Color.BrightRed)
                };
            }

            if (node.ExecutionResult == ExecutionResultEnum.Ignored)
            {
                return new ColorScheme
                {
                    Normal = new Attribute(default, Color.Gray),
                    Focus = new Attribute(default, Color.DarkGray)
                };
            }

            if (node.ExecutionResult == ExecutionResultEnum.Success)
            {
                return new ColorScheme
                {
                    Normal = new Attribute(default, Color.Green),
                    Focus = new Attribute(default, Color.BrightGreen)
                };
            }

            return null;
        };
        // testCaseTreeView.ObjectActivationKey = Key.Enter;
        // testCaseTreeView.ObjectActivated += (testCaseNode) =>
        // {
        // try
        // {
        // Button okButton = new Button("Ok");
        // okButton.Clicked += () => { Application.RequestStop(); };
        // Dialog testCaseDialog = new Dialog(testCaseNode.ActivatedObject.Name,
        // 50,
        // 50,
        // okButton);
        // Application.Run(testCaseDialog);
        // }
        // catch (Exception e)
        // {
        // Console.WriteLine(e);
        // throw;
        // }
        // };
        return testCaseTreeView;
    }
}