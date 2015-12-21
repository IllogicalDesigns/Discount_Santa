using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {
	private Vector3 startLocation;
	private Collider2D myColl;
	private SpriteRenderer mySpriteRenderer;

	// Use this for initialization
	void Start () {
		startLocation = transform.position;
		myColl = gameObject.GetComponent<Collider2D> ();
		mySpriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
	}

	public void HideMe () {
		myColl.enabled = false;
		mySpriteRenderer.enabled = false;
	}
	
	public void ResetMe () {
		myColl.enabled = true;
		mySpriteRenderer.enabled = true;
	}
}
