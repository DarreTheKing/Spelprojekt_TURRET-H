using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialDialogue : MonoBehaviour
{
    public Text texto;
    private float textamount = 0;
    private void Start()
    {
        texto.text = ("Hello scavanger, we don't have much time");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && textamount == 0)
        {
            texto.text = ("Quickly pick up those scrap gears");
            textamount = 1;
            if (Input.GetKeyDown(KeyCode.Mouse0) && textamount == 1)
            {
                texto.text = ("you can place turrets with scrap");
                textamount = 2;
                if (Input.GetKeyDown(KeyCode.Mouse0) && textamount == 2)
                {
                    texto.text = ("you can place them by pressing the space key but");
                }
            }
        }
    }
}
