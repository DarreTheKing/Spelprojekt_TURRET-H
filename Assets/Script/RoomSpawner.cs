using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{

	public int openingDirection;
	// 1 --> need bottom door
	// 2 --> need top door
	// 3 --> need left door
	// 4 --> need right door
	//public static int maxRooms = 50;
	public static int currentNumRooms = 0;

	private RoomTemplates templates;
	private int rand;
	public bool spawned = false;
	void Start()
	{
		templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();

		/*Collider2D test = Physics2D.OverlapCircle(transform.position, 4f);
        if (test != null)
        {
            if (test.transform.GetInstanceID() != gameObject.transform.GetInstanceID())
            {
				//print("test id = " + test.gameObject.transform.GetInstanceID());
				//print("spawner id = " + gameObject.transform.GetInstanceID());
				CancelInvoke();
				if (test.GetComponent<RoomSpawner>() != null)
				{
					test.GetComponent<RoomSpawner>().CancelInvoke();
					test.GetComponent<RoomSpawner>().spawned = true;

				}
				spawned = true;
				Destroy(test.gameObject);
				Destroy(gameObject);
				print(name + spawned);
				return;
            }
			else
			{
				Spawn();
			}
		} 
		*/
		Invoke("Spawn", 0.1f);
		
		/*if (currentNumRooms < maxRooms)
        {
			
        }
        else
        {
			//Destroy(gameObject);
        }*/
		
	}

    /*private void OnDrawGizmos()
    {
		Gizmos.color = Color.red;
		Gizmos.DrawSphere(transform.position, 4f);
    }*/

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
				//currentNumRooms += 1;
				spawned = true;
            /*else
            {
				Instantiate(templates.closedRoom, transform.position, templates.rightRooms[rand].transform.rotation);
			}*/
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