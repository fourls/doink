using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Tooltip : MonoBehaviour {
	public Vector3 offset;
	void Update() {
        GraphicRaycaster ray = GetComponentInParent<GraphicRaycaster>();
        StandaloneInputModule input = FindObjectOfType<StandaloneInputModule>();

		Vector2 localPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle( transform as RectTransform, Input.mousePosition, ray.eventCamera, out localPos );
        
		transform.position = localPos;
	}
	public void SetText(string text) {
		GetComponentInChildren<Text>().text = text;
	}
	public void Show() {
		gameObject.SetActive(true);
	}
	public void Hide() {
		gameObject.SetActive(false);
	}
}
