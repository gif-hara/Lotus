using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class UIBonusManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
		createBonusUI();
		m_waitTimer += Time.deltaTime;
	}
	/// <summary>
	/// ボーナスIDの追加.
	/// </summary>
	/// <param name='bonusID'>
	/// Bonus I.
	/// </param>
	public void add( int bonusID )
	{
		m_queue.Enqueue( bonusID );
	}
	
	private void createBonusUI()
	{
		if( m_queue.Count == 0 )	return;
		if( m_waitTimer < CAN_CREATE_TIME )	return;
		
		int id = (int)m_queue.Dequeue();
		Instantiate(
			m_u_uiBonus[id],
			m_u_uiBonus[id].transform.position,
			m_u_uiBonus[id].transform.rotation
			);
			
		m_waitTimer = 0.0f;
	}
	public GameObject[] m_u_uiBonus;
	
	private Queue m_queue = new Queue();
	
	private float m_waitTimer = 0.0f;
	
	private const float CAN_CREATE_TIME = 0.6f;
}
