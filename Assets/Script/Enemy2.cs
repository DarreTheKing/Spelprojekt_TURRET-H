using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    private Transform target;
    private Rigidbody2D rb;
    public float health=100;
    public GameObject bulletPrefab;
    public float stopRange;
    public float speed;
    Vector2 direction;
    public float timeBetweenAttack;
    public float attackRate;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        timeBetweenAttack += Time.deltaTime;
        if (Vector3.Distance(target.position, transform.position) > stopRange)
        {
            Move();
        }
        else
        {
            Shoot();
        }
        direction = (target.transform.position - transform.position).normalized * speed;
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    private void Shoot()
    {
        if (timeBetweenAttack > attackRate) 
        {
            GameObject shotGun = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            shotGun.transform.Rotate(0.0f, 0.0f, Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg - 30f);
            shotGun.GetComponent<Rigidbody2D>().AddForce((direction + new Vector2(-.3f, 0f)) * 10f, ForceMode2D.Impulse);
            shotGun = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            shotGun.transform.Rotate(0.0f, 0.0f, Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg + 30f);
            shotGun.GetComponent<Rigidbody2D>().AddForce((direction + new Vector2(.3f, 0f)) * 10f, ForceMode2D.Impulse);
            timeBetweenAttack = 0;
        }
        

    }
}
