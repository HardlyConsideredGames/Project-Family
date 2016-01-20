using UnityEngine;
using System.Collections;

public class Searcher : MonoBehaviour {

	public int myType;
	public GameObject thisObject;
	public ObjectHolder objectScript;
	public bool objectPresent;
	public bool ropeAq;
	public bool keyAq;
	public float searchMeter;
	public bool isSearching;
	string newObject;

	void Start () {

		objectPresent = false;
		isSearching = false;
		ropeAq = false;
		searchMeter = 0f;

		if (gameObject.CompareTag ("Mom")) {

			myType = 1;
		}
		else if(gameObject.CompareTag("Dad")){
			myType = 2;
		}
	
	}

	void FixedUpdate(){

		if (searchMeter >= 3f) {
			
			Search();
			
		}

		else if ( isSearching == true && objectPresent == true) {

			if(myType == 1 && objectScript.momSearched == false){

				searchMeter += 1f * Time.deltaTime;
			}

			else if(myType == 2 && objectScript.dadSearcehed == false){
				searchMeter += 1f * Time.deltaTime;

			}

		}

		else  {

			searchMeter = 0f;
		}

	}


	void OnTriggerStay2D(Collider2D other){

		if (other.gameObject.CompareTag ("Search")) {
			objectPresent = true;
			thisObject = other.gameObject;
			objectScript = thisObject.GetComponent<ObjectHolder>();
		}
	}

	void OnTriggerExit2D(Collider2D other){
		objectPresent = false;
		thisObject = null;
		objectScript = null;

	}

	void Search(){
		if (objectPresent == true) {
			if(myType == 1){										//if you are mother
				newObject = objectScript.momItem;
				objectScript.Searched (myType);
				if (newObject == "Rope") {
					ropeAq = true;
					}
				else if(newObject == "Key"){
					keyAq = true;
					}
				else{
					return;
					}
				}
			else if(myType == 2){								//if you are father
				newObject = objectScript.dadItem;
				objectScript.Searched(myType);
				if(newObject == "Key"){
					keyAq = true;
				}
				else{
					return;
				}
			}
		}
		searchMeter = 0f;
		newObject = null;
	}
	
}
