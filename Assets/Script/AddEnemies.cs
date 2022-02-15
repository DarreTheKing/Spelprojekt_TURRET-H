using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Kod av Otis
public class AddEnemies : MonoBehaviour
{
    //Variabel f�r vad som ska spawnas
    public GameObject enemySpawner;
    //Variabeln f�r om det tidigare hade spawnats fiender
    private int enemycount = 1;
    //Variabel f�r vilket h�ll fienderna ska spawnas �t
    public int direction;
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Kollar om spawnern har spawnat fiender
        if(enemycount == 1)
        {
            enemycount -= 1;
            //Spawnar fyra spawners i varje h�rn, beroende p� h�llet spawnas de olika
            if (direction == 1)
            {
                
                Instantiate(enemySpawner, transform.position + new Vector3(16, 14, 0), Quaternion.identity);
                Instantiate(enemySpawner, transform.position + new Vector3(16, -2, 0), Quaternion.identity);
                Instantiate(enemySpawner, transform.position + new Vector3(-16, 14, 0), Quaternion.identity);
                Instantiate(enemySpawner, transform.position + new Vector3(-16, -2, 0), Quaternion.identity);
            }
            else if (direction == 2)
            {

                Instantiate(enemySpawner, transform.position + new Vector3(16, -14, 0), Quaternion.identity);
                Instantiate(enemySpawner, transform.position + new Vector3(16, 2, 0), Quaternion.identity);
                Instantiate(enemySpawner, transform.position + new Vector3(-16, -14, 0), Quaternion.identity);
                Instantiate(enemySpawner, transform.position + new Vector3(-16, 2, 0), Quaternion.identity);
            }
            else if (direction == 3)
            {

                Instantiate(enemySpawner, transform.position + new Vector3(2, 8, 0), Quaternion.identity);
                Instantiate(enemySpawner, transform.position + new Vector3(2, -8, 0), Quaternion.identity);
                Instantiate(enemySpawner, transform.position + new Vector3(-26, -8, 0), Quaternion.identity);
                Instantiate(enemySpawner, transform.position + new Vector3(-26, 8, 0), Quaternion.identity);
            }
            else if (direction == 4)
            {

                Instantiate(enemySpawner, transform.position + new Vector3(-2, 8, 0), Quaternion.identity);
                Instantiate(enemySpawner, transform.position + new Vector3(-2, -8, 0), Quaternion.identity);
                Instantiate(enemySpawner, transform.position + new Vector3(26, -8, 0), Quaternion.identity);
                Instantiate(enemySpawner, transform.position + new Vector3(26, 8, 0), Quaternion.identity);
            }
        }
    }
}
