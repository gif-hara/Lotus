using UnityEngine;
using System.Collections;

public class LotusSceneManager : A_Scene {

	// Use this for initialization
	void Start () {
		m_isGameStart = false;
		m_isGameEnd = false;
		m_waitTimer = 0.0f;
		PlayerData.initialize();
		PlayerData.PlayMode = PlayerData.LOTUS_MODE;
	}
	
	// Update is called once per frame
	void Update () {
		
		quit();
		gameEnd();
		m_waitTimer -= Time.deltaTime;
	}
	void OnGUI()
	{
		GUI.matrix = Utility.getScreenMatrix();
		
		paymentButton();
		
		winButton();
		
		loseButton();

	}
	/// <summary>
	/// 掛け金処理時のボタン処理.
	/// </summary>
	private void paymentButton()
	{
		if( IsGameStart )	return;
		
		gameStartButton();
		addPaymentButton();
		subPaymentButton();
	}
	private void winButton()
	{
		if( !m_isGameEnd )	return;
		if( Dealer.IsLotusPlayerWin != Dealer.PLAYER_WIN )	return;
		
		gotoDoubleUpScene();
		gotoHalfUpScene();
		gotoRetry();
	}
	/// <summary>
	/// ダブルアップシーン遷移.
	/// </summary>
	private void gotoDoubleUpScene()
	{
		if( !GUI.Button( DoubleUpButtonRect, "Challenge DoubleUp!" ) )	return;
		
		Application.LoadLevel( "DoubleUpScene" );
	}
	/// <summary>
	/// ハーフアップシーン遷移.
	/// </summary>
	private void gotoHalfUpScene()
	{
		if( !GUI.Button( HalfUpButtonRect, "Challenge HalfUp!" ) )	return;
		
		PlayerData.migratingHalfUpScene();
		Application.LoadLevel( "DoubleUpScene" );
	}
	private void loseButton()
	{
		if( !m_isGameEnd )	return;
		if( Dealer.IsLotusPlayerWin != Dealer.PLAYER_LOSE )	return;
		
		gotoRetry();
	}
	/// <summary>
	/// ゲームスタートボタン処理.
	/// </summary>
	private void gameStartButton()
	{
		if( IsNotPayment )	return;
		if( !GUI.Button( GameStartRect, "GameStart!" ) )	return;
		
		gameStart();
	}
	/// <summary>
	/// 掛け金加算ボタン処理.
	/// </summary>
	private void addPaymentButton()
	{
		for( int i=0; i<4; ++i )
		{
			addPaymentButton( i );
		}
	}
	/// <summary>
	/// 掛け金減算ボタン処理.
	/// </summary>
	private void subPaymentButton()
	{
		for( int i=0; i<4; ++i )
		{
			subPaymentButton( i );
		}
	}

	private void addPaymentButton( int id )
	{
		int moneyCount = getMoneyCount( 10, id );
		string buttonStr = "+$" + moneyCount;
		if( !GUI.Button( getAddPaymentRect( id ), buttonStr ) )	return;
		
		if( PlayerData.Money < moneyCount )	return;
		
		PlayerData.Payment += moneyCount;
		PlayerData.Money -= moneyCount;
		m_u_uiRate.changeRateValue();
		m_u_rigidChipManager.createChip( id + 1 );
		createPaymentSound();
	}
	private void subPaymentButton( int id )
	{
		int moneyCount = getMoneyCount( 10, id );
		string buttonStr = "-$" + moneyCount;
		if( !GUI.Button( getSubPaymentRect( id ), buttonStr ) )	return;
		
		if( PlayerData.Payment < moneyCount )	return;
		
		PlayerData.Payment -= moneyCount;
		PlayerData.Money += moneyCount;
		m_u_uiRate.changeRateValue();
		createPaymentSound();
	}
	
	
	public override void gameStart ()
	{
		base.gameStart ();
		((GameObject)Instantiate(
			m_u_uiRemainTrump,
			m_u_uiRemainTrump.transform.position,
			m_u_uiRemainTrump.transform.rotation
			)).name = "UIRemainTrump";
	}
	protected override void gameEnd ()
	{
		if( !IsExecute )	return;
		if( !ObjectUtil.HandScript.IsGameEnd )	return;
		if( m_isGameEnd )	return;
		
		m_isGameEnd = true;
		Destroy( ObjectUtil.UIRemainTrump );
		Destroy( m_u_uiRate.gameObject );
		Dealer dealer = new Dealer();
		dealer.paymentLotus();
		++PlayerData.PlayCount;
		m_u_uiResultManager.createResult( Dealer.IsLotusPlayerWin );
	}
	/// <summary>
	/// リトライボタン処理.
	/// </summary>
	private void gotoRetry()
	{
		if( !IsExecute )	return;
		if( !ObjectUtil.HandScript.IsGameEnd )	return;
		

		if( GUI.Button( RetryRect, "Retry" ) )
		{
			PlayerData.migratingLotusScene();
			Application.LoadLevel( "LotusScene" );
		}
	}
	/// <summary>
	/// アプリ終了処理.
	/// </summary>
	private void quit()
	{
		if( !Input.GetKey( KeyCode.Escape ) )	return;
		
		Application.LoadLevel( "TitleScene" );
	}
	/// <summary>
	/// 掛け金加算ボタンの矩形を返す.
	/// </summary>
	/// <returns>
	/// The add payment rect.
	/// </returns>
	/// <param name='id'>
	/// Identifier.
	/// </param>
	private Rect getAddPaymentRect( int id )
	{
		return new Rect( 270, 40 + (id*70), 120, 60 );
	}
	/// <summary>
	/// 掛け金減算ボタンの矩形を返す.
	/// </summary>
	/// <returns>
	/// The sub payment rect.
	/// </returns>
	/// <param name='id'>
	/// Identifier.
	/// </param>
	private Rect getSubPaymentRect( int id )
	{
		return new Rect( 410, 40 + (id*70), 120, 60 );
	}
	/// <summary>
	/// IDによるお金の消費量を返す.
	/// </summary>
	/// <returns>
	/// The money count.
	/// </returns>
	/// <param name='value'>
	/// Value.
	/// </param>
	/// <param name='id'>
	/// Identifier.
	/// </param>
	private int getMoneyCount( int value, int id )
	{
		int result = value;
		for( int i=0; i<id; i++ )
		{
			result *= 10;
		}
		
		return result;
	}
	/// <summary>
	/// 掛け金サウンドの生成.
	/// </summary>
	private void createPaymentSound()
	{
		Instantiate(
			m_u_paymentSound,
			m_u_paymentSound.transform.position,
			m_u_paymentSound.transform.rotation
			);
	}
	private Rect GameStartRect
	{
		get{ return new Rect( 320, 380, 160, 60 ); }
	}
	
	
	private Rect RetryRect
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

	private bool IsNotPayment
	{
		get{ return PlayerData.Payment <= 0; }
	}
	
	/// <summary>
	/// 残りトランプUI.
	/// </summary>
	public GameObject m_u_uiRemainTrump;
	
	/// <summary>
	/// レートUI.
	/// </summary>
	public UIRate m_u_uiRate;
	
	/// <summary>
	/// チップ剛体管理者.
	/// </summary>
	public RigidChipManager m_u_rigidChipManager;
	
	/// <summary>
	/// 掛け金サウンド.
	/// </summary>
	public GameObject m_u_paymentSound;
	
	/// <summary>
	/// 勝敗結果UI管理者.
	/// </summary>
	public UIResultManager m_u_uiResultManager;
}
