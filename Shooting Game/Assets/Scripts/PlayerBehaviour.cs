using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    public float playerSpeed = 4.0f;

    private float currentSpeed = 0.0f;

    private Vector3 lastMovement = new Vector3();

    public Transform laser;

    public float laserDistance = .2f;

    public float timeBetweenFires = .3f;

    private float timeTilNextFire = 0.0f;

    public List<KeyCode> shootButton;

    public AudioClip shootSound;

    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        Rotation();
        Movement();

        foreach(KeyCode element in shootButton)
        {
            if(Input.GetKey(element) && timeTilNextFire < 0)
            {
                timeTilNextFire = timeBetweenFires;
                Shootlaser();
                break;
            }
        }

        timeTilNextFire -= Time.deltaTime;
	}

    void Shootlaser()
    {
        audioSource.PlayOneShot(shootSound);

        Vector3 laserPos = this.transform.position;

        laserPos += transform.up.normalized * laserDistance;

        Instantiate(laser, laserPos, this.transform.rotation);
    }

    void Movement()
    {
        Vector3 movement = new Vector3();

        movement.x += Input.GetAxis("Horizontal");
        movement.y += Input.GetAxis("Vertical");

        movement.Normalize();

        if(movement.magnitude > 0)
        {
            currentSpeed = playerSpeed;
            this.transform.Translate(movement * Time.deltaTime * playerSpeed, Space.World);
            lastMovement = movement;
        }else
        {
            this.transform.Translate(lastMovement * Time.deltaTime * currentSpeed, Space.World);
            currentSpeed *= .9f;
        }
    }

    void Rotation()
    {
        Vector3 worldPos = Input.mousePosition;
        worldPos.z = 10;
        worldPos = Camera.main.ScreenToWorldPoint(worldPos);

        float dx = this.transform.position.x - worldPos.x;
        float dy = this.transform.position.y - worldPos.y;

        float angle = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;

        Quaternion rot = Quaternion.Euler(new Vector3(0, 0, angle + 90));

        this.transform.rotation = rot;
    }
}
