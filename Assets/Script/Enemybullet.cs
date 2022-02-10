using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemybullet : MonoBehaviour
{
    //Zakk
    //Variabler
    public Transform player; 
    public Rigidbody2D rb;
    private float timer=0;
    private Vector2 direction; 
    public float speed; 
    //Variabler

    // Start is called before the first frame update
    void Start()
    {
        //h�mtar rigidbody och spelarens transform
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); 

        //tar reda p� �t vilket h�ll spelaren �r �t och sedan l�gger p� en velocitet p� skottet �t det h�llet spelaren �r
        direction = (player.transform.position - transform.position).normalized * speed; 
        rb.velocity = new Vector2(direction.x, direction.y);
        //roterar skottet mot spelaren
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2) //f�rst�r skottet efter en viss tid
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject); //f�rst�r skottet vid kollision
    }


}
