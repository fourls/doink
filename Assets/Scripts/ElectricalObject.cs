using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ElectricalObject : MonoBehaviour {
	public Vector2 rayOffset = new Vector2(0f,0.5f);
	public bool on = false;

	protected virtual void Start() {
		OnStateChange();
	}

	void Update() {
		Wire wire = GetWireAt(transform.position);

		if(wire != null && wire.Circuit.On != on) {
			on = wire.Circuit.On;
			OnStateChange();
		}

		if(!Application.isPlaying)
			OnStateChange();
	}

	protected virtual void OnStateChange() {

	}
	
	Wire GetWireAt(Vector2 position) {
		RaycastHit2D hit = Physics2D.Raycast(position + rayOffset,Vector2.one,0.01f,1 << LayerMask.NameToLayer("Electrical"));

		if(hit.collider != null) {
			return hit.collider.gameObject.GetComponent<Wire>();
		}
		return null;
	}
}
