using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpUI : MonoBehaviour
{
    //Zakk
    public Text hpText;
    public float hpAmount;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = hpAmount.ToString(); //skriver ut mängden liv spelaren har
    }
}
