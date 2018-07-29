using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Recipe : ScriptableObject {
	public List<QuantityOfItem> ingredients;
	public QuantityOfItem result;

}
