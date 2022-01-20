using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lose : MonoBehaviour
{
    public Image loseImage;
    public Image replayImage;
    public Image menuImage;
    public Button replayButton;
    public Button menuButton;
    public Text menuText;
    public Text replayText;
    player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.health <= 0)
        {
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
