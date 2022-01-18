using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpUI : MonoBehaviour
{
    private Text hpText;
    public float hpAmount = 100;

    // Start is called before the first frame update
    void Start()
    {
        hpText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = hpAmount.ToString();
    }
}
