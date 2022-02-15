using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Kod av Otis
public class Lose : MonoBehaviour
{
    //Variabler för förlust
    public Image loseImage;
    public Image replayImage;
    public Image menuImage;
    public Button replayButton;
    public Button menuButton;
    public Text menuText;
    public Text replayText;
    //Referens till spelaren
    player player;
    // Start is called before the first frame update
    void Start()
    {
        //Hittar spelaren
        player = GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {
        //Kollar om spelaren är död
        if(player.health <= 0)
        {
            //Visar loseskärmen om man dör
            loseImage.enabled = true;
            replayButton.enabled = true;
            replayImage.enabled = true;
            replayText.enabled = true;
            menuImage.enabled = true;
            menuButton.enabled = true;
            menuText.enabled = true;
        }
    }
}
