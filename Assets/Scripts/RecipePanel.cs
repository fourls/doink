using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipePanel : MonoBehaviour {
	public GameObject recipePrefab;

	private List<Recipe> recipes = new List<Recipe>();

	private int inventoryIteration = 0;

	void Start() {
		GetRecipes();
		RefreshRecipes();
		// StartCoroutine(RefreshOften());
	}

	void GetRecipes() {
		recipes = new List<Recipe>(Resources.LoadAll<Recipe>("Recipes/"));
	}

	// IEnumerator RefreshOften() {
	// 	while(true) {
	// 		yield return new WaitForSeconds(3f);
	// 		refresh = true;
	// 	}
	// }

	// void LateUpdate() {
	// 	Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

	// 	if(player.inventoryIteration != inventoryIteration) {
	// 		inventoryIteration = player.inventoryIteration;
	// 		RefreshRecipes();
	// 	}
	// }

	void OnEnable() {
		RefreshRecipes();
	}

	public void RefreshRecipes() {
		Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		for(int i = 0; i < transform.childCount; i++) {
			if(!transform.GetChild(i).gameObject.CompareTag("DontDestroy"))
				Destroy(transform.GetChild(i).gameObject);
		}

		foreach(Recipe recipe in recipes) {
			bool add = true;

			foreach(QuantityOfItem item in recipe.ingredients) {
				if(!player.HasItem(item.item,item.amount)) {
					add = false;
				}
			}

			if(add) {
				GameObject go = Instantiate(recipePrefab);
				go.transform.SetParent(transform,false);
				go.GetComponent<RecipeRepresentation>().recipe = recipe;
			}
		}

	}
}
