using UnityEngine;
using System.Collections;

public class DoubleUpSceneManager : A_Scene {

	// Use this for initialization
	void Start () {
		m_isGameStart = true;
		m_isGameEnd = false;
		PlayerData.PlayMode = PlayerData.DOUBLE_UP_MODE;
	}
	
	// Update is called once per frame
	void Update () {
		gameEnd();
		m_waitTimer -= Time.deltaTime;
	}
	
	void OnGUI()
	{
		if( !m_isGameEnd )	return;
		
		GUI.matrix = Utility.getScreenMatrix();
		
		winButton();
		loseButton();
		drawButton();
	}
	
	protected override void gameEnd ()
	{
		if( !IsExecute )	return;
		if( !m_u_doubleUpChoiseTrump.IsEndChoise )	return;
		if( m_isGameEnd )	return;
		
		m_isGameEnd = true;
		
		Dealer dealer = new Dealer();
		dealer.paymentDoubleUp();
		m_u_uiResultManager.createResult( Dealer.IsDoubleUpJudge );
	}
	/// <summary>
	/// 勝利時のボタン処理.
	/// </summary>
	private void winButton()
	{
		if( Dealer.IsDoubleUpJudge != Dealer.PLAYER_WIN )	return;
		
		nextDoubleUp( DoubleUpButtonRect, "Next DoubleUp!!" );
		nextHalfUp();
		gotoLotusScene();
	}
	/// <summary>
	/// 敗北時のボタン処理.
	/// </summary>
	private void loseButton()
	{
		if( Dealer.IsDoubleUpJudge != Dealer.PLAYER_LOSE )	return;
		
		gotoLotusScene();
	}
	/// <summary>
	/// 引き分け時のボタン処理.
	/// </summary>
	private void drawButton()
	{
		if( Dealer.IsDoubleUpJudge != Dealer.PLAYER_DRAW )	return;
		
		nextDoubleUp( OneMoreButtonRect, "One More!" );
	}
	
	private void nextDoubleUp( Rect buttonRect, string buttonStr )
	{
		if( !GUI.Button( buttonRect, buttonStr ) )	return;
		
		Application.LoadLevel( "DoubleUpScene" );
	}
	private void nextHalfUp()
	{
		if( !GUI.Button( HalfUpButtonRect, "Next HalfUp!!" ) )	return;
		
		PlayerData.migratingHalfUpScene();
		
		Application.LoadLevel( "DoubleUpScene" );
	}
	/// <summary>
	/// ロータスシーン遷移.
	/// </summary>
	private void gotoLotusScene()
	{
		if( !GUI.Button( LotusButtonRect, "GoBack" ) )	return;
		
		PlayerData.migratingLotusScene();
		Application.LoadLevel( "LotusScene" );
	}
	
	private Rect LotusButtonRect
	{
		get{ return new Rect( 320, 240, 160, 60 ); }
	}
	private Rect OneMoreButtonRect
	{
		get{ return new Rect( 320, 240, 160, 60 ); }
	}
	private Rect DoubleUpButtonRect
	{
		get{ return new Rect( 160, 240, 160, 60 ); }
	}
	
	private Rect HalfUpButtonRect
	{
		get{ return new Rect( 480, 240, 160, 60 ); }
	}

	
	/// <summary>
	/// ダブルアップ選択トランプオブジェクト.
	/// </summary>
	public DoubleUpChoiseTrump m_u_doubleUpChoiseTrump;
	
	/// <summary>
	/// 勝敗結果UI管理者.
	/// </summary>
	public UIResultManager m_u_uiResultManager;
}
