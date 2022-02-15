using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class transition : MonoBehaviour
{
    //Zakk
    //variabler
    public Image tranim;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2) //Avaktiverar bilden efter en viss tid
        {
            tranim.enabled = false;
        }
    }
}
