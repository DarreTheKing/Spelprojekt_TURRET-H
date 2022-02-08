using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public Image winImage;
    public Image replayImage;
    public Image menuImage;
    public Button replayButton;
    public Button menuButton;
    player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == ("Player"))
        {
            winImage.enabled = true;
            replayButton.enabled = true;
            replayImage.enabled = true;
            menuImage.enabled = true;
            menuButton.enabled = true;

        }
        if(other.gameObject.tag == ("SpawnPoint"))
        {
            Destroy(other.gameObject);
        }
    }

}
