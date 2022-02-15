using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Kod Av otis
public class Spawner : MonoBehaviour
{
    //Timer Variabel
    private float timer;
    //Vilken fiende som ska spawnas
    public GameObject enemy;
    //Mängden fiender
    public static int enemyAmmount;
    // Start is called before the first frame update
    void Start()
    {
        //Spawnar en fiende direkt när den skapas
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Minskar timern
        timer -= Time.deltaTime;
        //Kollar om timern är slut
        if(timer <= 0)
        {
            //Sätter timern till ett nytt slumpmässigt värde
            timer = Random.Range(2, 5);
            //Ökar mängden spawnade fiender
            enemyAmmount += 1;
            //Skapar en ny fiende
            Instantiate(enemy, transform.position, Quaternion.identity);
        }
        //Förstör spawnern när den har spawnat rätt mängd fiender
        if(enemyAmmount >= 5)
        {
            Destroy(this.gameObject);
        }
    }
}
