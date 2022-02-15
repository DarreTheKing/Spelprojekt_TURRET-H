using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Kod av Otis
public class Destroy : MonoBehaviour
{

	void OnTriggerEnter2D(Collider2D other)
	{
		//Kollar om den kollidar med en spawnpoint och förstör den isåfall
		if (other.transform.tag == ("SpawnPoint"))
        {
			Destroy(other.gameObject);
        }
		//Förstör closedrooms
		if (other.transform.tag == ("Stopp"))
        {
			Destroy(other.gameObject);
        }
	}
}