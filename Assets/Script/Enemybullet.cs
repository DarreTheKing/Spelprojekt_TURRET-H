using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemybullet : MonoBehaviour
{
    public Transform player; 
    public Rigidbody2D rb;
    private float timer=0;
    private Vector2 direction; 
    public float speed; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); 
        direction = (player.transform.position - transform.position).normalized * speed; 
        rb.velocity = new Vector2(direction.x, direction.y); 
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            Destroy(gameObject);
        }
    }


}
