using UnityEngine;
using System.Collections;

public class UIMoney : MonoBehaviour {
	
	void Update()
	{
		m_u_money.text = "$ " + PlayerData.Money;
	}
	
	public GUIText m_u_money;
}
