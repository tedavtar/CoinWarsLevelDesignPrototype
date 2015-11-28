using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class buildAndEnable : MonoBehaviour {

	//the cell prefab reference
	public GameObject cell;

	
	public static GameObject[] grid;

	public static List<int[]> savedSelectedCells;

	public static int height;
	//width better be divisible by 2!
	public static int width;
	public float padding;
	//load the cells
	void Awake(){
		//want to persist this so that have access to user-build grid
		DontDestroyOnLoad (transform.gameObject);

		height = 10;
		width = 20;
		padding = .1f;

		grid = new GameObject[height * width];
		savedSelectedCells = new List<int[]>();

		for (int i = 0; i < width; i++) {
			for (int j = 0; j < height; j++) {
				Vector3 newPos = new Vector3(i+i*padding,j+j*padding,0);
				GameObject newCell = (GameObject)Instantiate(cell,newPos,Quaternion.identity);
				int[] newId = new int[2];
				newId[0] = i;
				newId[1] = j;
				newCell.GetComponent<Cell>().id = newId;
				grid[width*j + i] = newCell;
			}
		}

	}

	//saves 
	public void Save(){
		foreach(GameObject c in buildAndEnable.grid){
			if (c.GetComponent<Cell>().selected){
				int[] selectedCellToAdd = new int[2];
				selectedCellToAdd[0] = c.GetComponent<Cell>().id[0];
				selectedCellToAdd[1] = c.GetComponent<Cell>().id[1];
				savedSelectedCells.Add(selectedCellToAdd);
			}
		}
	}

	//so once user designed level, transition to game scene and build level according to user specifications
	public void transition(){
		Save ();
		Application.LoadLevel ("GameDemo");
	}
}
