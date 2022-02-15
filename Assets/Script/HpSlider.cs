using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpSlider : MonoBehaviour
{
    //Zakk
    public Slider slider;
    public void SetMaxHealth(float hp) // sliderns max värde till spelarens max och nuvarande värde till samma som maxvärdet
    {
        slider.maxValue = hp;
        slider.value = hp;
    }

    public void SetHP(float hp) //sätter sliderns nuvarande värde till detsamma som spelarens nuvarande liv
    {
        slider.value = hp;
    }
}
