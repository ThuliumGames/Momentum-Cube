using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Platform : MonoBehaviour {
	
	public LayerMask LM;
	public TilemapCollider2D TMC;
	
	void Update () {
		if (Physics2D.Raycast(transform.position+Vector3.down, Vector2.down, 1, LM)) {
			TMC.isTrigger = false;
		} else {
			TMC.isTrigger = true;
		}
	}
}
