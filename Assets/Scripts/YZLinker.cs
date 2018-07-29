using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class YZLinker : MonoBehaviour {
	void LateUpdate () {
		transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.y);
	}
}
