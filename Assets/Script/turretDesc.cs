using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class turretDesc : MonoBehaviour
{
    public int turrettext=1;
    private Text textdesc;
    // Start is called before the first frame update
    void Start()
    {
        textdesc = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() //gör så att specefika texter vissas beroende på vad för värde turrettext har
    {
        if (turrettext == 1)
        {
            textdesc.text = ("Cannon");
        }
        if (turrettext == 2)
        {
            textdesc.text = ("MiniGun");
        }
    }
}
