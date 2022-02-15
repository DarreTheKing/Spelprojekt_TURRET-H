using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpSlider : MonoBehaviour
{
    //Zakk
    public Slider slider;
    public void SetMaxHealth(float hp) // sliderns max v�rde till spelarens max och nuvarande v�rde till samma som maxv�rdet
    {
        slider.maxValue = hp;
        slider.value = hp;
    }

    public void SetHP(float hp) //s�tter sliderns nuvarande v�rde till detsamma som spelarens nuvarande liv
    {
        slider.value = hp;
    }
}
