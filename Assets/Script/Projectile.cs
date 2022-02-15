using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //This variable will be used for the targeting system for the bullet
    private Transform target;
    //This variable will be used for the speed of the bullet
    public float speed = 10f;
    //This line of code will be used to access the Particle prefab
    public GameObject impactEffect;
    //This function will be used for setting the target
    Vector3 dir;

    public void Seek(Transform _target)
    {

        target = _target;
    }

    // Start is called before the first frame update
    void Start()
    {
        /*This line of code will find the direction that the bullet needs to point in to
          face it's target*/
        dir = target.position - transform.position;
        //This line of code will make move the bullet at the speed
        float distanceThisFrame = speed * Time.deltaTime;
        //This line of code makes the projectile move
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    // Update is called once per frame
    void Update()
    {

        //These lines of code will delete the projectile if doesn't have a target.
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        //This line of code will make move the bullet at the speed
        float distanceThisFrame = speed * Time.deltaTime;
        //This line of code makes the projectile move
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }
    //This logic will be used to execute what the projectile does when hitting the target
    void HitTarget()
    {
        //This line of code will instantiate the particle effect
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        //This line of code will make it so the particle effect gets destroyed after 2 seconds
        Destroy(effectIns, 2f);
        //This line of code will destroy the bullet
        Destroy(gameObject);

    }
    //This code just turns on collision detection
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //This line of code checks if it collides with an object that has the tag "Enemy"
        if (collision.transform.tag == "Enemy")
        {
            //This line of code will then execute the HitTarget logic
            HitTarget();
            return;
        }
    }
}