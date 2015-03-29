using UnityEngine;
using System.Collections;

public class InitTrumpData : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		gameObject.SendMessage( "initialize", getTrumpData() );
	}
	
	private TrumpData getTrumpData()
	{
		if( m_u_isRandom )	return getRandomTrumpData();
		
		TrumpData data = new TrumpData();
		data.initialize( m_u_number, m_u_type );
		
		return data;
	}
	
	private TrumpData getRandomTrumpData()
	{
		TrumpData data = new TrumpData();
		data.initialize( Random.Range( 0, Global.KING ), Random.Range( 0, 4 ) );
		
		return data;
	}
	
	/// <summary>
	/// 数値とタイプをランダムで設定するか.
	/// </summary>
	public bool m_u_isRandom = false;
	
	/// <summary>
	/// トランプの数値.
	/// </summary>
	public int m_u_number = 0;
	
	/// <summary>
	/// トランプのタイプ.
	/// </summary>
	public int m_u_type = 0;
}
