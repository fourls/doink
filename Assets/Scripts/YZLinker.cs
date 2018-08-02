using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class YZLinker : MonoBehaviour {
	public Vector2 shadowSize = new Vector2(0.7f,0.3f);
	public Vector2 shadowOffset = Vector2.zero;
	[HideInInspector]
	public GameObject shadow = null;

	void Start() {
		if(Application.isPlaying && shadow == null)
			SetUpShadow();
	}

	void SetUpShadow() {
		shadow = Instantiate(Resources.Load<GameObject>("Shadow"));
		shadow.transform.SetParent(transform,false);
		shadow.transform.GetChild(0).localScale = shadowSize;
		shadow.transform.GetChild(0).localPosition = shadowOffset;
	}

	void LateUpdate () {
		transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.y);

		// if(!Application.isPlaying) {
			// if(shadow == null)
		// 		SetUpShadow();
		if(shadow != null) {
			shadow.transform.GetChild(0).localScale = shadowSize;
			shadow.transform.GetChild(0).localPosition = shadowOffset;
		}
		// }
	}
}
