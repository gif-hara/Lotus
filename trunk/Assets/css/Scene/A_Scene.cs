using UnityEngine;
using System.Collections;

public class A_Scene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	/// <summary>
	/// 待機時間の設定.
	/// </summary>
	/// <param name='waitTime'>
	/// Wait time.
	/// </param>
	public void wait( float waitTime )
	{
		m_waitTimer = waitTime;
	}
	/// <summary>
	/// ゲームを開始する.
	/// </summary>
	public virtual void gameStart()
	{
		m_isGameStart = true;
	}
	protected virtual void gameEnd()
	{
		if( m_isGameEnd )	return;
		
		m_isGameEnd = true;
	}

	/// <summary>
	/// ゲームがスタートしているか？.
	/// </summary>
	/// <value>
	/// <c>true</c> if this instance is game start; otherwise, <c>false</c>.
	/// </value>
	public virtual bool IsGameStart
	{
		get{ return m_isGameStart; }
	}
	/// <summary>
	/// 実行出来るか？.
	/// </summary>
	/// <value>
	/// <c>true</c> if this instance is execute; otherwise, <c>false</c>.
	/// </value>
	protected bool IsExecute
	{
		get{ return m_waitTimer <= 0.0f; }
	}

	
	/// <summary>
	/// ゲームスタートフラグ.
	/// </summary>
	protected bool m_isGameStart;
	
	/// <summary>
	/// ゲームエンドフラグ.
	/// </summary>
	protected bool m_isGameEnd;
	
	/// <summary>
	/// 待機時間.
	/// </summary>
	protected float m_waitTimer;
}
