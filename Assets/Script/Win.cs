using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Kod av Otis
public class Win : MonoBehaviour
{
    //Sparar bilder för win skärmen
    public Image winImage;
    public Image replayImage;
    public Image menuImage;
    public Button replayButton;
    public Button menuButton;
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Gör att winmenyn kommer upp om man tar sig till det rummet
        if(other.gameObject.tag == ("Player"))
        {
            winImage.enabled = true;
            replayButton.enabled = true;
            replayImage.enabled = true;
            menuImage.enabled = true;
            menuButton.enabled = true;

        }
        //Gör så att fiender inte kan spawna i winrummet
        if(other.gameObject.tag == ("SpawnPoint"))
        {
            Destroy(other.gameObject);
        }
    }

}
