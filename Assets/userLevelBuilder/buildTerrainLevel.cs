using UnityEngine;
using System.Collections;

public class buildTerrainLevel : MonoBehaviour {

	public Terrain terrMain;

	int xRes;
	int yRes;


	float raisedHeight = .025f;


	// Use this for initialization
	void Start () {

		//get Terrain heightmap width and height
		xRes = terrMain.terrainData.heightmapWidth;
		yRes = terrMain.terrainData.heightmapHeight;

		//reset/flatten terrain at beginning (because residual stuff from last time can be present)
		float[,] initHeights = new float[xRes,yRes];
		for (int i = 0; i < xRes; i++) {
			for (int j = 0; j < yRes; j++) {
				initHeights[i,j] = 0;
			}	
		}
		terrMain.terrainData.SetHeights(0,0,initHeights);

		//get Terrain heights

		float[,] heights = terrMain.terrainData.GetHeights (0,0,xRes,yRes);


		//set heights to change terrain height
		/*
		int[] test = new int[2];
		test [0] = 0;//the y
		test [1] = 19;//the x
		heights = raiseCell(test, heights);*/
		foreach (int[] cellLoc in buildAndEnable.savedSelectedCells) {
			int[] correctedSwappedCellLoc = new int[2];
			correctedSwappedCellLoc[0] = cellLoc[1];
			correctedSwappedCellLoc[1] = cellLoc[0];
			heights = raiseCell(correctedSwappedCellLoc, heights);
		}



		terrMain.terrainData.SetHeights(0,0,heights);

	}

	//so takes in heights. And raises a cell in it. Also x,y are "switched"
	float [,] raiseCell(int[] cellLoc,float[,] heights){
		float xStep = xRes/10.0f; //the switch
		float yStep = yRes/20.0f; //"        "
		int xStart = (int)(cellLoc [0]*xStep);
		int yStart = (int)(cellLoc [1]*yStep);
		//Debug.Log ("xStart: " + xStart + " xStep: " + xStep);
		//Debug.Log ("yStart: " + yStart + " yStep: " + yStep);

		for (int i = xStart; i < xStart + xStep; i++) {
			for (int j = yStart; j < yStart + yStep; j++) {
				heights[i,j] = raisedHeight;
			}	
		}

		return heights;
	}


}
