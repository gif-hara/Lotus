using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour {

	// Use this for initialization
	void Start () {
		initHand();
	}
	
	// Update is called once per frame
	void Update () {
		
		if( PlayerData.isCurrentMode( PlayerData.HOW_TO_MODE ) )	return;
		if( !m_u_sceneManager.IsGameStart )	return;
		touch();
		debugClick();
		timeCreateHandTrump();
		doubleUpModeDisTrump();
		
		m_createTimer += Time.deltaTime;
	}
	/// <summary>
	/// ダブルアップモード時に出す捨てトランプ処理.
	/// </summary>
	private void doubleUpModeDisTrump()
	{
		if( !PlayerData.isCurrentMode( PlayerData.DOUBLE_UP_MODE ) )	return;
		if( IsAnyHandNull )	return;
		if( m_createTimer < CAN_CREATE_TIME )	return;
		if( !ObjectUtil.DisTrumpManagerScript.IsNullCurrentDisTrump )	return;
		
		GameObject disTrump = (GameObject)Instantiate(
			m_u_trump,
			getTrumpPosition( 2 ),
			m_u_trump.transform.rotation
			);
		disTrump.SendMessage( "initialize", m_u_deck.Draw() );
			
		ObjectUtil.DisTrumpManagerScript.acceptTrump( disTrump );
		Destroy( disTrump );
	}
	/// <summary>
	/// タッチ処理.
	/// </summary>
	private void touch()
	{
		if( Input.touchCount <= 0 )	return;
		
		Touch touch = Input.GetTouch( 0 );

		if( touch.phase != TouchPhase.Began )	return;
		
		Ray ray = m_u_mainCamera.ScreenPointToRay( getTouchPosition( touch ) );
		Instantiate(
			m_u_touchAction,
			getRayPosition( ray ),
			Quaternion.identity
			);
	}
	/// <summary>
	/// エディターのみで使用出来る、マウスでクリックした座標を表示する.
	/// </summary>
	private void debugClick()
	{
		if( !Application.isEditor )	return;
		if( !Input.GetMouseButtonDown( 0 ) )	return;
		
		Ray ray = m_u_mainCamera.ScreenPointToRay( Input.mousePosition );
		Instantiate(
			m_u_touchAction,
			getRayPosition( ray ),
			Quaternion.identity
			);

	}
	/// <summary>
	/// タッチされた座標を返す.
	/// </summary>
	/// <returns>
	/// The touch position.
	/// </returns>
	/// <param name='touch'>
	/// Touch.
	/// </param>
	private Vector3 getTouchPosition( Touch touch )
	{
		return new Vector3( touch.position.x, touch.position.y, 0 );
	}
	/// <summary>
	/// レイの座標を返す.
	/// </summary>
	/// <returns>
	/// The ray position.
	/// </returns>
	/// <param name='ray'>
	/// Ray.
	/// </param>
	private Vector3 getRayPosition( Ray ray )
	{
		return new Vector3( ray.origin.x, ray.origin.y, 0 );
	}
	/// <summary>
	/// 手札の初期化.
	/// </summary>
	private void initHand()
	{
		m_hand = new GameObject[5];
	}
	/// <summary>
	/// 時間による手札の生成処理.
	/// </summary>
	private void timeCreateHandTrump()
	{
		if( m_u_deck.IsAllDisappear )	return;
		if( m_createTimer < CAN_CREATE_TIME )	return;
		
		for( int i=0; i<m_hand.Length; ++i )
		{
			if( m_hand[i] == null )
			{
				createHandTrump( i );
				m_createTimer = 0.0f;
				m_u_sceneManager.wait( 1.0f );
				return;
			}
		}
	}
	/// <summary>
	/// 手札のトランプオブジェクトを生成する.
	/// </summary>
	private void createHandTrump( int id )
	{
		TrumpData trumpData = m_u_deck.Draw();
		if( trumpData.IsNull )
		{
			return;
		}
		
		m_hand[id] = (GameObject)Instantiate(
			m_u_trump,
			getTrumpPosition( id ),
			m_u_trump.transform.rotation
			);
		
		m_hand[id].SendMessage( "initialize", trumpData );
		m_hand[id].SendMessage( "acceptInitTargetPosition", getHandTrumpTargetPosition( id ) );
	}
	/// <summary>
	/// IDから座標を返す.
	/// </summary>
	/// <returns>
	/// The trump position.
	/// </returns>
	/// <param name='id'>
	/// Identifier.
	/// </param>
	private Vector3 getTrumpPosition( int id )
	{
		return new Vector3( 2.0f - id, -1.0f, 0.0f );
	}
	/// <summary>
	/// ハンドトランプの目標座標を返す.
	/// </summary>
	/// <returns>
	/// The hand trump target position.
	/// </returns>
	/// <param name='id'>
	/// Identifier.
	/// </param>
	private Vector3 getHandTrumpTargetPosition( int id )
	{
		return getTrumpPosition( id ) + new Vector3( 0.0f, 1.0f, 0.0f );
	}
	/// <summary>
	/// 手札のトランプドロワーを返す.
	/// </summary>
	/// <returns>
	/// The hand trump drawer.
	/// </returns>
	/// <param name='id'>
	/// Identifier.
	/// </param>
	private TrumpDrawer getHandTrumpDrawer( int id )
	{
		return (TrumpDrawer)m_hand[id].GetComponent( "TrumpDrawer" );
	}
	/// <summary>
	/// 引数番目の手札のトランプデータを返す.
	/// </summary>
	/// <returns>
	/// The hand trump data.
	/// </returns>
	/// <param name='id'>
	/// Identifier.
	/// </param>
	private TrumpData getHandTrumpData( int id )
	{
		return getHandTrumpDrawer( id ).GetTrumpData;
	}
	/// <summary>
	/// 引数のトランプオブジェクトは数値とタイプ共に手札のトランプと一致しないか？.
	/// </summary>
	/// <returns>
	/// The number and type only.
	/// </returns>
	/// <param name='trump'>
	/// If set to <c>true</c> trump.
	/// </param>
	public bool isNumberAndTypeOnly( GameObject trump )
	{
		int count = 0;
		for( int i=0; i<m_hand.Length; ++i )
		{
			if( m_hand[i] == null )	continue;
			
			TrumpData myTrumpData = ObjectUtil.getTrumpData( trump );
			TrumpData targetTrumpData = ObjectUtil.getTrumpData( m_hand[i] );
			if( myTrumpData.Number == targetTrumpData.Number || myTrumpData.Type == targetTrumpData.Type )
			{
				++count;
			}
		}
		
		/**
		 * 手札に引数のトランプオブジェクトがあるとすればカウントが１であるはず
		 * ちょっとややこしいけど・・・
		  * */
		return count == 1;
	}
	/// <summary>
	/// 手札のどれか一つでもNullなら真を返す.
	/// </summary>
	/// <value>
	/// <c>true</c> if this instance is any hand null; otherwise, <c>false</c>.
	/// </value>
	private bool IsAnyHandNull
	{
		get
		{
			for( int i=0; i<m_hand.Length; ++i )
			{
				if( m_hand[i] == null )	return true;
			}
			
			return false;
		}
	}
	/// <summary>
	/// ゲームが終了しているか？.
	/// </summary>
	/// <value>
	/// <c>true</c> if this instance is game end; otherwise, <c>false</c>.
	/// </value>
	public bool IsGameEnd
	{
		get
		{
			if( m_u_deck.IsAllDisappear )
			{
				return AllDissappearPattern;
			}
			
			return StillHavePattern;
		}
	}
	/// <summary>
	/// デッキにトランプが全て無い状態のゲーム終了条件.
	/// </summary>
	/// <value>
	/// <c>true</c> if all dissappear pattern; otherwise, <c>false</c>.
	/// </value>
	private bool AllDissappearPattern
	{
		get
		{
			for( int i=0; i<m_hand.Length; ++i )
			{
				if( m_hand[i] == null )	continue;
				if( ObjectUtil.DisTrumpManagerScript.isAccept( getHandTrumpData( i ) ) )
				{
					return false;
				}
			}
			
			return true;
		}
	}
	/// <summary>
	/// デッキにトランプがある状態のゲーム終了条件.
	/// </summary>
	/// <value>
	/// <c>true</c> if still have pattern; otherwise, <c>false</c>.
	/// </value>
	private bool StillHavePattern
	{
		get
		{
			for( int i=0; i<m_hand.Length; ++i )
			{
				if( m_hand[i] == null )	return false;
				if( ObjectUtil.DisTrumpManagerScript.isAccept( getHandTrumpData( i ) ) )
				{
					return false;
				}
			}
			
			return true;
		}
	}
	
	/// <summary>
	/// デッキ.
	/// </summary>
	public Deck m_u_deck;
	
	/// <summary>
	/// トランプオブジェクト.
	/// </summary>
	public GameObject m_u_trump;
	
	/// <summary>
	/// タッチアクションオブジェクト.
	/// </summary>
	public GameObject m_u_touchAction;
	
	/// <summary>
	/// メインカメラ.
	/// </summary>
	public Camera m_u_mainCamera;
	
	/// <summary>
	/// ゲームシーン管理者.
	/// </summary>
	public A_Scene m_u_sceneManager;
		
	/// <summary>
	/// 手札.
	/// </summary>
	private GameObject[] m_hand;
	
	private float m_createTimer = 0;
	
	private const float CAN_CREATE_TIME = 0.2f;
}
