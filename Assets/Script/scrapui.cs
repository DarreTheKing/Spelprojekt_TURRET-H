using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrapui : MonoBehaviour
{
    //Zakk
    //variabler
    private Text scraptext;
    public float playerScrap = 0;

    // Start is called before the first frame update
    void Start()
    {
        scraptext = GetComponent<Text>(); //h�mtar en text
    }

    // Update is called once per frame
    void Update()
    {
        scraptext.text = playerScrap.ToString("0"); //skriver �t m�ngden scrap och stoppar den fr�n att vissa decimaler
    }
}

