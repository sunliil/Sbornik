using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridManager : MonoBehaviour {
	
	public tk2dSpriteCollectionData tabsCollection;
	
	private List<GameObject> pictures = new List<GameObject>();
	private List<int> pictureUsed = new List<int>();
	
	void Awake()
	{
		InitGrid();
	}
	
	void InitGrid()
	{
		for(int i=0; i<8; i++)
		{
			pictureUsed.Add(0);
		}
		
		for(int i=0; i<4; i++)
		{
			for(int j=0; j<4; j++)
			{
				pictures.Add(GameObject.Find("Pict"+i.ToString()+"_"+j.ToString()));
				pictures[i*4+j].transform.localScale = new Vector3(0f,1f,1f);
				
				int pictureIndex = -1;
				while(pictureIndex < 0)
				{
					int temp = Random.Range(1,9);
					if(pictureUsed[temp-1] < 2)
					{
						pictureUsed[temp-1]++;
						pictureIndex = temp;
					}
				}
				
				tk2dSprite.AddComponent(pictures[i*4+j], tabsCollection, pictureIndex.ToString());
			}
		}
	}
	
	
}
