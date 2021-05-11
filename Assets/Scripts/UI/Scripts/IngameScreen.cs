using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IngameScreen : ScreenBase
{

    public TextMeshProUGUI coinsText;

    public override void Show()
    {
        base.Show();
        UpdateCoinsText();
        App.player.onCoinsChanged.AddListener(UpdateCoinsText);
    }

    public override void Hide()
    {
        App.player.onCoinsChanged.RemoveListener(UpdateCoinsText);
        base.Hide();
    }

    public void ReturnToMenu()
    {
        Hide();
        App.gameManager.ReturnToMenu();
    }

    public void UpdateCoinsText()
    {
        coinsText.text = "Coins: " + App.player.coinsCollected;
    }
}
