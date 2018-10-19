using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
	
	float Speed;
	public float Acceleration;
	public float JumpPower;
	bool OnGround;
	bool InWater;
	public bool OnSpring;
	
	void FixedUpdate () {
		
		if ((OnGround || InWater) && !OnSpring) {
			
			if (Input.GetKey (KeyCode.LeftArrow)) {
				Speed -= Acceleration;
			}
			
			if (Input.GetKey (KeyCode.RightArrow)) {
				Speed += Acceleration;
			}
		} else {
			Speed = GetComponent<Rigidbody2D>().velocity.x;
		}
		
		Speed /= ((GetComponent<Rigidbody2D>().drag/80)+1);
		
		if (Input.GetKey (KeyCode.UpArrow) && OnGround) {
			OnGround = false;
			GetComponent<Rigidbody2D>().velocity = new Vector2 (Speed, JumpPower);
		}
		
		GetComponent<Rigidbody2D>().velocity = new Vector2 (Speed, GetComponent<Rigidbody2D>().velocity.y);
	}
	
	void OnCollisionStay2D (Collision2D Hit) {
		if (Hit.collider != null) {	
			OnGround = true;
		}
	}
	
	void OnCollisionExit2D (Collision2D Hit) {
			OnGround = false;
	}
	
	void OnTriggerStay2D (Collider2D Hit) {
		
		if (Hit.gameObject.tag == "Dead") {
			Speed = 0;
			transform.position = new Vector2 (-7.5f,-1.5f);
		}
		
		if (Hit.gameObject.layer != LayerMask.NameToLayer ("Platform")) {
		
			if (!Input.GetKey (KeyCode.DownArrow) && !OnGround) {
				GetComponent<Rigidbody2D>().velocity += new Vector2 (0, 15*Time.deltaTime);
			}
			if (Input.GetKey (KeyCode.UpArrow)) {
				GetComponent<Rigidbody2D>().velocity += new Vector2 (0, 9.8f*Time.deltaTime);
			}
			GetComponent<Rigidbody2D>().drag = 2;
			InWater = true;
		}
	}
	
	void OnTriggerExit2D () {
		GetComponent<Rigidbody2D>().drag = 0;
		OnSpring = false;
		InWater = false;
	}
}
