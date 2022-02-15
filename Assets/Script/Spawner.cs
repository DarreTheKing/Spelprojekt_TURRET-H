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
    //M�ngden fiender
    public static int enemyAmmount;
    // Start is called before the first frame update
    void Start()
    {
        //Spawnar en fiende direkt n�r den skapas
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Minskar timern
        timer -= Time.deltaTime;
        //Kollar om timern �r slut
        if(timer <= 0)
        {
            //S�tter timern till ett nytt slumpm�ssigt v�rde
            timer = Random.Range(2, 5);
            //�kar m�ngden spawnade fiender
            enemyAmmount += 1;
            //Skapar en ny fiende
            Instantiate(enemy, transform.position, Quaternion.identity);
        }
        //F�rst�r spawnern n�r den har spawnat r�tt m�ngd fiender
        if(enemyAmmount >= 5)
        {
            Destroy(this.gameObject);
        }
    }
}
