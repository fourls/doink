using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ElectricalDoor : ElectricalObject {
	[Header("References")]
	public Sprite retractedSprite;
	public Sprite extendedSprite;
	public Collider2D[] toggledColls;
	[Header("Values")]
	public bool retractedWhenOn = true;
	private SpriteRenderer sr;

	protected override void Start() {
		sr = GetComponent<SpriteRenderer>();
		base.Start();
	}
	protected override void OnStateChange() {
		if(on == retractedWhenOn) {
			foreach(Collider2D coll in toggledColls) {
				coll.enabled = false;
			}
			sr.sprite = retractedSprite;
		} else {
			foreach(Collider2D coll in toggledColls) {
				coll.enabled = true;
			}
			sr.sprite = extendedSprite;
		}
	}
}
