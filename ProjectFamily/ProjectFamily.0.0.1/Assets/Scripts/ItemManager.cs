using UnityEngine;
using System.Collections.Generic;

public class ItemManager : MonoBehaviour {

	public List<string> dadItems = new List<string>();
	public List<string> momItems = new List<string>();
	public List<GameObject> searchSpots = new List<GameObject>();
	ObjectHolder objectScript;
	int searchNum;
	string temp;

	void Start(){


		foreach (GameObject searchable in GameObject.FindGameObjectsWithTag("Search")) {		//creates list of searchable gameobjects

			searchSpots.Add(searchable);
		}

		for (int i = 0; i < searchSpots.Count; i++) {				//createes a list of items for mom and dad relative to searchable objects
			DadRandom(Random.Range(0,6));
			dadItems.Add(temp);
			MomRandom(Random.Range(0,6));
			momItems.Add(temp);
		}

		momItems[Random.Range(0,searchSpots.Count)] = "Rope"; 					//insert rope randomly into mom's list

		for (int i = 0; i < searchSpots.Count; i++) {								//assigns items out to searchable gameobjects

			objectScript = searchSpots[i].GetComponent<ObjectHolder>();
			objectScript.SetItems(momItems[i],dadItems[i]);
		}

	}

	void DadRandom(int num){			//generates random items
		if (num < 2) {

			temp =  "Key";
		} else if (num >= 2) {

			temp = "Null";
		}

	}

	void MomRandom(int num){			//generates random items
		if (num < 2) {
			
			temp =  "Key";
		} else if (num >= 2) {
			
			temp = "Null";
		}
		
	}

}
