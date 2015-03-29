using UnityEngine;
using System.Collections;

public class UILose : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.position = m_initPosition;
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.position = Vector3.Lerp( transform.position, m_u_targetPosition, Time.deltaTime * SPEED );
	}
	
	/// <summary>
	/// 初期座標.
	/// </summary>
	private Vector3 m_initPosition = new Vector3( 0, 2.6565f, 0 );
	
	/// <summary>
	/// 目標座標.
	/// </summary>
	public Vector3 m_u_targetPosition = new Vector3( 0, 1.380358f, 0 );
	
	/// <summary>
	/// 移動速度.
	/// </summary>
	private const float SPEED = 2.6f;
}
