using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    //Zakk
    //Start av variabler
    public float speed;
    private Transform target;
    private Rigidbody2D rb;
    public GameObject projectile;
    private Rigidbody2D prb;
    public float timeBetweenAttack;
    public float attackRate;
    [SerializeField]
    public float health = 100;
    public Transform firepoint;
    private float bulletForce = 20;
    public Animator animator;
    public float stopRange;
    private float timer;
    public AudioSource enemyshot;
    public GameObject[] drops;
    public float damage = 25;
    Turret tdamage;
    //Slut av variabler

    // Start is called before the first frame update
    void Start()
    {
        //H�mtar spelarens position
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();//H�mtar fiendens rigidbody
        prb = projectile.GetComponent<Rigidbody2D>(); //H�mtar projectils rigidbody
        animator.SetBool("Walking", false); //g�r s� fienden b�rjar i idle animation
        timer = Random.Range(5, 10); //timer mellan fiendes "Skrik" men anv�ndes inte
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0) //om fienden d�r placers antingen ett health pickup eller scrap pickup
        {
            Instantiate(drops[Random.Range(0, drops.Length)], transform.position, Quaternion.identity);
            Spawner.enemyAmmount -= 1;
            Destroy(this.gameObject);
        }
        timeBetweenAttack += Time.deltaTime; //�kar timebetweenattack varje sekund

        if (Vector3.Distance(target.position, transform.position) > stopRange) //Om spelaren �r tillr�ckligt l�ngt bort startas move funktionen
        {
            Move();
        }
        else //om spelaren �r tillr�ckligt n�ra startas shoot funktionen
        {
            Shoot();
        }
        

    }

    private void Move() //flyttar fienden mot spelaren och ser till att r�tt animationer spelas
    {
        animator.SetBool("Walking", true);
        animator.SetFloat("VelocityX", (target.position.x - transform.position.x));
        animator.SetFloat("VelocityY", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }



    private void Shoot() //skjuter mot spelaren
    {
        animator.SetBool("Walking", false);
        timeBetweenAttack += Time.deltaTime;
        if (timeBetweenAttack >= attackRate)
        {
            GameObject bulletGO = (GameObject)Instantiate(projectile, transform.position, Quaternion.identity, transform);
            timeBetweenAttack = 0;
            enemyshot.Play();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == ("Bullet")) //vid kollision med "Bullet" tar fienden skada
        {
            tdamage = collision.transform.parent.GetComponent<Turret>();
            health -= tdamage.damage;
        }
    }
}
