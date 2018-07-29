using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour {
	public float lerp = 5f;
	public Vector2 offset = new Vector2(0.5f,0);
	[HideInInspector]
	public Vector2 flooredPosition;

	void Update() {
		Vector2 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		flooredPosition = Utils.GetFlooredTile(worldMousePos);
		Vector2 wantedPos = new Vector3(flooredPosition.x,flooredPosition.y,transform.position.z);

		transform.position = Vector2.Lerp(transform.position,wantedPos,lerp * Time.deltaTime);
	}

	public InteractableObject GetInteractableAtPosition() {
		RaycastHit2D hit = Physics2D.Raycast(flooredPosition + offset,Vector2.one,0.01f,1 << LayerMask.NameToLayer("Interactable"));

		if(hit.collider != null) {
			return hit.collider.gameObject.GetComponent<InteractableObject>();
		} else {
			return null;
		}
	}
}
