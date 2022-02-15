using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Kod av Otis
public class DoorAnimation : MonoBehaviour
{
    //Referens till animatorn
    private Animator animator;
    private void Awake()
    {
        //Hämtar animatorn komponenten
        animator = GetComponent<Animator>();
    }
    //Gör öppenanimationen när opendoor funktionen kallas på
    public void openDoor()
    {
        animator.SetBool("Open", true);
    }
    //gör stänganimationen när closedoor kallas på
    public void closeDoor()
    {
        animator.SetBool("Open", false);
    }
}
