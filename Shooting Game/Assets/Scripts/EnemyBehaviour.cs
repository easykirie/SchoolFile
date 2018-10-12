using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    public int health = 2;

    public Transform explosion;

    public AudioClip hitSound;

    void OnCollisionEnter2D(Collision2D theCollision)
    {
        if(theCollision.gameObject.name.Contains("Laser"))
        {
            LaserBehaviour laser = theCollision.gameObject.GetComponent<LaserBehaviour>();
            health -= laser.damage;
            Destroy(theCollision.gameObject);

            GetComponent<AudioSource>().PlayOneShot(hitSound);
        }

        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
