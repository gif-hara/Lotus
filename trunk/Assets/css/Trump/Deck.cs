using UnityEngine;
using System.Collections;

public class Deck : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		m_currentNumber = 0;
		initDeck();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	/// <summary>
	/// トランプを一枚引く.
	/// 描画では無い
	/// </summary>
	public TrumpData Draw()
	{
		if( m_deck.Length <= m_currentNumber )
		{
			return new TrumpData();
		}
		
		TrumpData data = m_deck[m_currentNumber];
		++m_currentNumber;
		return data;
	}
	
	private void initDeck()
	{
		m_deck = new TrumpData[Global.TRUMP_MAX];
		setTrumpData();
	}
	
	private void setTrumpData()
	{
		/*m_deck[0].initialize( 0, 0 );
		m_deck[1].initialize( 4, 0 );
		m_deck[2].initialize( 12, 0 );
		m_deck[3].initialize( 0, 0 );
		m_deck[4].initialize( 0, 0 );
		m_deck[5].initialize( 10, 1 );
		return;*/
		
		for( int i=0; i<4; i++ )
		{
			for( int j=0; j<13; ++j )
			{
				int address = Random.Range( 0, Global.TRUMP_MAX );
				//int address = ( i*13 ) + j;
				while( !m_deck[address].IsNull )
				{
					address = Random.Range( 0, Global.TRUMP_MAX );
				}
				
				m_deck[address].initialize( j, i );
			}
		}
	}
	/// <summary>
	/// デッキが全て無くなったか？.
	/// </summary>
	/// <value>
	/// <c>true</c> if this instance is all disappear; otherwise, <c>false</c>.
	/// </value>
	public bool IsAllDisappear
	{
		get{ return m_currentNumber >= Global.TRUMP_MAX; }
	}
	
	/// <summary>
	/// デッキ.
	/// </summary>
	private TrumpData[] m_deck;
	
	/// <summary>
	/// 現在の引かれた枚数.
	/// </summary>
	private int m_currentNumber;
}
