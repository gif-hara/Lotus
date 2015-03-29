using UnityEngine;
using System.Collections;

public class UIComboCount : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		m_u_comboCount.text = "Count:" + PlayerData.ComboCount;
	}
	
	public GUIText m_u_comboCount;
}
