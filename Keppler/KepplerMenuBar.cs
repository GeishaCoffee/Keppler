#region

using Terminal.Gui;

#endregion

namespace Keppler;

public class KepplerMenuBar
{
    public MenuBar Menubar
    {
        get
        {
            return new MenuBar
            {
                Menus = new MenuBarItem[]
                {
                    new MenuBarItem("_File", new MenuItem[]
                    {
                        new MenuItem("_Close", "", () => { Terminal.Gui.Application.RequestStop(); })
                    })
                }
            };
        }
    }
}