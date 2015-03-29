using UnityEngine;
using System.Collections;

public class TrumpTextureSelectScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		createTrump();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{
		GUI.matrix = Utility.getScreenMatrix();
		arrowButton();
		decisionButton();
	}
	/// <summary>
	/// トランプオブジェクトの生成.
	/// </summary>
	private void createTrump()
	{
		destroyCurrentTrump();
		
		m_currentTrump = (GameObject)Instantiate(
			m_u_trump,
			Vector3.zero,
			Quaternion.AngleAxis( 0, Vector3.up )
			);
	}
	/// <summary>
	/// 現在あるトランプオブジェクトを削除.
	/// </summary>
	private void destroyCurrentTrump()
	{
		if( m_currentTrump == null )	return;
		
		Destroy( m_currentTrump );
	}
	/// <summary>
	/// 矢印ボタン処理.
	/// </summary>
	private void arrowButton()
	{
		if( GUI.Button( LeftButtonRect, "Back" ) )
		{
			PlayerData.BackTextureID -= 1;
			createTrump();
		}
		if( GUI.Button( RightButtonRect, "Next" ) )
		{
			PlayerData.BackTextureID += 1;
			createTrump();
		}
	}
	/// <summary>
	/// 決定ボタン処理.
	/// </summary>
	private void decisionButton()
	{
		if( !GUI.Button( DecisionButtonRect, "OK" ) )	return;
		
		Application.LoadLevel( "TitleScene" );
	}
	
	private Rect LeftButtonRect
	{
		get{ return new Rect( 160, 380, 160, 60 ); }
	}
	private Rect RightButtonRect
	{
		get{ return new Rect( 480, 380, 160, 60 ); }
	}
	private Rect DecisionButtonRect
	{
		get{ return new Rect( 340, 380, 120, 60 ); }
	}
	
	/// <summary>
	/// トランプオブジェクト.
	/// </summary>
	public GameObject m_u_trump;
	
	/// <summary>
	/// 現在あるトランプオブジェクト.
	/// </summary>
	private GameObject m_currentTrump;
}
