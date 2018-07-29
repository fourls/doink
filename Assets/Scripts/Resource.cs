using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour {
	public Item itemRef;
	public float gravitateSpeed;
	public float instantStartVelocity = 5f;
	private Rigidbody2D rb2d;

	void Start() {
		if(itemRef != null) {
			SetItem(itemRef);
		}

		rb2d = GetComponent<Rigidbody2D>();

		rb2d.velocity = new Vector2(Random.Range(-1f,1f),Random.Range(-1f,1f)).normalized * instantStartVelocity;
	}

	public void SetItem(Item it) {
		itemRef = it;
		GetComponent<SpriteRenderer>().sprite = itemRef.sprite;
	}

	void OnTriggerStay2D(Collider2D other) {
		if(other.CompareTag("Player")) {
			Vector2 direction = (other.transform.position - transform.position).normalized;
			rb2d.velocity = direction * gravitateSpeed;
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.CompareTag("Player")) {
			other.gameObject.GetComponent<Player>().PickUpItem(itemRef);
			Destroy(gameObject);
		}
	}
}
