using UnityEngine;
using System.Collections;

public class TabController : MonoBehaviour {
	
	private GameObject picture;
	private CellsManager cellManager;
	
	void Awake()
	{
		string str = gameObject.name;
		str = str.Remove(0, 4);
		picture = GameObject.Find("Pict"+str);
		
		cellManager = GameObject.Find("Cells").GetComponent<CellsManager>();
	}
	
	public void OnClick() // todo-------------------------------------------------------------------
	{
		string str = gameObject.name;
		str = str.Remove(0, 4);
		int i = str.Remove();
		cellManager.ChangeState(str[4].toInt());
	}
	
	public void OpenCell()
	{
		DoScale(new Vector3(1f,1f,1f),new Vector3(-1f,1f,1f), 0.5f, true);
	}
	
	public void CloseCell()
	{
		DoScale(new Vector3(-1f,1f,1f),new Vector3(1f,1f,1f), 0.5f, false);
	}
	
	public void RemoveCell()
	{
		transform.GetComponent<MeshRenderer>().enabled = false;
		picture.transform.GetComponent<MeshRenderer>().enabled = false;
		transform.GetComponent<Collider>().enabled = false;
	}
	
	public void ResetCell()
	{
		transform.GetComponent<MeshRenderer>().enabled = true;
		picture.transform.GetComponent<MeshRenderer>().enabled = true;
		transform.GetComponent<Collider>().enabled = true;
	}
	
	private void DoScale(Vector3 start, Vector3 end, float totalTime, bool open) 
	{
	    StartCoroutine(CR_DoScale(start, end, totalTime, open));
	}
	
	private IEnumerator CR_DoScale(Vector3 start, Vector3 end, float totalTime, bool open) 
	{
	    float t = 0;
		
	    do {
	        transform.localScale = Vector3.Lerp(start, end, t / totalTime);

	        yield return null;
	        t += Time.deltaTime;
			
			if(open)
			{
				if(t >= totalTime/2) 
				{
					picture.transform.localScale = Vector3.Lerp(start, end, t / totalTime);
				}
			}
			else
			{
				if(t < totalTime/2) 
				{
					picture.transform.localScale = Vector3.Lerp(start, end, t / totalTime);
				}
			}
	    } while (t < totalTime);

	    transform.localScale = end;
		if(!open) picture.transform.localScale = new Vector3(0f, 1f, 1f);
		transform.GetComponent<BoxCollider>().enabled = false;
	    yield break;
	}
}
