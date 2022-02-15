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
        //H�mtar animatorn komponenten
        animator = GetComponent<Animator>();
    }
    //G�r �ppenanimationen n�r opendoor funktionen kallas p�
    public void openDoor()
    {
        animator.SetBool("Open", true);
    }
    //g�r st�nganimationen n�r closedoor kallas p�
    public void closeDoor()
    {
        animator.SetBool("Open", false);
    }
}
