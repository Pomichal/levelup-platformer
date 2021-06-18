using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingPanel : MonoBehaviour
{
    public void HideLoadingScreen()
    {
        App.gameManager.loadingScreen.Hide();
    }
}
