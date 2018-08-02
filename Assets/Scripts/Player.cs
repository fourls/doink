using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public Cursor cursor;
	public float speed;
	public Dictionary <Item,int> inventory = new Dictionary<Item, int>();
	public int selectedSlot = 0;

	private Rigidbody2D rb2d;
	[HideInInspector]
	public int inventoryIteration = 0;

	void Start() {
		rb2d = GetComponent<Rigidbody2D>();
	}

	void Update() {
		if(Input.GetMouseButtonDown(0)) {
			InteractableObject intObj = cursor.GetInteractableAtPosition();

			if(intObj != null) {
				intObj.OnClick();
			}
		}

		if(Input.GetMouseButtonDown(1)) {
			RaycastHit2D hit = Physics2D.Raycast(cursor.flooredPosition + cursor.offset,Vector2.one,0.01f,1 << LayerMask.NameToLayer("Interactable") << LayerMask.NameToLayer("Electrical"));
			RaycastHit2D ground = Physics2D.Raycast(cursor.flooredPosition + cursor.offset,Vector2.one,0.01f,1 << LayerMask.NameToLayer("Ground"));

			if(hit.collider == null && ground.collider != null) {
				Item selectedItem = GetToolbarItems()[selectedSlot];
				if(selectedItem != null && selectedItem.placedObject != null) {
					GameObject go = Instantiate(selectedItem.placedObject,cursor.flooredPosition,Quaternion.identity);
					MovingCamera.main.Shake(0.1f,5f);
					RemoveItem(selectedItem);
				}
			}
		}

		if(Input.GetKeyDown(KeyCode.Tab)) {
			selectedSlot++;
			if(selectedSlot >= inventory.Count)
				selectedSlot = 0;
		}
	}

	void FixedUpdate() {
		float vert = Input.GetAxisRaw("Vertical");
		float horiz = Input.GetAxisRaw("Horizontal");

		Vector2 direction = new Vector2(horiz,vert).normalized;

		if(direction.magnitude > 0)
			rb2d.velocity = direction * speed;
		else
			rb2d.velocity = Vector2.zero;

		GetComponent<Animator>().SetBool("moving",direction.magnitude > 0);

		if(direction.x != 0)
			transform.localScale = new Vector3(Mathf.Sign(horiz),1,1);
	}

	public void PickUpItem(Item item) {
		inventoryIteration ++;
		if(inventory.ContainsKey(item)) {
			inventory[item]++;
		} else {
			inventory.Add(item,1);
		}
	}

	public void RemoveItem(Item item, int amount = 1) {
		inventoryIteration ++;
		if(inventory.ContainsKey(item)) {
			inventory[item] -= amount;
			if(inventory[item] <= 0) {
				inventory.Remove(item);
			}
		}
	}

	public bool HasItem(Item item, int amount) {
		if(inventory.ContainsKey(item)) {
			return inventory[item] >= amount;
		} else {
			return false;
		}
	}

	public List<Item> GetToolbarItems() {
		List<Item> toolbar = new List<Item>();
		int i = 0;
		foreach(KeyValuePair<Item,int> kvp in inventory) {
			toolbar.Add(kvp.Key);
			i++;
		}
		return toolbar;
	}

	public List<Item> GetToolbarItems(out List<int> amounts) {
		List<Item> toolbar = new List<Item>();
		amounts = new List<int>();
		int i = 0;
		foreach(KeyValuePair<Item,int> kvp in inventory) {
			toolbar.Add(kvp.Key);
			amounts.Add(kvp.Value);
			i++;
		}
		return toolbar;
	}
}
