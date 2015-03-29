using UnityEngine;
using System.Collections;

public class RigidChipManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		//createChip();
		m_waitTimer -= Time.deltaTime;
	}
	
	public void createChip( int id )
	{
		GameObject chip = (GameObject)Instantiate(
			m_u_chips[id],
			m_u_chips[id].transform.position,
			m_u_chips[id].transform.rotation
			);
		chip.name = m_u_chips[id].name;
		chip.transform.parent = transform;
		
		m_waitTimer = INIT_WAIT_TIME;
	}
	
	private int getMargin( int id )
	{
		int result = 1;
		for( int i=0; i<id; ++i )
		{
			result *= 10;
		}
		
		return result;
	}
	
	
	/// <summary>
	/// チップ達.
	/// </summary>
	public GameObject[] m_u_chips;
	
	/// <summary>
	/// 待機時間.
	/// </summary>
	private float m_waitTimer = 0.0f;
	
	/// <summary>
	/// 待機時間の初期値.
	/// </summary>
	private const float INIT_WAIT_TIME = 0.25f;
}
