using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private DoorAnimation door;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {

            door.openDoor();
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        this.door.closeDoor();
    }
}
