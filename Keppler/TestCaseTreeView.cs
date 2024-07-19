#region

using Terminal.Gui;

#endregion

namespace Keppler;

public class TestCaseTreeView : TreeView<TestCaseNode>
{
    public TestCaseTreeView()
    {
        KeyBindings.Add(Key.A, Command.Left);
        KeyBindings.Add(Key.B, Command.Right);
        AddCommand(Command.Left, () =>
        {
            Button okButton = new Button
            {
                Title = "_Ok"
            };
            okButton.Accept += (sender, args) => Terminal.Gui.Application.RequestStop();
            Dialog dialog = new Dialog
            {
                Title = "Key A pressed dialog",
            };
            dialog.AddButton(okButton);
            return true;
        });
        AddCommand(Command.Right, () =>
        {
            Button okButton = new Button
            {
                Title = "_Ok"
            };
            okButton.Accept += (sender, args) => Terminal.Gui.Application.RequestStop();
            Dialog dialog = new Dialog
            {
                Title = "Key B pressed dialog",
            };
            dialog.AddButton(okButton);
            return true;
        });
    }
}