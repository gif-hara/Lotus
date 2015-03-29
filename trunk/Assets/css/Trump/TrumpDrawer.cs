using UnityEngine;
using System.Collections;

public class TrumpDrawer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		renderer.material.mainTextureScale = TRUMP_SIZE;
		renderer.material.mainTextureOffset = getTextureOffSet();
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public void initialize( TrumpData trumpData )
	{
		m_trumpData = trumpData;
	}
		
	
	private Vector2 getTextureOffSet()
	{
		float x = TRUMP_SIZE.x * (m_trumpData.Number - 1);
		float y = TRUMP_SIZE.y * m_trumpData.Type;
		
		return new Vector2( x, y );
	}
	/// <summary>
	/// トランプの種類を文字列で返す.
	/// </summary>
	/// <returns>
	/// The trump type string.
	/// </returns>
	private string getTrumpTypeString( int id )
	{
		string[] type = {
			"Clover",
			"Spade",
			"Diamond",
			"Heart",
		};
		
		return type[id];
	}
	/// <summary>
	/// トランプの種類をIDで返す.
	/// </summary>
	/// <returns>
	/// The trump type I.
	/// </returns>
	/// <param name='typeString'>
	/// Type string.
	/// </param>
	private int getTrumpTypeID( string typeString )
	{
		Hashtable table = new Hashtable();
		table["Spade"] = 0;
		table["Clover"] = 1;
		table["Diamond"] = 2;
		table["Heart"] = 3;
		
		return (int)table[typeString];
	}
	/// <summary>
	/// トランプデータを返す.
	/// </summary>
	/// <value>
	/// The get trump data.
	/// </value>
	public TrumpData GetTrumpData
	{
		get{ return m_trumpData; }
	}
	
	/// <summary>
	/// トランプデータ.
	/// </summary>
	public TrumpData m_trumpData;
	
	/// <summary>
	/// 画像のトランプ一枚のサイズ.
	/// </summary>
	private static Vector2 TRUMP_SIZE = new Vector2( 0.07692307f, 0.25f );
}
