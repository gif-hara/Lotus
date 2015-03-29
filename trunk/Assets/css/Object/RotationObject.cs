using UnityEngine;
using System.Collections;

public class RotationObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		transform.rotation *= Quaternion.AngleAxis( Time.deltaTime * m_u_speed, m_u_axis.normalized );
	}
	
	/// <summary>
	/// 回転速度.
	/// </summary>
	public float m_u_speed = 1.0f;
	
	/// <summary>
	/// 回転軸.
	/// </summary>
	public Vector3 m_u_axis;
}
