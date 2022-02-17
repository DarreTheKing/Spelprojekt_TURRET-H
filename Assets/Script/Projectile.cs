using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //This variable will be used for the targeting system for the bullet. -Johan
    private Transform target;
    //This variable will be used for the speed of the bullet. -Johan
    public float speed = 10f;
    //This line of code will be used to access the Particle prefab. -Johan
    public GameObject impactEffect;
    //This line of code will be used for direction of the projectile. -Johan
    Vector3 dir;
    //This function will be used for setting the target. -Johan
    public void Seek(Transform _target)
    {

        target = _target;
    }

    // Start is called before the first frame update
    void Start()
    {
        /*This line of code will find the direction that the bullet needs to point in to
          face it's target. -Johan*/
        dir = target.position - transform.position;
        //This line of code will make move the bullet at the speed. -Johan
        float distanceThisFrame = speed * Time.deltaTime;
        //This line of code makes the projectile move. -Johan
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    // Update is called once per frame
    void Update()
    {

        //These lines of code will delete the projectile if doesn't have a target. -Johan
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        //This line of code will make move the bullet at the speed. -Johan
        float distanceThisFrame = speed * Time.deltaTime;
        //This line of code makes the projectile move. -Johan
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }
    //This logic will be used to execute what the projectile does when hitting the target. -Johan
    void HitTarget()
    {
        //This line of code will instantiate the particle effect. -Johan
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        //This line of code will make it so the particle effect gets destroyed after 2 seconds. -Johan
        Destroy(effectIns, 2f);
        //This line of code will destroy the bullet. -Johan
        Destroy(gameObject);

    }
    //This code just turns on collision detection. -Johan
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //This line of code checks if it collides with an object that has the tag "Enemy". -Johan
        if (collision.transform.tag == "Enemy")
        {
            //This line of code will then execute the HitTarget logic. -Fo' Shizzle Joe han
            HitTarget();
            return;
        }
    }
}