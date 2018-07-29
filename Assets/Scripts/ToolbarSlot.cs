using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolbarSlot : MonoBehaviour {
	[Header("Sprites")]
	public Sprite normalSprite;
	public Sprite selectedSprite;

	[Header("References")]
	public Image itemSprite;
	public TMPro.TMP_Text amountText;
	[Header("Values")]
	public int slot;

	private Player player;

	void Start() {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}

	void Update() {
		int[] amounts;
		Item item = player.GetToolbarItems(out amounts)[slot];

		if(item == null) {
			itemSprite.enabled = false;
			amountText.text = "";
		} else {
			itemSprite.enabled = true;
			itemSprite.sprite = item.sprite;
			amountText.text = amounts[slot].ToString();
		}

		if(player.selectedSlot == slot) {
			GetComponent<Image>().sprite = selectedSprite;
		} else {
			GetComponent<Image>().sprite = normalSprite;
		}
	}
}
