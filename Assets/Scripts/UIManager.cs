using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	public GameObject recipePanel;
	public Button recipeButton;

	void Start() {
		recipePanel.SetActive(false);
	}

	void Update() {
		if(Input.GetKeyDown(KeyCode.R)) {
			if(recipePanel.activeInHierarchy) {
				CloseButtonClicked("recipe");
			} else {
				OpenButtonClicked("recipe");
			}
		}
	}

	public void OpenButtonClicked(string windowName) {
		switch(windowName) {
			case "recipe":
				recipePanel.SetActive(true);
				recipeButton.interactable = false;
				break;
		}
	}

	public void CloseButtonClicked(string windowName) {
		switch(windowName) {
			case "recipe":
				recipePanel.SetActive(false);
				recipeButton.interactable = true;
				break;
		}
	}
}
