using UnityEngine;
using System.Collections;

public class UIWin : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		flash();
		m_timer += Time.deltaTime;
	}
	
	private void flash()
	{
		if( m_flashCount > FLASH_MAX )
		{
			renderer.enabled = true;
			return;
		}
		
		if( m_timer < FLASH_TIME )	return;
		
		m_timer = 0.0f;
		++m_flashCount;
		renderer.enabled = !renderer.enabled;
	}
	
	/// <summary>
	/// 汎用タイマー.
	/// </summary>
	private float m_timer = 0.0f;
	
	/// <summary>
	/// フラッシュした回数.
	/// </summary>
	private int m_flashCount = 0;
	
	private const int FLASH_MAX = 11;
	
	private const float FLASH_TIME = 0.06f;
}
