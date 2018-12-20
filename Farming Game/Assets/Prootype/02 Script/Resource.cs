using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour {

    public GameObject resource;
    public float durability;//내구도

	// Use this for initialization
	void Start () {
        resource = gameObject;
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void Level ()
    {
        if(resource.tag == "Stone")
        {
            durability = 10;
        }
        if (resource.tag == "Copper")
        {
            durability = 30;
        }
        if (resource.tag == "Coal")
        {
            durability = 60;
        }
        if (resource.tag == "Iron")
        {
            durability = 100;
        }                      
    }
}
