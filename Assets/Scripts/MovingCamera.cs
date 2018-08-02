using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour {
	public static MovingCamera main;
	public Transform player;
	public float movementSpeed = 5f;
	public float shakeMultiplier = 1f;
	public float lerp = 5f;

	public float test_ssDuration = 0.2f;
	public float test_ssMagnitude = 2f;

	private Vector3 wantedPosition;

	void Start() {
		main = this;
		wantedPosition = new Vector3(player.position.x,player.position.y,-10f);
	}

	void Update() {
		// if(Input.GetKey(KeyCode.LeftShift)) {
		// 	if(transform.position == wantedPosition) {
		// 		wantedPosition = new Vector3(Mathf.Round(player.position.x),Mathf.Round(player.position.y),-10f);
		// 	}
		// }

		if(Input.GetKeyDown(KeyCode.F)) {
			StartCoroutine(ScreenShake(test_ssDuration,test_ssMagnitude));
		}
	}

	void LateUpdate() {
		// if(transform.position != wantedPosition) {
		// 	transform.position = Vector3.Lerp(transform.position,wantedPosition,lerp * Time.fixedDeltaTime);
		// 	// transform.position += (wantedPosition - transform.position).normalized * movementSpeed * Time.fixedDeltaTime;
		// 	if(Vector2.Distance(transform.position,wantedPosition) <= 0.005f) {
		// 		transform.position = wantedPosition;
		// 	}
		// }
		transform.position = new Vector3((player.position.x),(player.position.y),-10f);
	}

	public void Shake(float shakeTime = 0.1f, float magnitude = 5f) {
		StartCoroutine(ScreenShake(shakeTime,magnitude));
	}

	IEnumerator ScreenShake(float shakeTime, float magnitude) {
		float timeStarted = Time.time;
		magnitude *= shakeMultiplier;

		while(timeStarted + shakeTime > Time.time) {
			transform.GetChild(0).position += new Vector3(Random.Range(-magnitude,magnitude),Random.Range(-magnitude,magnitude)) * Time.deltaTime;
			yield return null;
		}

		Vector3 wantedPos = new Vector3(0,0);
		while(Vector3.Distance(transform.GetChild(0).localPosition,wantedPos) > 0.005f) {
			transform.GetChild(0).localPosition = Vector3.Lerp(transform.GetChild(0).localPosition,wantedPos,lerp * Time.deltaTime);
			yield return null;
		}
		transform.GetChild(0).localPosition = wantedPos;
	}
}
