using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemRepresentation : MonoBehaviour {
	public Image imageSprite;
	public Text amountText;

	public void UpdateValues(Sprite sprite, int amount) {
		imageSprite.sprite = sprite;
		amountText.text = amount.ToString();
	}
}
