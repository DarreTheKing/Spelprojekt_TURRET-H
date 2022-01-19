using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.transform.tag == ("SpawnPoint"))
        {
			Destroy(other.gameObject);
        }
	}
}