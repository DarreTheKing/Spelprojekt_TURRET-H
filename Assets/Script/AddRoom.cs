using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Kod av Otis
public class AddRoom : MonoBehaviour
{
	//Referens till roomtemplates scripten
	private RoomTemplates templates;

	void Start()
	{
		//Hittar objekt med tagen rooms och hämtar Roomtemplateskomponenten
		templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
		//Lägger till rummet som en gameobject i roomtemplates
		templates.rooms.Add(this.gameObject);
	}
}