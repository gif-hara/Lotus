using UnityEngine;
using System.Collections;

public class UIBonus : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += (transform.up * (Time.deltaTime * m_speed));
		
		if( transform.position.y > MAX_Y )
		{
			Destroy( gameObject );
		}
		
		m_speed = Mathf.Max( m_speed - (Time.deltaTime * 60.0f), 0.6f );
	}
	
	private float m_speed = 16.0f;
	
	private const float MAX_Y = 4.0f;
}
