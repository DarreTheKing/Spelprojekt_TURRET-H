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
    public float health=100;
    public GameObject[] drops;
    public AudioSource enemySound1;
    public AudioSource enemySound2;
    AudioSource randomSound;
    public List<AudioSource> audioList;
    private float timer;

    void Start()
    {
        timer = Random.Range(5, 10);
        audioList.Add(enemySound1);
        audioList.Add(enemySound2);
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        prb = projectile.GetComponent<Rigidbody2D>();
        animator.SetBool("Walking", false);
        
    }

    // Update is called once per frame
    void Update()
    {
        int audioIndex = Random.Range(0, 2);
        randomSound = audioList[audioIndex];

        if(timer <= 0)
        {
            randomSound.Play();
            timer = Random.Range(5, 10);
        }
        timeBetweenAttack += Time.deltaTime;

        if (Vector3.Distance(target.position, transform.position) > stopRange)
        {
            Move();
        }
        else
        {
            Shoot();
        }
        

        if (Input.GetKeyDown(KeyCode.F))
        {
            Damage();
        }
        

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == ("Bullet"))
        {
            Damage();
            
        }
    }

    private void Move()
    {
        animator.SetBool("Walking", true);
        animator.SetFloat("VelocityX", (target.position.x - transform.position.x));
        animator.SetFloat("VelocityY", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    private void Damage()
    {
        health -= 50;
        if (health <= 0)
        {
            Instantiate(drops[Random.Range(0, drops.Length)], transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }


    private void Shoot()
    {
        animator.SetBool("Walking", false);
        timeBetweenAttack += Time.deltaTime;
        if (timeBetweenAttack >= attackRate)
        {
            GameObject bulletGO = (GameObject)Instantiate(projectile, transform.position, transform.rotation);
            timeBetweenAttack = 0;
        }
        

    }
}
