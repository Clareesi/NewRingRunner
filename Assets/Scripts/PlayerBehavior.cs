﻿using UnityEngine;
using System.Collections;

public class PlayerBehavior : MonoBehaviour {
	public Rigidbody2D rb;
	public GameObject planet;
	private float acceleration = 100f;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//transform.rotation = Quaternion.Euler (0, 0, Mathf.Atan2(transform.position.y, transform.position.x));
		//transform.Translate (-Vector3.right * 5 * Time.deltaTime);
		
		Vector3 posDiff = planet.transform.position - transform.position;
		Vector3 perpendicular = new Vector3 (-posDiff.y, posDiff.x, posDiff.z);
		rb.velocity = perpendicular.normalized * 5;
		
		
		rb.AddForce(posDiff.normalized * acceleration);
		if (Input.GetKey (KeyCode.Space)) {
			Debug.Log (5);
			Vector3 n = Quaternion.Euler(0, 0, -30) * -posDiff;
			rb.velocity = n.normalized*20;
			//rb.AddForce(n.normalized*20,ForceMode2D.Impulse);
			//Vector3 op = transform.position;
			//transform.position = new Vector3(op.x, op.y+0.5f, op.z);
		}
		//rb.AddForce (perpendicular.normalized * 5);
	}
}