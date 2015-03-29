using UnityEngine;
using System.Collections;

public class TitleSceneManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		createBGM();
	}
	
	// Update is called once per frame
	void Update () {
		quit();
	}
	
	void OnGUI()
	{
		GUI.matrix = Utility.getScreenMatrix();
		
		gotoLotusScene();
		gotoTrumpTextureSelectScene();
	}
	/// <summary>
	/// ロータスシーン遷移処理.
	/// </summary>
	private void gotoLotusScene()
	{
		if( !GUI.Button( LotusButtonRect, "Game Start!" ) )	return;
		
		Application.LoadLevel( "LotusScene" );
	}
	/// <summary>
	/// 裏面画像変更シーン遷移処理.
	/// </summary>
	private void gotoTrumpTextureSelectScene()
	{
		if( !GUI.Button( TrumpTextureSelectButtonRect, "Texture Setting" ) )	return;
		
		Application.LoadLevel( "TrumpTextureSelectScene" );
	}
	/// <summary>
	/// ゲーム終了処理.
	/// </summary>
	private void quit()
	{
		if( !Input.GetKey( KeyCode.Escape ) )	return;
		
		Application.Quit();
	}
	/// <summary>
	/// BGMオブジェクトの生成.
	/// </summary>
	private void createBGM()
	{
		if( GameObject.Find( "BGM" ) != null )	return;
		
		((GameObject)Instantiate(
			m_u_bgm,
			m_u_bgm.transform.position,
			m_u_bgm.transform.rotation
			)).name = m_u_bgm.name;
	}
	/// <summary>
	/// ロータス遷移ボタンの矩形を返す.
	/// </summary>
	/// <value>
	/// The lotus button rect.
	/// </value>
	private Rect LotusButtonRect
	{
		get{ return new Rect( 80, 240, 160, 60 ); }
	}
	/// <summary>
	/// 裏面画像変更シーン遷移ボタンの矩形を返す.
	/// </summary>
	/// <value>
	/// The trump texture select button rect.
	/// </value>
	private Rect TrumpTextureSelectButtonRect
	{
		get{ return new Rect( 80, 320, 160, 60 ); }
	}
	
	/// <summary>
	/// BGMオブジェクト.
	/// </summary>
	public GameObject m_u_bgm;
}
