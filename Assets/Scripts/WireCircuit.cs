using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class WireCircuit : MonoBehaviour {
	public List<Wire> activeWires = new List<Wire>();
	public bool On {get { return activeWires.Count > 0;}}
}
