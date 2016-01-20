using UnityEngine;
using System.Collections;

public class DadController : MonoBehaviour {

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
		
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			
			rb.AddForce(new Vector2(0,jumpFactor), ForceMode2D.Impulse);
		}
		if (Input.GetKey (KeyCode.DownArrow)) {

			searchScript.isSearching = true;

		}

		if(Input.GetKeyUp(KeyCode.DownArrow)){

			searchScript.isSearching = false;
		}
		
		if (Input.GetKey (KeyCode.RightArrow)) {
			
			transform.position += Vector3.right * Time.deltaTime * speedFactor;
			
			if(isFacingRight != true){
				Flip();
			}
		}
		
		else if (Input.GetKey (KeyCode.LeftArrow)) {
			
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
