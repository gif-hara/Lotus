using UnityEngine;
using System.Collections;

public class HandTrump : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		initLotusMode();
		initDoubleUpMode();
	}
	
	// Update is called once per frame
	void Update () {
		if( PlayerData.isCurrentMode( PlayerData.HOW_TO_MODE ) )	return;
		
		move();
		rotate();
		gradation();
		inHandSendUIRemainTrump();
		m_timer += Time.deltaTime;
	}
	/// <summary>
	/// ロータスモード時の初期化処理.
	/// </summary>
	private void initLotusMode()
	{
		if( !PlayerData.isCurrentMode( PlayerData.LOTUS_MODE ) )	return;
	}
	/// <summary>
	/// ダブルアップモード時の初期化処理.
	/// </summary>
	private void initDoubleUpMode()
	{
		if( !PlayerData.isCurrentMode( PlayerData.DOUBLE_UP_MODE ) )	return;
		
		m_isRotate = false;
	}
	/// <summary>
	/// 目標座標の受け入れ.
	/// </summary>
	/// <param name='target'>
	/// Target.
	/// </param>
	private void acceptInitTargetPosition( Vector3 target )
	{
		m_targetPosition = target;
	}
	/// <summary>
	/// 回転フラグの受け入れ.
	/// </summary>
	/// <param name='flag'>
	/// Flag.
	/// </param>
	private void acceptRotateFlag( bool flag )
	{
		m_isRotate = flag;
	}
	/// <summary>
	/// 移動処理.
	/// </summary>
	private void move()
	{
		transform.position = Vector3.Lerp( transform.position, m_targetPosition, Time.deltaTime * MOVE_SPEED );
	}
	/// <summary>
	/// 回転処理.
	/// </summary>
	private void rotate()
	{
		if( !IsRotate )	return;
		
		transform.rotation = Quaternion.Lerp( transform.rotation, FORWARD_ANGLE, Time.deltaTime * ROTATE_SPEED );
	}
	/// <summary>
	/// グラデーション処理.
	/// </summary>
	private void gradation()
	{
		if( !PlayerData.isCurrentMode( PlayerData.LOTUS_MODE ) )	return;
		
		if( ObjectUtil.DisTrumpManagerScript.IsNullCurrentDisTrump ||
			!ObjectUtil.DisTrumpManagerScript.isAccept( ObjectUtil.getTrumpData( gameObject ) ) )
		{
			renderer.material.color = Color.white;
			return;
		}
		
		float t = Mathf.Abs( Utility.sin( m_timer * 6 ) );
		renderer.material.color = Color.Lerp( Color.white, Color.yellow, t );
	}
	private void inHandSendUIRemainTrump()
	{
		if( !PlayerData.isCurrentMode( PlayerData.LOTUS_MODE ) )	return;
		if( m_isInHandSend )	return;
		if( !IsInHandSend )	return;
		
		m_isInHandSend = true;
		ObjectUtil.UIRemainTrumpScript.inHand( ObjectUtil.getTrumpData( gameObject ) );
	}
	/// <summary>
	/// 回転しても良いか？.
	/// </summary>
	/// <value>
	/// <c>true</c> if this instance is rotate; otherwise, <c>false</c>.
	/// </value>
	private bool IsRotate
	{
		get{ return m_isRotate && Vector3.Distance( transform.position, m_targetPosition ) < CAN_ROTATE_DISTANCE; }
	}
	/// <summary>
	/// 手札に入ったことを知らせて良いか？.
	/// </summary>
	/// <value>
	/// <c>true</c> if this instance is in hand send; otherwise, <c>false</c>.
	/// </value>
	private bool IsInHandSend
	{
		get{ return Mathf.Abs( transform.rotation.eulerAngles.y ) > CAN_SEND_ROTATE; }
	}
	
	/// <summary>
	/// 汎用タイマー.
	/// </summary>
	private float m_timer = 0.0f;
	
	/// <summary>
	/// 目標座標.
	/// </summary>
	private Vector3 m_targetPosition;
	
	/// <summary>
	/// 手札に入ったことをUIRemainTrumpに知らせるフラグ.
	/// </summary>
	private bool m_isInHandSend = false;
	
	/// <summary>
	/// 回転フラグ.
	/// </summary>
	private bool m_isRotate = true;
	
	/// <summary>
	/// 移動速度.
	/// </summary>
	private const float MOVE_SPEED = 12.0f;
	
	/// <summary>
	/// 回転速度.
	/// </summary>
	private const float ROTATE_SPEED = 5.0f;
	
	/// <summary>
	/// 回転しても良い処理.
	/// </summary>
	private const float CAN_ROTATE_DISTANCE = 0.2f;
	
	/// <summary>
	/// UIRemainTrumpに知らせても良い角度.
	/// </summary>
	private const float CAN_SEND_ROTATE = 300.0f;
	
	/// <summary>
	/// 目標角度.
	/// </summary>
	private static Quaternion FORWARD_ANGLE = Quaternion.AngleAxis( 0, Vector3.up );
}
