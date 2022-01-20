using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public float speed;
    private Transform target;
    private Rigidbody2D rb;
    public GameObject projectile;
    private Rigidbody2D prb;
    public float timeBetweenAttack;
    public float attackRate;
    public Transform firepoint;
    private float bulletForce = 20;
    public Animator animator;
    public float stopRange;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        prb = projectile.GetComponent<Rigidbody2D>();
        animator.SetBool("Walking", false);

        
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
        

    }

    private void Move()
    {
        animator.SetBool("Walking", true);
        animator.SetFloat("VelocityX", (target.position.x - transform.position.x));
        animator.SetFloat("VelocityY", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }



    private void Shoot()
    {
        animator.SetBool("Walking", false);
        timeBetweenAttack += Time.deltaTime;
        if (timeBetweenAttack >= attackRate)
        {
            GameObject bulletGO = (GameObject)Instantiate(projectile, transform.position, Quaternion.identity);
            timeBetweenAttack = 0;
        }
        

    }
}
