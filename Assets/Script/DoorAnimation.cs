using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void openDoor()
    {
        animator.SetBool("Open", true);
    }
    public void closeDoor()
    {
        animator.SetBool("Open", false);
    }
}
