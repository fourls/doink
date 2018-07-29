using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricalButton : ElectricalSource {
	public Sprite onSprite;
	public Sprite offSprite;

	void Update() {
		GetComponent<SpriteRenderer>().sprite = on ? onSprite : offSprite;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.CompareTag("Player")) {
			on = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.CompareTag("Player")) {
			on = false;
		}
	}
}
