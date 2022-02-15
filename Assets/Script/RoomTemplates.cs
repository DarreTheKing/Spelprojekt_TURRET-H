using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Kod av Otis
public class RoomTemplates : MonoBehaviour
{
    //Skapar variablar för olika gameobject åt olika håll
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;
    public GameObject closedRoom;
    public GameObject leftStart;
    public GameObject rightStart;
    public GameObject upStart;
    public GameObject downStart;

    //Skapar en lista för alla skapade rum
    public List<GameObject> rooms;
    //Väntar med att skapa win
    public float waitTime;
    //Kollar om win har spawnat
    private bool spawnedWin;
    //Variabel för win
    public GameObject win;


    // Update is called once per frame
    void Update()
    {
        //Kollar om waittime har tagit slut och om det har skapats ett win
        if(waitTime <= 0 && spawnedWin == false)
        {
            //Går igenom alla rum till det sista och spawnar win på det senaste skapade rummet
            for (int i = 0; i < rooms.Count; i++)
            {
                if(i == rooms.Count - 1)
                {
                    Instantiate(win, rooms[i].transform.position, Quaternion.identity);
                    //Gör att det inte skapas fler wins
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
