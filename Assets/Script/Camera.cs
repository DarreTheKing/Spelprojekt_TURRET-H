using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public int cameraDirection;
    public GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(cameraDirection == 1)
        {
            Instantiate(camera, transform.position + new Vector3(0, -10, -10), Quaternion.identity);
        }
        else if (cameraDirection == 2)
        {
            Instantiate(camera, transform.position + new Vector3(0, 10, -10), Quaternion.identity);
        }
        else if (cameraDirection == 3)
        {
            Instantiate(camera, transform.position + new Vector3(18, 0, -10), Quaternion.identity);
        }
        else if (cameraDirection == 4)
        {
            Instantiate(camera, transform.position + new Vector3(-18, 0, -10), Quaternion.identity);
        }
    }
}
