using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventoryAndEffects : MonoBehaviour {
	public float redDrool = 0;
	public Text redDroolX;
	[SerializeField] private GameObject redDroolWaste;
	private float oldDroolCount = 0;

	// Use this for initialization
	void Start () {
		redDroolX.text = redDrool.ToString();
	}

	public void ejectObj (string type){
		if (type == "RedDrool") {
			float tmpFloat = Random.Range (-90f, 90f);
			Quaternion tmpQ = Quaternion.identity;
			tmpQ.eulerAngles = new Vector3 (0, 0, tmpFloat);
			Instantiate (redDroolWaste, transform.position, tmpQ);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (redDrool < 0) {
			oldDroolCount = 0;
			redDrool = oldDroolCount;
		}
		if (redDrool != oldDroolCount) {
			oldDroolCount = redDrool;
			redDroolX.text = redDrool.ToString();
		}
	}
}
