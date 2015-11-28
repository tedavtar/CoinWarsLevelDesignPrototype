using UnityEngine;
using System.Collections;

public class SnapGrid : MonoBehaviour
	
{
	private bool locked;

	private Vector3 screenPoint;
	private Vector3 offset;

	/*
	public TerrainData terrDat;
	int xRes;
	int yRes;


	void Start(){
		xRes = terrDat.heightmapWidth;
		yRes = terrDat.heightmapHeight;

	}
	*/
	
	void OnMouseDown() 
	{ 
		if (locked) {
			return; // don't want to allow any more dragging once pipe segment is placed!
		}
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		
		//Cursor.visible = false;
		
		
	}
	
	void OnMouseDrag() 
	{ 
		if (locked) {
			return; // don't want to allow any more dragging once pipe segment is placed!
		}
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		
		transform.position = SnapToGrid(curPosition);
		
	}

	void OnMouseUp() 
	{ 
		locked = true;
	}

	
	
	Vector3 SnapToGrid(Vector3 Position)
	{
		Vector3 ohSnap = Vector3.zero;
		float x = Position.x;
		float y = Position.z;
		//ok so base (0,0) bottom left coord in world space of grid is 12.5,12.5. And rest of tiles are mults of 25 away
		//need to modify the x,y to snap to center of cells
		float xmod = 0;
		float ymod = 0;

		xmod = centerRound (x, 20, 25);
		ymod = centerRound (y, 10, 25);

		ohSnap.x = xmod;
		ohSnap.z = ymod;

		return ohSnap;
	}

	float centerRound(float x,int numSegs,float widthSeg){
		float rtn = 0;

		for (int i=0; i<numSegs; i++) {
			//float lowerBound = offset + i*widthSeg;
			//float upperBound = offset + (i+1)*widthSeg;
			float lowerBound = i*widthSeg;
			float upperBound = (i+1)*widthSeg;
			if ((x >= lowerBound)&&(x < upperBound)){
				rtn = .5f*(lowerBound + upperBound);
				//Debug.Log("lowerbound: " + lowerBound + "upperBound: " + upperBound);
			}
		}

		if (rtn == 0) {
			//Debug.Log("Overshoot");
			rtn = widthSeg/2.0f;
		}

		return rtn;
	}
}



