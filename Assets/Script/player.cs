using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public float speed;

    public Animator animator;

    private Rigidbody2D rb;
    Vector2 movement;
    public GameObject turret1;
    public float scrapAmount = 0;
    scrapui scrapAmountShow;
    HpUI hpAmount;
    private float turretAmount;
    public float health = 100;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scrapAmountShow = FindObjectOfType<scrapui>();
        hpAmount = FindObjectOfType<HpUI>();

    }
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
       // scrapAmountShow.playerScrap = scrapAmount;
       // hpAmount.hpAmount = health;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        

        if (Input.GetKeyDown(KeyCode.Space) && scrapAmount > 25 && turretAmount < 3)
        {
            Instantiate(turret1, rb.position, Quaternion.identity);
            scrapAmount -= 25;
            turretAmount += 1;
        }

    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("projectile"))
        {
            Tdmg();
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "scrap")
        {
            scrapAmount += 15;
            Destroy(collision.gameObject);
        }
    }

    private void Tdmg()
    {
        health -= 25;
        if (health < 0)
        {
            rb.bodyType = RigidbodyType2D.Static;
            animator.SetBool("Dead", true);
        }
    }
}

