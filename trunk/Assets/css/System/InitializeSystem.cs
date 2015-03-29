using UnityEngine;
using System.Collections;

public class InitializeSystem : MonoBehaviour {

	// Use this for initialization
	void Awake () {
	
		initPlayCount();
		testPayment();
		testBackTexture();
	}
	/// <summary>
	/// プレイ回数初期化.
	/// </summary>
	private void initPlayCount()
	{
		if( !m_u_initPlayCount )	return;
		
		PlayerData.PlayCount = 0;
	}
	/// <summary>
	/// 掛け金テスト.
	/// </summary>
	private void testPayment()
	{
		if( !m_u_testPayment )	return;
		
		PlayerData.Payment = 1000;
	}
	/// <summary>
	/// 裏面画像のテスト.
	/// </summary>
	private void testBackTexture()
	{
		if( !m_u_backTextureID )	return;
		
		PlayerData.BackTextureID = m_u_backTextureIDNum;
	}
	/// <summary>
	/// プレイ回数初期化フラグ.
	/// </summary>
	public bool m_u_initPlayCount;
	
	/// <summary>
	/// 掛け金デバッグ.
	/// </summary>
	public bool m_u_testPayment;
	
	/// <summary>
	/// 裏面画像テスト.
	/// </summary>
	public bool m_u_backTextureID;
	
	/// <summary>
	/// 裏面画像ID設定値.
	/// </summary>
	public int m_u_backTextureIDNum;
}
