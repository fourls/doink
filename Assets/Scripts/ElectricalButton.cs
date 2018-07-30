using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricalButton : ElectricalSource {
	public Sprite onSprite;
	public Sprite offSprite;

	private List<Collider2D> buttonPressers = new List<Collider2D>();

	void Update() {
		on = buttonPressers.Count > 0;
		GetComponent<SpriteRenderer>().sprite = on ? onSprite : offSprite;
	}

	void OnTriggerStay2D(Collider2D other) {
		if(!buttonPressers.Contains(other) && other.gameObject.GetComponent<PressesButtons>() != null) {
			buttonPressers.Add(other);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if(buttonPressers.Contains(other)) {
			buttonPressers.Remove(other);
		}
	}
}
