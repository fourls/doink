using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour {
	public Transform player;
	public float movementSpeed = 5f;
	public float lerp = 5f;

	private Vector3 wantedPosition;

	void Start() {
		wantedPosition = new Vector3(player.position.x,player.position.y,-10f);
	}

	void Update() {
		if(Input.GetKey(KeyCode.LeftShift)) {
			if(transform.position == wantedPosition) {
				wantedPosition = new Vector3(Mathf.Round(player.position.x),Mathf.Round(player.position.y),-10f);
			}
		}
	}

	void FixedUpdate() {
		if(transform.position != wantedPosition) {
			transform.position = Vector3.Lerp(transform.position,wantedPosition,lerp * Time.fixedDeltaTime);
			// transform.position += (wantedPosition - transform.position).normalized * movementSpeed * Time.fixedDeltaTime;
			if(Vector2.Distance(transform.position,wantedPosition) <= 0.005f) {
				transform.position = wantedPosition;
			}
		}
	}
}
