using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeRepresentation : MonoBehaviour {
	public GameObject ingredientPrefab;
	public Recipe recipe;
	public ItemRepresentation resultRep;
	public Transform ingredientsContainer;
	public Tooltip tooltip;

	void Start() {
		SetUp();
	}

	public void SetUp() {
		for(int i = 0; i < ingredientsContainer.childCount; i++) {
			Destroy(ingredientsContainer.GetChild(i).gameObject);
		}

		resultRep.UpdateValues(recipe.result.item.sprite,recipe.result.amount);
		tooltip.SetText(recipe.result.item.name);

		foreach(QuantityOfItem ingredient in recipe.ingredients) {
			GameObject ing = Instantiate(ingredientPrefab);
			ing.transform.SetParent(ingredientsContainer,false);
			ing.GetComponent<ItemRepresentation>().UpdateValues(ingredient.item.sprite,ingredient.amount);
		}
	}

	public void RecipeClicked() {
		Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

		foreach(QuantityOfItem ingredient in recipe.ingredients) {
			player.RemoveItem(ingredient.item,ingredient.amount);
		}

		for(int i = 0; i < recipe.result.amount; i++)
			player.PickUpItem(recipe.result.item);

		transform.parent.GetComponent<RecipePanel>().RefreshRecipes();
	}
}
