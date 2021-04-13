using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameScreen : ScreenBase
{

    public void ReturnToMenu()
    {
        App.gameManager.ReturnToMenu();
        Hide();
    }

}
