using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public Image loseImage;
    public Image replayImage;
    public Image menuImage;
    public Button replayButton;
    public Button menuButton;

    public float speed;

    public Animator animator;

    private Rigidbody2D rb;
    Vector2 movement;
    public GameObject turret1;
    public float scrapAmount = 0;
    scrapui scrapAmountShow;
    HpUI hp;
    public static float turretAmount;
    public float health = 100;
    private float maxHp = 100;
    public AudioSource placeTurret;
    private bool isDead = false;
    Enemies damage;
    public HpSlider healthbar;

    // Start is called before the first frame update
    void Start()
    {
        placeTurret = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        scrapAmountShow = FindObjectOfType<scrapui>();
        hp = FindObjectOfType<HpUI>();
        health = maxHp;
        healthbar.SetMaxHealth(maxHp);

    }
    // Update is called once per frame
    void Update()
    {
        
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        //scrapAmountShow.playerScrap = scrapAmount;
        hp.hpAmount = health;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if(animator.GetFloat("Speed")>0.01)
        {
            animator.SetFloat("IdleHori", movement.x);

            if(animator.GetFloat("Horizontal") == 0)
            {
                animator.SetFloat("IdleHori", 1f);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && scrapAmount >= 25 && turretAmount < 3 && !isDead)
        {
            placeTurret.Play();
            Instantiate(turret1, rb.position, Quaternion.identity);
            scrapAmount -= 25;
            turretAmount += 1;
        }

        if (health > 101)
        {
            health = 100;
        }
        if (health < 0)
        {
            health = 0f;
        }

       if (scrapAmount < 25)
       {
         scrapAmount += Time.deltaTime;
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
            damage=collision.transform.parent.GetComponent<Enemies>();
            Tdmg();
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == ("scrap"))
        {
            scrapAmount += 15;
            Destroy(collision.gameObject);
        }
        if (collision.transform.tag == ("Health"))
        {
            health += 20;
            Destroy(collision.gameObject);
        }
    }

    private void Tdmg()
    {
        health -= damage.damage;
        healthbar.SetHP(health);
        if (health <= 0)
        {
            rb.bodyType = RigidbodyType2D.Static;
            isDead = true;
            animator.SetBool("Dead", true);
            StartCoroutine(Death());
            
        }
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(1.5f);
        loseImage.enabled = true;
        replayButton.enabled = true;
        replayImage.enabled = true;
        menuImage.enabled = true;
        menuButton.enabled = true;
        speed = 0;
    }
}

