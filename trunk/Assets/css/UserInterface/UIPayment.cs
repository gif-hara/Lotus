using UnityEngine;
using System.Collections;

public class UIPayment : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		guiText.text = "Pay:" + PlayerData.Payment;
	}
}
