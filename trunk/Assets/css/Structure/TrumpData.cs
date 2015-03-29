using UnityEngine;
using System.Collections;

public struct TrumpData {
	
	/// <summary>
	/// 初期化.
	/// </summary>
	/// <param name='number'>
	/// Number.
	/// </param>
	/// <param name='type'>
	/// Type.
	/// </param>
	public void initialize( int number, int type )
	{
		m_number = number + 1;
		m_type = type;
	}
	/// <summary>
	/// トランプの数値を返す.
	/// </summary>
	/// <value>
	/// The number.
	/// </value>
	public int Number
	{
		get{ return m_number; }
	}
	/// <summary>
	/// トランプのタイプを返す.
	/// </summary>
	/// <value>
	/// The type.
	/// </value>
	public int Type
	{
		get{ return m_type; }
	}
	/// <summary>
	/// 自分自身がNULLであるか？.
	/// </summary>
	/// <value>
	/// <c>true</c> if this instance is not null; otherwise, <c>false</c>.
	/// </value>
	public bool IsNull
	{
		get{ return m_number == 0; }
	}
	public override string ToString ()
	{
		return string.Format ("[TrumpData: Number={0}, Type={1}]", Number, Type);
	}
	
	private int m_number;
	
	private int m_type;
	
	public const int SPADE = 0;
	
	public const int CLOVER = 1;
	
	public const int DIAMOND = 2;
	
	public const int HEART = 3;
}
