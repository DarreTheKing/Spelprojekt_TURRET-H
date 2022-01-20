using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    //This line of code will let the code store the current target in a private variable
    private Transform target;

    //This header is here to mark the attributes of the turret
    [Header("Attributes")]

    //This line of code creates a variable which will be used for a firerate
    public float fireRate = 0.5f;
    //This line of code creates a variable which will be used for creating a countdown
    private float fireCountdown = 0f;
    //This line of code adds the range of the turret
    public float range = 5f;
    //public AudioSource turretShotSource;

    //This header is here to mark the codes that unity requires for the turret to work
    [Header("Unity Setup Fields")]

    /*This line of code makes a variable, which creates an enemy tag that will be used for the
      enemy detection system*/
    public string enemyTag = "Enemy";
    //This line of code will be used to mark the part of the turret that should rotate
    public Transform partToRotate;
    //This line of code creates a variable which will be used for the turn speed
    public float turnSpeed = 10f;
    //This line of code will be used to make the turret access the bullet prefab
    public GameObject bulletPrefab;
    //This line of code will be used to create a firePoint for the turret
    public Transform firePoint;
    // Start is called before the first frame update
    void Start()
    {
        //turretShotSource = GetComponent<AudioSource>();
        //This line of code will repeat the search for a target every 0.5 seconds
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    /*This method will help us search through objects marked as an Enemy, and select the closest
      one within range as a target*/
    void UpdateTarget()
    {
        //This line of code creates an array for the enemies
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        //This line of code will store the distance to the closest enemy each detection
        float shortestDistance = Mathf.Infinity;
        //This line of code will store the nearest GameObject that is an enemy within the code
        GameObject nearestEnemy = null;
        //This line of code will loop through the Array we created
        foreach (GameObject enemy in enemies)
        {
            /*This line of code will get the distance between the turrets position and the enemies,
              which will be saved in the float */
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            /*This line of code will execute the code bellow it if the distanceToEnemy 
              is less than the shortestDistance*/
            if (distanceToEnemy < shortestDistance)
            {
                //This line of code will set the shortestDistance to the distanceToEnemy
                shortestDistance = distanceToEnemy;
                //This line of code will set the nearestEnemy equal to the current enemy that's selected
                nearestEnemy = enemy;
            }
        }
        //This line of code will check if we have found an enemy and that it's closest in our range
        if (nearestEnemy != null && shortestDistance <= range)
        {
            //This line of code will set our target as our nearest enemy
            target = nearestEnemy.transform;
        }
        else
        {
            /*This line of code will make the sentry lose the connection with the target when
              it's out of the range. */
            target = null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //This line of code makes it so if the turret has no target it wont do anything
        if (target == null)
        {
            return;
        }
       

        //This line of code makes a direction that will point towards an enemy
        Vector3 dir = target.position - transform.position;
        //This line of code will help the turret rotate itself to look at the direction of the target
        Vector3 rotatedVectorDir = Quaternion.Euler(0, 0, 90    ) * dir;
        //These next lines of code help the partToRotate to rotate smoothly towards the target 
        Quaternion lookRotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: rotatedVectorDir);
        Quaternion rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed);
        partToRotate.rotation = rotation;


        /*This line of code checks if the Firecountdown is less than 0, and will execute the code below
          if it is*/
        if (fireCountdown <= 0f)
        {

            Shoot();
            /*This line of code will divide the fireCountdown by the Firerate, making it shoot
              the set amount of bullets in the fire rate per second*/
            fireCountdown = 1f / fireRate;
        }
        //This line of code will reduce the firecountdown by 1 every second
        fireCountdown -= Time.deltaTime;
    }
    //This line of code will draw out the Range when the turret is selected
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        //This line of code will draw a sphere that only shows the wire parts
        Gizmos.DrawWireSphere(transform.position, range);
    }
    void Shoot()
    {
        //This line of code will instantiate the bullet
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //turretShotSource.Play();
        //This line of code stores the bullet script in the turret script
        Projectile projectile = bulletGO.GetComponent<Projectile>();
        //This line of code will make the bullet seek a target if said bullet has a component.
        if (projectile != null)
        {
            projectile.Seek(target);
        }
        
    }
}
