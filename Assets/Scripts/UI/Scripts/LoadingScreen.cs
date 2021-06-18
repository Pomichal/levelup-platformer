using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{

    public Animator anim;
    public Slider slider;

    public void LoadingFinished()
    {
        anim.SetTrigger("LoadingFinished");
    }

    public void StartLoading()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void SetSlider(float value)
    {
        slider.value = value;
    }
}
