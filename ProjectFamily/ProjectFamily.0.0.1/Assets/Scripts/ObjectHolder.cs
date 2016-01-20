using UnityEngine;
using System.Collections;

public class ObjectHolder : MonoBehaviour {
	public bool momSearched;
	public bool dadSearcehed;
	public string momItem;
	public string dadItem;
	GameObject itemManager;
	ItemManager itemScript;
	
	void Start () {
		momSearched = false;
		dadSearcehed = false;
		itemManager = GameObject.FindGameObjectWithTag ("IM");
		itemScript = itemManager.GetComponent<ItemManager> ();
	
	}

	public void Searched (int type) {
	
		if (type == 1) {
			momSearched = true;
		} else if (type == 2) {
			dadSearcehed = true;
		}

	}

	IEnumerator MomReset(){

		yield return new WaitForSeconds(10);
		//Reset items here

	}


	public void SetItems(string mom, string dad){
		momItem = mom;
		dadItem = dad;


	}
}
