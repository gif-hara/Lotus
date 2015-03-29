using UnityEngine;
using System.Collections;

public class DoubleUpChoiseTrump : MonoBehaviour {
	
	/// <summary>
	/// 選択したトランプの受け入れ.
	/// </summary>
	/// <param name='obj'>
	/// Object.
	/// </param>
	public void acceptChoiseTrump( GameObject obj )
	{
		m_choiseTrump = obj;
		m_u_doubleUpSceneManager.wait( 1.0f );
	}
	/// <summary>
	/// 選択したトランプを返す.
	/// </summary>
	/// <value>
	/// The choise trump.
	/// </value>
	public GameObject ChoiseTrump
	{
		get{ return m_choiseTrump; }
	}
	/// <summary>
	/// 選択が終了しているか？.
	/// </summary>
	/// <value>
	/// <c>true</c> if this instance is end choise; otherwise, <c>false</c>.
	/// </value>
	public bool IsEndChoise
	{
		get{ return ChoiseTrump != null; }
	}
	
	/// <summary>
	/// ダブルアップシーン管理者.
	/// </summary>
	public DoubleUpSceneManager m_u_doubleUpSceneManager;
	
	/// <summary>
	/// 選択したトランプ保持.
	/// </summary>
	private GameObject m_choiseTrump;
}
