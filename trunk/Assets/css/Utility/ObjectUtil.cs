using UnityEngine;
using System.Collections;

public class ObjectUtil : MonoBehaviour {
	
	/// <summary>
	/// 捨て札オブジェクトを返す.
	/// </summary>
	/// <value>
	/// The dis trump.
	/// </value>
	public static GameObject DisTrumpManager
	{
		get
		{
			findObject( ref m_s_disTrump, "DisTrumpManager" );
			return m_s_disTrump;
		}
	}
	/// <summary>
	/// 捨て札スクリプトを返す.
	/// </summary>
	/// <value>
	/// The dis trump script.
	/// </value>
	public static DisTrumpManager DisTrumpManagerScript
	{
		get
		{
			return (DisTrumpManager)DisTrumpManager.GetComponent( "DisTrumpManager" );
		}
	}
	/// <summary>
	/// 手札オブジェクトを返す.
	/// </summary>
	/// <value>
	/// The hand.
	/// </value>
	public static GameObject Hand
	{
		get
		{
			findObject( ref m_s_hand, "Hand" );
			return m_s_hand;
		}
	}
	/// <summary>
	/// 手札スクリプトを返す.
	/// </summary>
	/// <value>
	/// The hand script.
	/// </value>
	public static Hand HandScript
	{
		get{ return (Hand)Hand.GetComponent( "Hand" ); }
	}
	/// <summary>
	/// UI残りトランプのゲームオブジェクトを返す.
	/// </summary>
	/// <value>
	/// The user interface remain trump.
	/// </value>
	public static GameObject UIRemainTrump
	{
		get
		{
			findObject( ref m_s_uiRemainTrump, "UIRemainTrump" );
			return m_s_uiRemainTrump;
		}
	}
	/// <summary>
	/// UI残りトランプスクリプトを返す.
	/// </summary>
	/// <value>
	/// The user interface remain trump script.
	/// </value>
	public static UIRemainTrump UIRemainTrumpScript
	{
		get{ return (UIRemainTrump)UIRemainTrump.GetComponent( "UIRemainTrump" ); }
	}
	/// <summary>
	/// ダブルアップ選択カード保持オブジェクト.
	/// </summary>
	/// <value>
	/// The double up choise trump.
	/// </value>
	public static GameObject DoubleUpChoiseTrump
	{
		get
		{
			findObject( ref m_s_doubleUpChoiseTrump, "DoubleUpChoiseTrump" );
			return m_s_doubleUpChoiseTrump;
		}
	}
	
	public static DoubleUpChoiseTrump DoubleUpChoiseTrumpScript
	{
		get
		{
			return (DoubleUpChoiseTrump)DoubleUpChoiseTrump.GetComponent( "DoubleUpChoiseTrump" );
		}
	}
	/// <summary>
	/// トランプデータを抽出して返す.
	/// </summary>
	/// <returns>
	/// The trump data.
	/// </returns>
	/// <param name='obj'>
	/// Object.
	/// </param>
	public static TrumpData getTrumpData( GameObject obj )
	{
		TrumpDrawer drawer = (TrumpDrawer)obj.GetComponent( "TrumpDrawer" );
		return drawer.GetTrumpData;
	}
	/// <summary>
	/// オブジェクトの検索.
	/// </summary>
	/// <param name='obj'>
	/// Object.
	/// </param>
	/// <param name='findStr'>
	/// Find string.
	/// </param>
	private static void findObject( ref GameObject obj, string findStr )
	{
		if( obj != null )	return;
		
		obj = GameObject.Find( findStr );
	}
	
	/// <summary>
	/// 捨て札オブジェクトキャッシュ.
	/// </summary>
	private static GameObject m_s_disTrump = GameObject.Find( "DisTrumpManager" );
	
	/// <summary>
	/// 手札オブジェクト.
	/// </summary>
	private static GameObject m_s_hand = GameObject.Find( "Hand" );
	
	/// <summary>
	/// 残りトランプUIオブジェクト.
	/// </summary>
	private static GameObject m_s_uiRemainTrump = GameObject.Find( "UIRemainTrump" );
	
	/// <summary>
	/// ダブルアップ選択カード保持オブジェクト.
	/// </summary>
	private static GameObject m_s_doubleUpChoiseTrump = GameObject.Find( "DoubleUpChoiseTrump" );
}
