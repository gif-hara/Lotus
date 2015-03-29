using UnityEngine;
using System.Collections;

public class DisTrumpManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	/// <summary>
	/// 捨てられるトランプの受け入れ.
	/// </summary>
	/// <param name='data'>
	/// Data.
	/// </param>
	public void acceptTrump( GameObject trump )
	{
		GameObject oldDisTrump = m_currentDisTrump;
		m_currentDisTrump = (GameObject)Instantiate(
			m_u_trump,
			trump.transform.position,
			Quaternion.identity
			);
		
		m_currentDisTrump.transform.parent = transform;
		m_currentDisTrump.SendMessage( "acceptCurrentComboCount", PlayerData.ComboCount );
		m_currentDisTrump.SendMessage( "initialize", ObjectUtil.getTrumpData( trump ) );
		
		createUIMediation( oldDisTrump );
		continuity( oldDisTrump );
		createChallenger( oldDisTrump );
	}
	/// <summary>
	/// 引数のトランプは捨てトランプに相応しいか？.
	/// </summary>
	/// <returns>
	/// The accept.
	/// </returns>
	/// <param name='data'>
	/// If set to <c>true</c> data.
	/// </param>
	public bool isAccept( TrumpData data )
	{
		if( IsNullCurrentDisTrump )
		{
			return true;
		}
		
		TrumpData currentData = ((TrumpDrawer)m_currentDisTrump.GetComponent( "TrumpDrawer" )).GetTrumpData;
		
		return currentData.Number == data.Number ||
			currentData.Type == data.Type;
	}
	/// <summary>
	/// タイプ連続捨て処理.
	/// </summary>
	/// <param name='oldDisTrump'>
	/// Old dis trump.
	/// </param>
	private void continuity( GameObject oldDisTrump )
	{
		if( oldDisTrump == null )
		{
			m_continuityCount = 1;
			return;
		}
		
		TrumpData oldData = ObjectUtil.getTrumpData( oldDisTrump );
		TrumpData currentData = ObjectUtil.getTrumpData( m_currentDisTrump );
		if( oldData.Type != currentData.Type )
		{
			m_continuityCount = 0;
		}
		
		++m_continuityCount;
		createUIContinuity();
	}
	/// <summary>
	/// 橋渡し成功UIの生成.
	/// </summary>
	/// <param name='oldDisTrump'>
	/// Old dis trump.
	/// </param>
	private void createUIMediation( GameObject oldDisTrump )
	{
		if( oldDisTrump == null )	return;
		
		TrumpData oldData = ObjectUtil.getTrumpData( oldDisTrump );
		TrumpData currentData = ObjectUtil.getTrumpData( m_currentDisTrump );
		if( oldData.Number != currentData.Number )	return;
		
		m_u_uiBonusManager.add( PlayerData.BONUS_MEDIATION );
		
		PlayerData.bonusPayment( PlayerData.BONUS_MEDIATION );
		m_u_uiRate.changeRateValue();
	}
	/// <summary>
	/// タイプ連続捨て成功UIの生成.
	/// </summary>
	private void createUIContinuity()
	{
		if( m_continuityCount < CAN_CONTINUITY )	return;
		
		m_u_uiBonusManager.add( PlayerData.BONUS_CONTINUITY );
		
		m_continuityCount = 0;
		PlayerData.bonusPayment( PlayerData.BONUS_CONTINUITY );
		m_u_uiRate.changeRateValue();
	}
	/// <summary>
	/// チャレンジャー成功UIの生成.
	/// </summary>
	/// <param name='oldDisTrump'>
	/// Old dis trump.
	/// </param>
	private void createChallenger( GameObject oldDisTrump )
	{
		if( oldDisTrump != null )	return;
		if( !PlayerData.isCurrentMode( PlayerData.LOTUS_MODE ) )	return;
		if( !ObjectUtil.HandScript.isNumberAndTypeOnly( m_currentDisTrump ) )	return;
		
		m_u_uiBonusManager.add( PlayerData.BONUS_CHALLENGER );
		PlayerData.bonusPayment( PlayerData.BONUS_CHALLENGER );
		m_u_uiRate.changeRateValue();
	}
	/// <summary>
	/// 現在の捨てトランプが無いなら真を返す.
	/// </summary>
	/// <value>
	/// <c>true</c> if this instance is null current dis trump; otherwise, <c>false</c>.
	/// </value>
	public bool IsNullCurrentDisTrump
	{
		get{ return m_currentDisTrump == null; }
	}
	/// <summary>
	/// 現在の捨てトランプを返す.
	/// </summary>
	/// <value>
	/// The current dis trump.
	/// </value>
	public GameObject CurrentDisTrump
	{
		get{ return m_currentDisTrump; }
	}
		
	/// <summary>
	/// トランプオブジェクト.
	/// </summary>
	public GameObject m_u_trump;
	
	/// <summary>
	/// ボーナスUI管理者.
	/// </summary>
	public UIBonusManager m_u_uiBonusManager;
		
	/// <summary>
	/// レートUI.
	/// </summary>
	public UIRate m_u_uiRate;
	
	/// <summary>
	/// タイプ連続捨て回数.
	/// </summary>
	private int m_continuityCount = 0;
	
	/// <summary>
	/// 現在の捨てトランプ.
	/// </summary>
	private GameObject m_currentDisTrump = null;
	
	/// <summary>
	/// タイプ連続捨てボーナス適用数.
	/// </summary>
	private const int CAN_CONTINUITY = 5;
}
