using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float timer;
    public GameObject enemy;
    public static int enemyAmmount;
    // Start is called before the first frame update
    void Start()
    {
        timer = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer = Random.Range(2, 5);
            enemyAmmount += 1;
            Instantiate(enemy, transform.position, Quaternion.identity);
        }
        if(enemyAmmount >= 5)
        {
            Destroy(this.gameObject);
        }
    }
}
