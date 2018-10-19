using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bounce : MonoBehaviour {
	
	public float Power;
	public Sprite[] TheSprites;
	public float Cooldown;
	
	void Update () {
		if (Cooldown > 0) {
			GetComponent<SpriteRenderer>().sprite = TheSprites[1];
		} else {
			GetComponent<SpriteRenderer>().sprite = TheSprites[0];
			Cooldown = 0;
		}
		
		Cooldown -= Time.deltaTime;
		
	}
	
	void OnTriggerStay2D (Collider2D Hit) {
		if (Hit.gameObject != null) {
			if (Hit.gameObject.GetComponent<Rigidbody2D>() != null) {
				if (Hit.gameObject.GetComponent<Move>() != null) {
					Hit.gameObject.GetComponent<Move>().OnSpring = true;
				}
				Hit.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2)transform.up * Power;
				Cooldown = 0.25f;
			}
		}
	}
}
