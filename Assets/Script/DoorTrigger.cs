using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Kod av Otis
public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private DoorAnimation door;

    // Start is called before the first frame update
    void Start()
    {
        //öppnar alla dörrar
        door.openDoor();
    }

    // Update is called once per frame
    void Update()
    {
        //Öppnar dörrarna om det inte finns några fiender
        if (Spawner.enemyAmmount <= 0)
        {
            door.openDoor();
        }
        //Stänger dörrarna om det finns fiender
        if (Spawner.enemyAmmount > 0)
        {
            door.closeDoor();
        }
    }

}
