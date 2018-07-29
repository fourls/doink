using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils {
	public static Vector2 GetFlooredTile(Vector2 position) {
		return new Vector2(Mathf.Round(position.x),Mathf.Floor(position.y));
	}
}
