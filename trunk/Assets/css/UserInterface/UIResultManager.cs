using UnityEngine;
using System.Collections;

public class UIResultManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	/// <summary>
	/// 勝敗結果UIの生成.
	/// </summary>
	/// <param name='resultID'>
	/// Is window.
	/// </param>
	public void createResult( int resultID )
	{
		createUIWin( resultID );
		createUILose( resultID );
		createUIDraw( resultID );
	}
	
	private void createUIWin( int resultID )
	{
		if( resultID != Dealer.PLAYER_WIN )	return;
		
		Instantiate(
			m_u_uiWin,
			m_u_uiWin.transform.position,
			m_u_uiWin.transform.rotation
			);
	}
	
	private void createUILose( int resultID )
	{
		if( resultID != Dealer.PLAYER_LOSE )	return;
		
		Instantiate(
			m_u_uiLose,
			m_u_uiLose.transform.position,
			m_u_uiLose.transform.rotation
			);
	}
	
	private void createUIDraw( int resultID )
	{
		if( resultID != Dealer.PLAYER_DRAW )	return;
		
		Instantiate(
			m_u_uiDraw,
			m_u_uiDraw.transform.position,
			m_u_uiDraw.transform.rotation
			);
	}
	
	
	
	
	/// <summary>
	/// 勝利UIオブジェクト.
	/// </summary>
	public GameObject m_u_uiWin;
	
	/// <summary>
	/// 敗北UIオブジェクト.
	/// </summary>
	public GameObject m_u_uiLose;
	
	/// <summary>
	/// 引き分けUIオブジェクト.
	/// </summary>
	public GameObject m_u_uiDraw;
}
