using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : InteractableObject {
	public GameObject damageIndicatorPrefab;
	public GameObject resourcePrefab;
	public int health = 1;
	public List<QuantityOfItem> items;

	public override void OnClick() {
		health--;
		GameObject dInd = Instantiate(damageIndicatorPrefab,transform.position,Quaternion.identity);
		// dInd.GetComponentInChildren<TMPro.TMP_Text>().text = "1";					
		MovingCamera.main.Shake(0.1f,8f);

		if(health <= 0) {
			Break();
		}
	}

	void Break() {
		if(items.Count > 0) {
			foreach(QuantityOfItem item in items) {
				for(int i = 0; i < item.amount; i++) {
					GameObject go = Instantiate(resourcePrefab,transform.position,Quaternion.identity);
					go.GetComponent<Resource>().SetItem(item.item);
				}
			}
		}
		Destroy(gameObject);
	}
}
