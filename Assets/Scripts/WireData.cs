using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WireData : ScriptableObject {
	[Header("Colours")]
	public Color onColor;
	public Color offColor;
	[Header("Sprites")]
	public Sprite m_error;
	public Sprite m_topleft;
	public Sprite m_topright;
	public Sprite m_bottomleft;
	public Sprite m_bottomright;
	public Sprite m_vert;
	public Sprite m_horiz;
	public Sprite m_tup;
	public Sprite m_tdown;
	public Sprite m_tleft;
	public Sprite m_tright;
	public Sprite m_junction;
	public Sprite m_endup;
	public Sprite m_enddown;
	public Sprite m_endleft;
	public Sprite m_endright;
}
