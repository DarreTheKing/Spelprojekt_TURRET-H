using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject closedRoom;

    public List<GameObject> rooms;
    public float waitTime;
    private bool spawnedWin;
    public GameObject win;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(waitTime <= 0 && spawnedWin == false)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if(i == rooms.Count - 1)
                {
                    Instantiate(win, rooms[i].transform.position, Quaternion.identity);
                    spawnedWin = true;
                }
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}