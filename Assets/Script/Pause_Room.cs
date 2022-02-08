using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Room : MonoBehaviour
{
    [SerializeField]
    Transform target;
    private int leaveMenu = 0;
    Vector3 originalPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && leaveMenu == 0)
        {
            Debug.Log("Pause");
            leaveMenu = 1;
            originalPos = transform.position;
            transform.position = target.position;
            //transform.position += new Vector3(0, -350, 0);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && leaveMenu == 1)
        {
            Debug.Log("Unpause");
            leaveMenu = 0;
            transform.position = originalPos;
            //transform.position += new Vector3(0, 350, 0);
        } 
    }

}

