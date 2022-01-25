using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private DoorAnimation door;
    public int doordirection;
    public GameObject doorstop;

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
            GameObject[] destroydoorstop = GameObject.FindGameObjectsWithTag("DoorStop");
            for (int i = 0; i < destroydoorstop.Length; i++)
            {
                Destroy(destroydoorstop[i]);
            }
        }
        if (Spawner.enemyAmmount > 0)
        {
            door.closeDoor();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(doordirection == 1)
        {
            Instantiate(doorstop, transform.position, Quaternion.identity);
        }
        if (doordirection == 2)
        {
            Instantiate(doorstop, transform.position, Quaternion.Euler(0, 0, 90));
        }
    }
}
