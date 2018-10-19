using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceMove : MonoBehaviour {
	
	public MeshRenderer SR;
	
	void Update () {
		SR.material.SetTextureOffset ("_MainTex", new Vector2 (0, Mathf.Lerp (SR.material.GetTextureOffset ("_MainTex").y, Mathf.Clamp (GetComponent<Rigidbody2D>().velocity.y/15, -0.5f, 0), 10 * Time.deltaTime)));
	}
}
