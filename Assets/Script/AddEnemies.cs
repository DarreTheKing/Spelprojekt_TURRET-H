using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddEnemies : MonoBehaviour
{
    public GameObject enemySpawner;
    private int enemycount = 1;
    public int direction;
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
        if(enemycount == 1)
        {
            enemycount -= 1;
            if (direction == 1)
            {
                
                Instantiate(enemySpawner, transform.position + new Vector3(16, 14, 0), Quaternion.identity);
                Instantiate(enemySpawner, transform.position + new Vector3(16, -2, 0), Quaternion.identity);
                Instantiate(enemySpawner, transform.position + new Vector3(-16, 14, 0), Quaternion.identity);
                Instantiate(enemySpawner, transform.position + new Vector3(-16, -2, 0), Quaternion.identity);
            }
            if (direction == 2)
            {

                Instantiate(enemySpawner, transform.position + new Vector3(16, -14, 0), Quaternion.identity);
                Instantiate(enemySpawner, transform.position + new Vector3(16, 2, 0), Quaternion.identity);
                Instantiate(enemySpawner, transform.position + new Vector3(-16, -14, 0), Quaternion.identity);
                Instantiate(enemySpawner, transform.position + new Vector3(-16, 2, 0), Quaternion.identity);
            }
            if (direction == 3)
            {

                Instantiate(enemySpawner, transform.position + new Vector3(2, 8, 0), Quaternion.identity);
                Instantiate(enemySpawner, transform.position + new Vector3(2, -8, 0), Quaternion.identity);
                Instantiate(enemySpawner, transform.position + new Vector3(-26, -8, 0), Quaternion.identity);
                Instantiate(enemySpawner, transform.position + new Vector3(-26, 8, 0), Quaternion.identity);
            }
            if (direction == 4)
            {

                Instantiate(enemySpawner, transform.position + new Vector3(-2, 8, 0), Quaternion.identity);
                Instantiate(enemySpawner, transform.position + new Vector3(-2, -8, 0), Quaternion.identity);
                Instantiate(enemySpawner, transform.position + new Vector3(26, -8, 0), Quaternion.identity);
                Instantiate(enemySpawner, transform.position + new Vector3(26, 8, 0), Quaternion.identity);
            }
        }
    }
}
