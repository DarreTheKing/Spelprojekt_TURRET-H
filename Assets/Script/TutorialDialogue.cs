using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialDialogue : MonoBehaviour
{
    //Zakk men används inte
    public Text texto;
    private float textamount = 0;
    private void Start()
    {
        
        StartCoroutine(Dialogue());
    }

    IEnumerator Dialogue()
    {
        texto.text = ("Hello scavanger, we don't have much time");
        yield return new WaitForSeconds(3f);
        texto.text = ("Quickly pick up those scrap gears");
        yield return new WaitForSeconds(3f);
        texto.text = ("you can place turrets with scrap");
        yield return new WaitForSeconds(3f);
        texto.text = ("you can place them by pressing the space key but...");
        yield return new WaitForSeconds(3f);
        texto.text = ("You should wait with placing your turrets due to the monsters outside");
    }
    
       
            
                
            
        
    
}
