using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStamina : MonoBehaviour {

    public float playerstamina_max;
    public float playerstamina_current;

    Image img;

    // Use this for initialization
    void Start () {
        playerstamina_current = playerstamina_max;
        img = GetComponent<Image>();
        float img_amount = img.fillAmount;
        Color img_color = img.color;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Hit(float dmg)
    {

        playerstamina_current -= dmg;

        img.fillAmount = playerstamina_current / playerstamina_max;
    }
}

