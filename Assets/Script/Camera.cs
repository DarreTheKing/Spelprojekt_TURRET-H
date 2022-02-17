using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Kod av Otis
public class Camera : MonoBehaviour
{
    //Kollar vilket h�ll kameran ska flyttas �t
    public int cameraDirection;
    //Skapar ett gameObject f�r kameran
    public new GameObject camera;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Kollar om d�rren kollidar med playern
        if (other.transform.tag == "Player")
        {
            //Kollar vilket h�ll kameran ska spawnas �t
            if (cameraDirection == 1)
            {
                //Skapar en array och l�gger in alla kameror
                GameObject[] destroycamera = GameObject.FindGameObjectsWithTag("MainCamera");
                //F�rst�r alla kameror i arrayen
                for (int i = 0; i < destroycamera.Length; i++)
                {
                    Destroy(destroycamera[i]);
                }
                //Skapar en ny kamera �t det nya h�llet
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
        //F�rst�r alla m�jlig helstopp som kan spawnas p� rummet
        if(other.CompareTag("Stopp"))
        {
            Destroy(other.gameObject);
        }
    }
}
