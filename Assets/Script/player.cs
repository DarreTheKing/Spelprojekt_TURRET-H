using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    //gjort av Zakk

    //variabler start
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
    //Variabler slut

    // Start is called before the first frame update
    void Start()
    {
        placeTurret = GetComponent<AudioSource>(); //hämtar ljud för placeringen av turrets
        rb = GetComponent<Rigidbody2D>();  //hämtar spelaren rigidbody
        scrapAmountShow = FindObjectOfType<scrapui>(); //"refererar" till scarpui scriptet
        hp = FindObjectOfType<HpUI>(); //"refererar" till HpUI scriptet
        health = maxHp; //sätter spelarens liv till max
        healthbar.SetMaxHealth(maxHp); //sätter healthbaren till maxhp

    }
    // Update is called once per frame
    void Update()
    {
        //hämtar spelarens horizontala och verticala input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //gör så att scrap mängden från scrapui scriptet är det samma som spelaren har
        scrapAmountShow.playerScrap = scrapAmount;

        hp.hpAmount = health; //gör så det som visar spelarens liv är det samma som mängden liv spelaren har

        //gör så animatorn spelar rätt animationer
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        //gör så spelarens idle animationer är korrekta
        if(animator.GetFloat("Speed")>0.01) 
        { //Om hastigheten är högre än 0.01 hämtas spelarens X direktion
            animator.SetFloat("IdleHori", movement.x);

            if(animator.GetFloat("Horizontal") == 0) //om spelarens horizontala värde är 0 blir det 1
            {
                animator.SetFloat("IdleHori", 1f);
            }
        }


        if (Input.GetKeyDown(KeyCode.Space) && scrapAmount >= 25 && turretAmount < 3 && !isDead)
        { //om spelaren trycker på space och har tillräckligt med scrap men har inte 3 turrets ute plus inte är död
            //spelas ett ljud, en turret placeras, scrap mängden sänks och turret mängden ökas
            placeTurret.Play();
            Instantiate(turret1, rb.position, Quaternion.identity);
            scrapAmount -= 25;
            turretAmount += 1;
        }

        if (health > 101) //stoppar spelaren från att ha mer än 100 liv
        {
            health = 100;
        }
        if (health < 0)//stoppar spelaren från att ha negativ mängd liv
        {
            health = 0f;
        }

       if (scrapAmount < 25) //ökar mängden scrap om man har mindre än 25 scrap.
       {
         scrapAmount += Time.deltaTime;
       }

    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime); //flyttar spelaren
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("projectile"))
        { //Kolliderar spelaren med en projectile startas Tdmg funktionen och projectilen förstörs
            damage=collision.transform.parent.GetComponent<Enemies>(); //hämtar damage variabeln från skjutaren
            Tdmg();
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == ("scrap"))
        { //kolliderar spelaren med scrap ökas mängden scrap man har och scrap pickup försvinner
            scrapAmount += 15;
            Destroy(collision.gameObject);
        }
        if (collision.transform.tag == ("Health"))
        { //Ökar splarens liv om man kolliderar med Health pickup sedan förstör pickup
            health += 20;
            healthbar.SetHP(health);
            Destroy(collision.gameObject);
        }
    }

    private void Tdmg()
    {
        //sänker mängden liv
        health -= damage.damage;
        healthbar.SetHP(health);
        if (health <= 0)
        { //om liv är 0 stoppas spelaren från att röra sig och startat death funktionen(Coroutine)
            rb.bodyType = RigidbodyType2D.Static;
            isDead = true;
            animator.SetBool("Dead", true);
            StartCoroutine(Death());
            
        }
    }

    IEnumerator Death()
    {
        //väntar i 1.5 sekunder sedan kommer lose screen up.
        yield return new WaitForSeconds(1.5f);
        loseImage.enabled = true;
        replayButton.enabled = true;
        replayImage.enabled = true;
        menuImage.enabled = true;
        menuButton.enabled = true;
        speed = 0;
    }
}

