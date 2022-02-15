using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Kod av Otis
public class Camera : MonoBehaviour
{
    //Kollar vilket håll kameran ska flyttas åt
    public int cameraDirection;
    //Skapar ett gameObject för kameran
    public new GameObject camera;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Kollar om dörren kollidar med playern
        if (other.transform.tag == "Player")
        {
            //Kollar vilket håll kameran ska spawnas åt
            if (cameraDirection == 1)
            {
                //Skapar en array och lägger in alla kameror
                GameObject[] destroycamera = GameObject.FindGameObjectsWithTag("MainCamera");
                //Förstör alla kameror i arrayen
                for (int i = 0; i < destroycamera.Length; i++)
                {
                    Destroy(destroycamera[i]);
                }
                //Skapar en ny kamera åt det nya hållet
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
        //Förstör alla möjlig helstopp som kan spawnas på rummet
        if(other.CompareTag("Stopp"))
        {
            Destroy(other.gameObject);
        }
    }
}
