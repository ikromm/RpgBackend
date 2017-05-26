using UnityEngine;
using System.Collections;
using ikromm.Ui;

public class MenuManager : UnitySingleton<MenuManager>
{
    public MenuBehaviour LandingMenu;
    
    private MenuBehaviour currentMenu;
    public MenuBehaviour CurrentMenu { get { return currentMenu; } }

    private Dialog currentDialog;

    public bool DialogOpen { get { return currentDialog != null; } }

    public void Start()
    {
        System.Array.ForEach(FindObjectsOfType<MenuBehaviour>(), x => x.IsOpen = false);

        if (LandingMenu != null)
            ShowMenu(LandingMenu);
    }

    public void ShowMenu(MenuBehaviour menu)
    {
        if (currentMenu != null)
            currentMenu.IsOpen = false;

        currentMenu = menu;
        currentMenu.IsOpen = true;
    }

    public void ShowDialog(Dialog dialog)
    {
        if (DialogOpen)
            currentDialog.IsOpen = false;

        currentDialog = dialog;
        currentDialog.IsOpen = true;
    }

    public void CloseDialog()
    {
        if (DialogOpen)
        {
            currentDialog.IsOpen = false;
            currentDialog = null;
        }
    }

    public void CloseApp()
    {
        Application.Quit();
    }

}
