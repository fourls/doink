using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityAtStart : MonoBehaviour {
	public Vector2 velocity;

	void Start() {
		GetComponent<Rigidbody2D>().velocity = velocity;
	}
}
