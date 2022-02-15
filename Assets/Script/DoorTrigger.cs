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
        //�ppnar alla d�rrar
        door.openDoor();
    }

    // Update is called once per frame
    void Update()
    {
        //�ppnar d�rrarna om det inte finns n�gra fiender
        if (Spawner.enemyAmmount <= 0)
        {
            door.openDoor();
        }
        //St�nger d�rrarna om det finns fiender
        if (Spawner.enemyAmmount > 0)
        {
            door.closeDoor();
        }
    }

}
