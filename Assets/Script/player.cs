using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    Vector2 movement;
    public GameObject turret1;
    public GameObject turret2;
    public float scrapAmount = 0;
    scrapui scrapAmountShow;
    private float turretAmount;
    public float health = 100;
    private GameObject currentTurret;
    public Sprite turret1Sprite;
    public Sprite turret2Sprite;
    public Image turretSelect;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scrapAmountShow = FindObjectOfType<scrapui>();
        currentTurret = turret1;
        changeimg();

    }
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        scrapAmountShow.playerScrap = scrapAmount;

        if (Input.GetKeyDown(KeyCode.Space) && scrapAmount > 25 && turretAmount < 3)
        {
            Instantiate(currentTurret, rb.position, Quaternion.identity);
            scrapAmount -= 25;
            turretAmount += 1;
        }


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentTurret = turret1;
            changeimg();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentTurret = turret2;
            changeimg();

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
    private void changeimg()
    {
        if (currentTurret == turret1)
        {
            turretSelect.sprite = turret1Sprite;
        }
        if (currentTurret == turret2)
        {
            turretSelect.sprite = turret2Sprite;
        }
    }

    private void Tdmg()
    {
        health -= 25;
        if (health < 0)
        {
            rb.bodyType = RigidbodyType2D.Static;
        }
    }
}

