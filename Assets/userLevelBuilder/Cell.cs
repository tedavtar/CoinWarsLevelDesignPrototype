using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour {

	public int[] id;
	public bool selected = false;


	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp (0)) {
			Vector3 camPos = Camera.main.WorldToScreenPoint(transform.position);
			camPos.y = CameraOperator.InvertY(camPos.y);
			bool toggle = CameraOperator.selection.Contains(camPos);
			if (toggle){
				//toggle player selected cell
				selected = !selected;

				//do the mirror toggle
				GameObject mirroredCell = null;
				int[] flippedId = new int[2];
				flippedId[1] = id[1];
				flippedId[0] = buildAndEnable.width - 1 - id[0];
				/*
				int half = buildAndEnable.width/2;
				if (id[0] < half){
					flippedId[0] = buildAndEnable.width - 1 - id[0];
				} else {
					flippedId[0] = 
				}*/

				foreach(GameObject c in buildAndEnable.grid){
					if ((c.GetComponent<Cell>().id[0] == flippedId[0]) && c.GetComponent<Cell>().id[1] == flippedId[1]){
						c.GetComponent<Cell>().selected = !c.GetComponent<Cell>().selected;
					}
				}


			}
		}



		if (selected) {
			GetComponent<Renderer>().material.color = Color.red;
		} else {
			GetComponent<Renderer>().material.color = Color.white;
		}
	}
}
