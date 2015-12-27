using UnityEngine;
using System.Collections;

public class PlayerCam : MonoBehaviour {
	private Transform myCam;
	public float testIntesity = 1f;
	public Vector3 distFromCam;
	private Vector3 velocity;
	public float smoothTime = 0.3f;
	public Transform target;

	void Start () {
		myCam = this.transform;
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.B)) {
			RandomCamShake (testIntesity);
		}
		Vector3 tmpVec = new Vector3 (target.position.x - distFromCam.x, target.position.y - distFromCam.y, target.position.z - distFromCam.z);

		myCam.position = Vector3.SmoothDamp(myCam.position, tmpVec, ref velocity, smoothTime);
	}

	public void RandomCamShake (float intensity){
		int tmpInt = Mathf.RoundToInt (Random.Range (0, 3));
		int tmpInt1 = Mathf.RoundToInt (Random.Range (0, 3));
		if (tmpInt == 0 | tmpInt1 == 0) {
			myCam.position = new Vector3(myCam.position.x,myCam.position.y - intensity,myCam.position.z);
		}
		if (tmpInt == 1 | tmpInt1 == 1) {
			myCam.position = new Vector3(myCam.position.x,myCam.position.y + intensity,myCam.position.z);
		}
		if (tmpInt == 2 | tmpInt1 == 2) {
			myCam.position = new Vector3(myCam.position.x - intensity,myCam.position.y,myCam.position.z);
		}
		if (tmpInt == 3 | tmpInt1 == 3) {
			myCam.position = new Vector3(myCam.position.x + intensity,myCam.position.y,myCam.position.z);
		}
	}
}
