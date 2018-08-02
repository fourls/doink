using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : InteractableObject {
	[Header("References")]
	public GameObject bubblePanel;
	public Text bubble;

	[Header("Dialogue")]
	public List<DialogueComponent> dialogue;
	private int index = -1;
	private Animator animator;

	void Awake() {
		animator = GetComponent<Animator>();
	}

	public void UpdateBubble() {
		if(index < 0 || index >= dialogue.Count) {
			bubblePanel.SetActive(false);	
		} else {
			bubblePanel.SetActive(true);
			bubble.text = dialogue[index].text;
			if(dialogue[index].animation != "")
				animator.SetTrigger(dialogue[index].animation);
		}
	}

	public override void OnClick() {
		index++;

		UpdateBubble();
	}
}
