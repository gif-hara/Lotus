using UnityEngine;
using System.Collections;

public abstract class UIHowtoFrame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		initPosition();
		initColor();
		guiTexture.pixelInset = ScreenRect;
	}
	
	// Update is called once per frame
	void Update () {
	
		move();
		//debugClick();
		touch();
		gradation();
	}
	/// <summary>
	/// 座標の初期化.
	/// </summary>
	private void initPosition()
	{
		transform.position = INIT_POSITION;
	}
	/// <summary>
	/// 色の初期化.
	/// </summary>
	private void initColor()
	{
		guiTexture.color = new Color(
			0.5f, 0.5f, 0.5f, 0.0f
			);
	}

	/// <summary>
	/// 展開処理.
	/// </summary>
	public void deployment()
	{
		PlayerData.PlayMode = PlayerData.HOW_TO_MODE;
	}
	/// <summary>
	/// 移動処理.
	/// </summary>
	private void move()
	{
		transform.position = Vector3.Lerp( transform.position, TargetPosition, MOVE_SPEED * Time.deltaTime );
	}
	/// <summary>
	/// タッチ処理.
	/// </summary>
	private void touch()
	{
		if( !PlayerData.isCurrentMode( PlayerData.HOW_TO_MODE ) )	return;
		if( Input.touchCount <= 0 )	return;
		
		Touch touch = Input.GetTouch( 0 );
		if( touch.phase != TouchPhase.Began )	return;
		
		depot();
	}
	/// <summary>
	/// エディターのみのクリック処理.
	/// </summary>
	private void debugClick()
	{
		if( !Application.isEditor )	return;
		if( !PlayerData.isCurrentMode( PlayerData.HOW_TO_MODE ) )	return;
		
		depot();
	}
	/// <summary>
	/// グラデーション処理.
	/// </summary>
	private void gradation()
	{
		Color myColor = guiTexture.color;
		float alpha = PlayerData.isCurrentMode( PlayerData.HOW_TO_MODE ) ? ALPHA_SPEED : -ALPHA_SPEED;
		myColor.a = Mathf.Max( Mathf.Min( myColor.a + (alpha * Time.deltaTime), 0.5f ), 0.0f );

		guiTexture.color = myColor;
	}
	/// <summary>
	/// スクリーン矩形を返す.
	/// </summary>
	/// <value>
	/// The screen rect.
	/// </value>
	private Rect ScreenRect
	{
		get{ return new Rect( 0, 0, Screen.width, Screen.height ); }
	}
	private bool IsDeployment
	{
		get{ return PlayerData.isCurrentMode( PlayerData.HOW_TO_MODE ); }
	}
	private Vector3 TargetPosition
	{
		get
		{
			if( IsDeployment )
			{
				return DEPLOYMENT_POSITION;
			}
			
			return INIT_POSITION;
		}
	}
	
	/// <summary>
	/// 格納処理.
	/// </summary>
	protected abstract void depot();
	
	/// <summary>
	/// 移動速度.
	/// </summary>
	private const float MOVE_SPEED = 16.0f;
	
	/// <summary>
	/// 透過色の変化速度.
	/// </summary>
	private const float ALPHA_SPEED = 1.6f;
	
	/// <summary>
	/// 初期座標.
	/// </summary>
	private static Vector3 INIT_POSITION = new Vector3( 0, 1, 1 );
	
	/// <summary>
	/// 展開座標.
	/// </summary>
	private static Vector3 DEPLOYMENT_POSITION = new Vector3( 0, 0, 1 );
}
