#region

using Terminal.Gui;
using Attribute = Terminal.Gui.Attribute;

#endregion

namespace Keppler;

public class KepplerTopLevel : Toplevel
{
    private Window MainWindow;
    private TreeView<TestCaseNode> TestCaseTreeView;
    private TestCaseNode TestCaseTreeViewData = new TestCaseNode();

    public KepplerTopLevel()
    {
        MenuBar = CreateMenuBar();

        MainWindow = CreateMainWindow();

        TestCaseTreeViewData = TestCaseNodeTreeProvider.Provide();
        TestCaseTreeView = CreateTestCaseTreeView();
        MainWindow.Add(TestCaseTreeView);

        Add(MainWindow);
    }

    private Window CreateMainWindow()
    {
        return new Window
        {
            X = 0,
            Y = 0,
            Width = Dim.Fill(),
            Height = Dim.Fill(),
            BorderStyle = LineStyle.Double,
            Title = "Test cases"
        };
    }

    private TreeView<TestCaseNode>? CreateTestCaseTreeView()
    {
        TreeView<TestCaseNode> tv = new TreeView<TestCaseNode>
        {
            X = 0,
            Y = 0,
            Width = Dim.Fill(),
            Height = Dim.Fill(),
            Title = "Test cases - Tree",
            BorderStyle = LineStyle.Rounded,
            SuperViewRendersLineCanvas = true,
            TreeBuilder = new TestCaseNodeTreeBuilder()
        };
        tv.ColorGetter += (node) =>
        {
            if (node.ExecutionResult == ExecutionResultEnum.Fail)
            {
                return new ColorScheme
                {
                    Normal = new Attribute(Color.Red, Color.Blue),
                    Focus = new Attribute(Color.BrightRed, Color.Blue)
                };
            }

            if (node.ExecutionResult == ExecutionResultEnum.Ignored)
            {
                return new ColorScheme
                {
                    Normal = new Attribute(Color.Gray, Color.Blue),
                    Focus = new Attribute(Color.DarkGray, ColorName.Blue)
                };
            }

            if (node.ExecutionResult == ExecutionResultEnum.Success)
            {
                return new ColorScheme
                {
                    Normal = new Attribute(Color.Green, ColorName.Blue),
                    Focus = new Attribute(Color.BrightGreen, ColorName.Blue)
                };
            }

            return new ColorScheme
            {
                Normal = new Attribute(Color.White, ColorName.Blue),
                Focus = new Attribute(Color.BrightBlue, ColorName.Blue),
            };
        };
        tv.ObjectActivationKey = KeyCode.Enter;
        tv.ObjectActivated += (sender, args) =>
        {
            Button dialogButton = new Button { Title = "_OK" };
            dialogButton.ProcessKeyDown += (o, key) =>
            {
                if (key == Key.Enter)
                {
                    Terminal.Gui.Application.RequestStop();
                }
            };
            Dialog dialog = new Dialog
            {
                Title = "Object activated dialog"
            };
            dialog.AddButton(dialogButton);
            Terminal.Gui.Application.Run(dialog);
        };
        tv.ProcessKeyDown += (sender, key) =>
        {
            if (key == Key.A)
            {
                Button keyAButton = new Button { Text = "_Ok" };
                keyAButton.ProcessKeyDown += (o, keyAButtonEvent) =>
                {
                    if (keyAButtonEvent == Key.Enter)
                    {
                        Terminal.Gui.Application.RequestStop();
                    }
                };
                Dialog keyAdialog = new Dialog
                {
                    Title = "Key A dialog"
                };
                keyAdialog.AddButton(keyAButton);
                Terminal.Gui.Application.Run(keyAdialog);
            }

            if (key == Key.B)
            {
                Button keyBButton = new Button { Text = "_Ok" };
                keyBButton.ProcessKeyDown += (o, keyBButtonEvent) =>
                {
                    if (keyBButtonEvent == Key.Enter)
                    {
                        Terminal.Gui.Application.RequestStop();
                    }
                };
                Dialog keyBBDialog = new Dialog
                {
                    Title = "Key B dialog"
                };
                keyBBDialog.AddButton(keyBButton);
                Terminal.Gui.Application.Run(keyBBDialog);
            }
        };
        tv.AddObject(TestCaseTreeViewData);
        return tv;
    }

    private MenuBar CreateMenuBar()
    {
        return new MenuBar
        {
            Menus = new[]
            {
                new MenuBarItem("File",
                    new MenuItem[]
                    {
                        new MenuItem("_Quit", "Quit application", RequestStop)
                    }),
                new MenuBarItem("Settings",
                    new[]
                    {
                        new MenuItem("Settings", "Settings", () => { }),
                        new MenuItem("Dummy", "Dummy", () => { }),
                    })
            }
        };
    }
}