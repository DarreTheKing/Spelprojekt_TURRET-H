using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpSlider : MonoBehaviour
{
    public Slider slider;
    public void SetMaxHealth(float hp)
    {
        slider.maxValue = hp;
        slider.value = hp;
    }

    public void SetHP(float hp)
    {
        slider.value = hp;
    }
}
