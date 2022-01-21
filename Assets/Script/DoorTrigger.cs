using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private DoorAnimation door;


    // Start is called before the first frame update
    void Start()
    {
        door.openDoor();
    }

    // Update is called once per frame
    void Update()
    {
        if (Spawner.enemyAmmount <= 0)
        {
            door.openDoor();
        }
        if (Spawner.enemyAmmount > 0)
        {
            door.closeDoor();
        }

    }
}
