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
		List<int> amounts;
		List<Item> items = player.GetToolbarItems(out amounts);

		if(items.Count <= slot) {
			itemSprite.enabled = false;
			amountText.text = "";
			GetComponent<Image>().enabled = false;
		} else {
			Item item = items[slot];
			itemSprite.enabled = true;
			itemSprite.sprite = item.sprite;
			amountText.text = amounts[slot].ToString();
			GetComponent<Image>().enabled = true;

			if(player.selectedSlot == slot) {
				GetComponent<Image>().sprite = selectedSprite;
			} else {
				GetComponent<Image>().sprite = normalSprite;
			}
		}

	}
}
