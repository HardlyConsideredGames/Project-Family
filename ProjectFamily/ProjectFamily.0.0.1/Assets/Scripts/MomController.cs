using UnityEngine;
using System.Collections;

public class MomController : MonoBehaviour {

	public float speedFactor;
	public float jumpFactor;
	public Rigidbody2D rb;
	bool isFacingRight;
	Vector3 myScale;
	public Searcher searchScript;

	void Start() {

		rb = GetComponent<Rigidbody2D> ();
		rb.freezeRotation = true;
		isFacingRight = true;
		myScale = transform.localScale;
		searchScript = gameObject.GetComponent<Searcher> ();


	}
	
	void FixedUpdate () {

		if (Input.GetKeyDown (KeyCode.W)) {
			
			rb.AddForce(new Vector2(0,jumpFactor), ForceMode2D.Impulse);
		}

		if (Input.GetKey (KeyCode.S)) {
			
			searchScript.isSearching = true;
			
		}
		
		if(Input.GetKeyUp(KeyCode.S)){
			
			searchScript.isSearching = false;
		}


	
		if (Input.GetKey (KeyCode.D)) {

			transform.position += Vector3.right * Time.deltaTime * speedFactor;

			if(isFacingRight != true){
				Flip();
			}
		}

		else if (Input.GetKey (KeyCode.A)) {
			
			transform.position -= Vector3.right * Time.deltaTime * speedFactor;

			if(isFacingRight == true){
				Flip();
			}
		}

	}
	void Flip(){

		isFacingRight = !isFacingRight;
		myScale.x *= -1;
		transform.localScale = myScale;

	}
}
