using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    //This line of code will let the code store the current target in a private variable -Johan
    private Transform target;

    //This header is here to mark the attributes of the turret -Johan
    [Header("Attributes")]

    //This line of code creates a variable which will be used for a firerate -Johan
    public float fireRate = 0.5f;
    //This line of code creates a variable which will be used for creating a countdown -Johan
    private float fireCountdown = 0f;
    //This line of code adds the range of the turret -Johan
    public float range = 5f;
    //This line of code helps play the audio source -Gjord av Otis, kommenterad av Johan
    public AudioSource turretShotSource;
    //This line of code creates a variable which will be used for the destruction time -Johan
    public float timer = 15;
    //This line of code will be used for the damage of the bullets -Johan
    public float damage = 25;
    

    //This header is here to mark the codes that unity requires for the turret to work -Johan
    [Header("Unity Setup Fields")]
    /*This line of code makes a variable, which creates an enemy tag that will be used for the
      enemy detection system -Johan*/
    public string enemyTag = "Enemy";
    //This line of code will be used to mark the part of the turret that should rotate -Johan
    public Transform partToRotate;
    //This line of code creates a variable which will be used for the turn speed -Johan
    public float turnSpeed = 10f;
    //This line of code will be used to make the turret access the bullet prefab -Johan
    public GameObject bulletPrefab;
    //This line of code will be used to create a firePoint for the turret -Johan
    public Transform firePoint;
    //This line of code will be used to make the turret access the Turret1Particle prefab -Johan
    public GameObject TurretParticleEffect;
    // Start is called before the first frame update
    void Start()
    {
        turretShotSource = GetComponent<AudioSource>();
        //This line of code will repeat the search for a target every 0.5 seconds -Johan
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    /*This method will help us search through objects marked as an Enemy, and select the closest
      one within range as a target -Johan*/
    void UpdateTarget()
    {
        //This line of code creates an array for the enemies -Johan
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        //This line of code will store the distance to the closest enemy each detection -Johan
        float shortestDistance = Mathf.Infinity;
        //This line of code will store the nearest GameObject that is an enemy within the code -Johan
        GameObject nearestEnemy = null;
        //This line of code will loop through the Array we created -Johan
        foreach (GameObject enemy in enemies)
        {
            /*This line of code will get the distance between the turrets position and the enemies,
              which will be saved in the float -Johan*/
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            /*This line of code will execute the code bellow it if the distanceToEnemy 
              is less than the shortestDistance -Johan*/
            if (distanceToEnemy < shortestDistance)
            {
                //This line of code will set the shortestDistance to the distanceToEnemy -Johan
                shortestDistance = distanceToEnemy;
                //This line of code will set the nearestEnemy equal to the current enemy that's selected -Johan
                nearestEnemy = enemy;
            }
        }
        //This line of code will check if we have found an enemy and that it's closest in our range -Johan
        if (nearestEnemy != null && shortestDistance <= range)
        {
            //This line of code will set our target as our nearest enemy -Johan
            target = nearestEnemy.transform;
        }
        else
        {
            /*This line of code will make the sentry lose the connection with the target when
              it's out of the range. -Johan*/
            target = null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //This line of code will check if the timer reaches zero -Johan
        if (timer <= 0)
        {
            /*It will then subtract 1 from the turretAmount counter in the player script
              and destroy the turret itself. -Johan*/
            player.turretAmount -= 1;
            Destroy(this.gameObject);
        }
        timer -= Time.deltaTime;

        //This line of code makes it so if the turret has no target it wont do anything. -Johan
        if (target == null)
        {
            return;
        }


        //This line of code makes a direction that will point towards an enemy. -Johan
        Vector3 dir = target.position - transform.position;
        //This line of code will help the turret rotate itself to look at the direction of the target. -Johan
        Vector3 rotatedVectorDir = Quaternion.Euler(0, 0, 90    ) * dir;
        //These next lines of code help the partToRotate to rotate smoothly towards the target. -Johan
        Quaternion lookRotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: rotatedVectorDir);
        Quaternion rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed);
        partToRotate.rotation = rotation;


        /*This line of code checks if the Firecountdown is less than 0, and will execute the code below. 
        -Johan */
        if (fireCountdown <= 0f)
        {

            Shoot();
            /*This line of code will divide the fireCountdown by the Firerate, making it shoot
              the set amount of bullets in the fire rate per second -Johan*/
            fireCountdown = 1f / fireRate;
        }
        //This line of code will reduce the firecountdown by 1 every second -Johan
        fireCountdown -= Time.deltaTime;
    }
    //This line of code will draw out the Range when the turret is selected -Johan
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        //This line of code will draw a sphere that only shows the wire parts -Johan
        Gizmos.DrawWireSphere(transform.position, range);
    }
    void Shoot()
    {
        //This line of code will instantiate the bullet -Johan
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation, transform);
        //This line of code will instantiate the particle effect -Johan
        GameObject Turret1Shot = (GameObject)Instantiate(TurretParticleEffect, firePoint.position, firePoint.rotation);
        //This line of code stores the bullet script in the turret script -Johan
        Projectile projectile = bulletGO.GetComponent<Projectile>();
        //This line of code plays the turret shot sound -Gjord av Otis, kommenterad av Johan
        turretShotSource.Play();
        //This line of code will make the bullet seek a target if said bullet has a component. -Johan
        if (projectile != null)
        {
            projectile.Seek(target);
        }
        
    }
}