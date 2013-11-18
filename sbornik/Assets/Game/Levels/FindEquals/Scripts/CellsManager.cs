using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CellsManager : MonoBehaviour {
	
	private List<int> cellStates = new List<int>();
	private List<TabController> cells = new List<TabController>();
	private int OpenedCells;
	/*
	 1 - closed *
	 2 - opened *
	 3 - removed *
	 */
	
	public int GetOpenedCellCount()
	{
		return OpenedCells;
	}
	
	void Awake()
	{
		for(int i=0; i<16; i++)
		{
			cells.Add(transform.GetChild(i).GetComponent<TabController>());
		}
		OpenedCells = 0;
	}
	
	public void ResetGrid()
	{
		for(int i=0; i<16; i++)
		{
			cellStates.Add(1);
			cells[i].ResetCell();
		}
	}
	
	void CheckPair()
	{
		
	}
	
	void OnWin()
	{
		
	}
	
	public void ChangeState(int i, int j)
	{
		
	}
	
	void Update()
	{
		
	}
}
