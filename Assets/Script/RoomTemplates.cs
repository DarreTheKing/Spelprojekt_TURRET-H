using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Kod av Otis
public class RoomTemplates : MonoBehaviour
{
    //Skapar variablar f�r olika gameobject �t olika h�ll
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;
    public GameObject closedRoom;
    public GameObject leftStart;
    public GameObject rightStart;
    public GameObject upStart;
    public GameObject downStart;

    //Skapar en lista f�r alla skapade rum
    public List<GameObject> rooms;
    //V�ntar med att skapa win
    public float waitTime;
    //Kollar om win har spawnat
    private bool spawnedWin;
    //Variabel f�r win
    public GameObject win;


    // Update is called once per frame
    void Update()
    {
        //Kollar om waittime har tagit slut och om det har skapats ett win
        if(waitTime <= 0 && spawnedWin == false)
        {
            //G�r igenom alla rum till det sista och spawnar win p� det senaste skapade rummet
            for (int i = 0; i < rooms.Count; i++)
            {
                if(i == rooms.Count - 1)
                {
                    Instantiate(win, rooms[i].transform.position, Quaternion.identity);
                    //G�r att det inte skapas fler wins
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
