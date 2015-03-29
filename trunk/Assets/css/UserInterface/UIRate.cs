using UnityEngine;
using System.Collections;

public class UIRate : MonoBehaviour {
	
	void Start()
	{
		changeRateValue();
	}
	/// <summary>
	/// 掛け金による勝利金額の表示.
	/// </summary>
	public void changeRateValue()
	{
		m_u_rateText.text = getRateString();
	}
	/// <summary>
	/// 全ての勝利パターンの金額を文字列として返す.
	/// </summary>
	/// <returns>
	/// The rate string.
	/// </returns>
	private string getRateString()
	{
		string result = string.Empty;
		
		for( int i=Dealer.MAX_LEVEL; i>=0; --i )
		{
			result += getRateString( i );
		}
		
		return result;
	}
	/// <summary>
	/// レベルによる勝利パターンの金額を文字列として返す.
	/// </summary>
	/// <returns>
	/// The rate string.
	/// </returns>
	/// <param name='level'>
	/// Level.
	/// </param>
	private string getRateString( int level )
	{
		if( level == Dealer.MAX_LEVEL )
		{
			return "   " + Dealer.getBetweenValue( level ) + "   : $" + Dealer.getWinPayment( level ) + "\n";
		}
		int min = Dealer.getBetweenValue( level );
		int max = Dealer.getBetweenValue( level + 1 ) - 1;
		int winMoney = Dealer.getWinPayment( level );

		return "" + min + "~" + max + " : $" + winMoney + "\n";
	}
	
	/// <summary>
	/// レート文字列.
	/// </summary>
	public GUIText m_u_rateText;
}
