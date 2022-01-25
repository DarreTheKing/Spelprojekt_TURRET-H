using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public int cameraDirection;
    public new GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            if (cameraDirection == 1)
            {

                GameObject[] destroycamera = GameObject.FindGameObjectsWithTag("MainCamera");
                for (int i = 0; i < destroycamera.Length; i++)
                {
                    Destroy(destroycamera[i]);
                }
                Instantiate(camera, transform.position + new Vector3(0, -10, -10), Quaternion.identity);
            }
            else if (cameraDirection == 2)
            {

                GameObject[] destroycamera = GameObject.FindGameObjectsWithTag("MainCamera");
                for (int i = 0; i < destroycamera.Length; i++)
                {
                    Destroy(destroycamera[i]);
                }
                Instantiate(camera, transform.position + new Vector3(0, 10, -10), Quaternion.identity);
            }
            else if (cameraDirection == 3)
            {

                GameObject[] destroycamera = GameObject.FindGameObjectsWithTag("MainCamera");
                for (int i = 0; i < destroycamera.Length; i++)
                {
                    Destroy(destroycamera[i]);
                }
                Instantiate(camera, transform.position + new Vector3(18, 0, -10), Quaternion.identity);
            }
            else if (cameraDirection == 4)
            {
                GameObject[] destroycamera = GameObject.FindGameObjectsWithTag("MainCamera");
                for (int i = 0; i < destroycamera.Length; i++)
                {
                    Destroy(destroycamera[i]);
                }

                Instantiate(camera, transform.position + new Vector3(-18, 0, -10), Quaternion.identity);
                
            }
        }
    }
}
