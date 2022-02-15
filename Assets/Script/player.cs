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
        placeTurret = GetComponent<AudioSource>(); //h�mtar ljud f�r placeringen av turrets
        rb = GetComponent<Rigidbody2D>();  //h�mtar spelaren rigidbody
        scrapAmountShow = FindObjectOfType<scrapui>(); //"refererar" till scarpui scriptet
        hp = FindObjectOfType<HpUI>(); //"refererar" till HpUI scriptet
        health = maxHp; //s�tter spelarens liv till max
        healthbar.SetMaxHealth(maxHp); //s�tter healthbaren till maxhp

    }
    // Update is called once per frame
    void Update()
    {
        //h�mtar spelarens horizontala och verticala input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //g�r s� att scrap m�ngden fr�n scrapui scriptet �r det samma som spelaren har
        scrapAmountShow.playerScrap = scrapAmount;

        hp.hpAmount = health; //g�r s� det som visar spelarens liv �r det samma som m�ngden liv spelaren har

        //g�r s� animatorn spelar r�tt animationer
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        //g�r s� spelarens idle animationer �r korrekta
        if(animator.GetFloat("Speed")>0.01) 
        { //Om hastigheten �r h�gre �n 0.01 h�mtas spelarens X direktion
            animator.SetFloat("IdleHori", movement.x);

            if(animator.GetFloat("Horizontal") == 0) //om spelarens horizontala v�rde �r 0 blir det 1
            {
                animator.SetFloat("IdleHori", 1f);
            }
        }


        if (Input.GetKeyDown(KeyCode.Space) && scrapAmount >= 25 && turretAmount < 3 && !isDead)
        { //om spelaren trycker p� space och har tillr�ckligt med scrap men har inte 3 turrets ute plus inte �r d�d
            //spelas ett ljud, en turret placeras, scrap m�ngden s�nks och turret m�ngden �kas
            placeTurret.Play();
            Instantiate(turret1, rb.position, Quaternion.identity);
            scrapAmount -= 25;
            turretAmount += 1;
        }

        if (health > 101) //stoppar spelaren fr�n att ha mer �n 100 liv
        {
            health = 100;
        }
        if (health < 0)//stoppar spelaren fr�n att ha negativ m�ngd liv
        {
            health = 0f;
        }

       if (scrapAmount < 25) //�kar m�ngden scrap om man har mindre �n 25 scrap.
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
        { //Kolliderar spelaren med en projectile startas Tdmg funktionen och projectilen f�rst�rs
            damage=collision.transform.parent.GetComponent<Enemies>(); //h�mtar damage variabeln fr�n skjutaren
            Tdmg();
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == ("scrap"))
        { //kolliderar spelaren med scrap �kas m�ngden scrap man har och scrap pickup f�rsvinner
            scrapAmount += 15;
            Destroy(collision.gameObject);
        }
        if (collision.transform.tag == ("Health"))
        { //�kar splarens liv om man kolliderar med Health pickup sedan f�rst�r pickup
            health += 20;
            healthbar.SetHP(health);
            Destroy(collision.gameObject);
        }
    }

    private void Tdmg()
    {
        //s�nker m�ngden liv
        health -= damage.damage;
        healthbar.SetHP(health);
        if (health <= 0)
        { //om liv �r 0 stoppas spelaren fr�n att r�ra sig och startat death funktionen(Coroutine)
            rb.bodyType = RigidbodyType2D.Static;
            isDead = true;
            animator.SetBool("Dead", true);
            StartCoroutine(Death());
            
        }
    }

    IEnumerator Death()
    {
        //v�ntar i 1.5 sekunder sedan kommer lose screen up.
        yield return new WaitForSeconds(1.5f);
        loseImage.enabled = true;
        replayButton.enabled = true;
        replayImage.enabled = true;
        menuImage.enabled = true;
        menuButton.enabled = true;
        speed = 0;
    }
}

