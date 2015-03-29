using UnityEngine;
using System.Collections;

public class DisTrump : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	private void acceptCurrentComboCount( int count )
	{
		m_currentComboCount = count;
	}
	// Update is called once per frame
	void FixedUpdate () {
	
		transform.position = Vector3.Lerp( transform.position, getTargetPosition(), Time.deltaTime * SPEED );
	}
	/// <summary>
	/// 捨て札数に夜目標座標を返す.
	/// </summary>
	/// <returns>
	/// The target position.
	/// </returns>
	private Vector3 getTargetPosition()
	{
		Vector3 fixedZ = new Vector3( 0, 0, 0.1f * m_currentComboCount );
		return TARGET_POSITION + fixedZ;
	}
	
	/// <summary>
	/// 自分自身の連続捨て札数保持.
	/// </summary>
	private int m_currentComboCount;
	
	/// <summary>
	/// 初期目標座標.
	/// </summary>
	private static Vector3 TARGET_POSITION = new Vector3( 0.0f, 2.0f, -52.0f );
	
	private static float SPEED = 9.0f;
}
