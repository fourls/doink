using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityAtStart : MonoBehaviour {
	public bool randomDirection;
	public float randomMagnitude;
	public Vector2 velocity;

	void Start() {
		if(randomDirection) {
			velocity = new Vector2(Random.Range(-1f,1f),Random.Range(-1f,1f)).normalized * randomMagnitude;
		}
		GetComponent<Rigidbody2D>().velocity = velocity;
	}
}
