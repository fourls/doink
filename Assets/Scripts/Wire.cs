using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Wire : MonoBehaviour {
	public static List<bool> circuits = new List<bool>();
	public WireData wireSprites;
	public Vector2 rayOffset = new Vector2(0f,0.5f);

	private new SpriteRenderer renderer;
	public WireCircuit Circuit { get { return GetComponentInParent<WireCircuit>();}}



	// Use this for initialization
	void Start () {
		renderer = GetComponent<SpriteRenderer>();
		UpdateVisuals();
	}
	
	// Update is called once per frame
	void Update () {
		ElectricalSource source = GetElectrical();
		if(source != null && source.on) {
			if(!Circuit.activeWires.Contains(this)) {
				Circuit.activeWires.Add(this);
			}
		} else if(Circuit.activeWires.Contains(this)) {
			Circuit.activeWires.Remove(this);
		}

		renderer.color = Circuit.On ? wireSprites.onColor : wireSprites.offColor;
		
		if(!Application.isPlaying)
			UpdateVisuals();
	}

	public void UpdateVisuals() {
		Vector3Int[] positionsToCheck = new Vector3Int[4] {
			Vector3Int.left,
			Vector3Int.right,
			Vector3Int.up,
			Vector3Int.down
		};

		int mask = GetWireAt(transform.position + Vector3.up) != null ? 1 : 0;
        mask += GetWireAt(transform.position + Vector3.right) != null ? 2 : 0;
        mask += GetWireAt(transform.position + Vector3.down) != null ? 4 : 0;
        mask += GetWireAt(transform.position + Vector3.left) != null ? 8 : 0;

		renderer.sprite = GetSprite(mask);
	}

	public Sprite GetSprite(int mask) {
		const int up = 1;
		const int right = 2;
		const int down = 4;
		const int left = 8;

		switch(mask) {
			case up+down+left+right:
				return wireSprites.m_junction;

			case up+down+left:
				return wireSprites.m_tleft;
			case up+down+right:
				return wireSprites.m_tright;
			case left+right+up:
				return wireSprites.m_tup;
			case left+right+down:
				return wireSprites.m_tdown;

			case down+right:
				return wireSprites.m_topleft;
			case down+left:
				return wireSprites.m_topright;
			case up+right:
				return wireSprites.m_bottomleft;
			case up+left:
				return wireSprites.m_bottomright;

			case up:
				return wireSprites.m_enddown;
			case down:
				return wireSprites.m_endup;
			case up+down:
				return wireSprites.m_vert;
			case left:
				return wireSprites.m_endright;
			case right:
				return wireSprites.m_endleft;
			case right+left:
				return wireSprites.m_horiz;
		}
		return wireSprites.m_error;
	}

	public ElectricalSource GetElectrical() {
		RaycastHit2D hit = Physics2D.Raycast(transform.position + (Vector3)rayOffset,Vector2.one,0.01f,1 << LayerMask.NameToLayer("Interactable"));

		if(hit.collider != null && hit.collider.gameObject.GetComponent<ElectricalSource>() != null) {
			return hit.collider.gameObject.GetComponent<ElectricalSource>();
		}
		return null;
	}

	public Wire GetWireAt(Vector2 position) {
		RaycastHit2D hit = Physics2D.Raycast(position + rayOffset,Vector2.one,0.01f,1 << LayerMask.NameToLayer("Electrical"));

		if(hit.collider != null) {
			return hit.collider.gameObject.GetComponent<Wire>();
		}
		return null;
	}
}
