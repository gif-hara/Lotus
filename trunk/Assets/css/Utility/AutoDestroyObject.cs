using UnityEngine;
using System.Collections;

public class AutoDestroyObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		dead();
		m_u_deadTimer -= Time.deltaTime;
	}
	/// <summary>
	/// 死亡処理.
	/// </summary>
	private void dead()
	{
		if( !IsDead )	return;
		
		Destroy( gameObject );
	}
	/// <summary>
	/// 死亡しているか？.
	/// </summary>
	/// <value>
	/// <c>true</c> if this instance is dead; otherwise, <c>false</c>.
	/// </value>
	private bool IsDead
	{
		get{ return m_u_deadTimer <= 0; }
	}
	
	public float m_u_deadTimer = 1.0f;
}
