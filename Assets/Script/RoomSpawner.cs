using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Kod gjord av Otis
public class RoomSpawner : MonoBehaviour
{
	//Bestämmer vilket håll nästa rum ska skapas åt så att det alltid finns en dörr att gå igenom
	public int openingDirection;

	//En variabel för max antal rum
	public static int maxRooms = 15;
	//Variabel för mängden rum
	public static int currentNumRooms = 0;

	//tar kod från Roomtemplates
	private RoomTemplates templates;
	//variabel för att ta en random plats i en array
	private int rand;
	//Kollar om det redan har spawnats ett rum
	public bool spawned = false;
	void Start()
	{
		//Hittar objectet med tagen rooms och hittar roomtemplates komponenten i det objektet
		templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
		//väntar lite med att spawna nästa rum så att rummet innan hinner spawna
		Invoke("Spawn", 0.1f);
		//Kollar om mängden skapade rum är mer än maxmängden rum
		if (currentNumRooms > maxRooms)
		{
			//Kollar om det har spawnats ett rum tidigare
			if (spawned == false)
			{
				//Skapar ett rum utan dörrar som gör att man inte kan ta sig ut ur rummet
				Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
				spawned = true;
			}
		}
	}


    void Spawn()
	{
		if (spawned == false)
		{
			if (openingDirection == 1)
			{
				currentNumRooms += 1;
				if (currentNumRooms < 4)
				{
					Instantiate(templates.downStart, transform.position, Quaternion.identity);
				}
				// Need to spawn a room with a BOTTOM door.
				else
				{
					rand = Random.Range(0, templates.bottomRooms.Length);
					Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
				}
			}
			else if (openingDirection == 2)
			{
				currentNumRooms += 1;
				if (currentNumRooms < 4)
				{
					Instantiate(templates.upStart, transform.position, Quaternion.identity);
				}
				// Need to spawn a room with a TOP door.
				else
				{
					rand = Random.Range(0, templates.topRooms.Length);
					Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
				}
			}
			else if (openingDirection == 3)
			{
				currentNumRooms += 1;
				if (currentNumRooms < 4)
				{
					Instantiate(templates.leftStart, transform.position, Quaternion.identity);
				}

				// Need to spawn a room with a LEFT door.
				else
				{
					rand = Random.Range(0, templates.leftRooms.Length);
					Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
				}
			}
			else if (openingDirection == 4)
			{
				currentNumRooms += 1;
				if (currentNumRooms < 4)
				{
					Instantiate(templates.rightStart, transform.position, Quaternion.identity);
				}
				// Need to spawn a room with a RIGHT door.
				else
				{
					rand = Random.Range(0, templates.rightRooms.Length);
					Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
				}
			}
				spawned = true;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("SpawnPoint"))
		{
			if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
			{
				Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
				Destroy(this.gameObject);
				Debug.Log("Destroy");
			}
			spawned = true;
		}
	}
}