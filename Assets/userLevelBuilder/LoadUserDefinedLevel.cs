using UnityEngine;
using System.Collections;

public class LoadUserDefinedLevel : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		foreach (int[] cellLoc in buildAndEnable.savedSelectedCells) {
			Debug.Log(cellLoc[0] + ", " + cellLoc[1]);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
