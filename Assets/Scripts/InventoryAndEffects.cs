using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventoryAndEffects : MonoBehaviour {
	public float redDrool = 0;
	public Text redDroolX;
	private float oldDroolCount = 0;

	// Use this for initialization
	void Start () {
		redDroolX.text = redDrool.ToString();
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
