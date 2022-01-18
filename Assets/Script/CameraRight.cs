using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRight : MonoBehaviour
{
    new Camera camera;
    // Start is called before the first frame update
    void Start()
    {


        camera = Camera.main;
        camera.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == ("Player"))
        {
            Instantiate(camera, transform.position + new Vector3(4.5f, 0, -10), Quaternion.identity);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
    }
}
