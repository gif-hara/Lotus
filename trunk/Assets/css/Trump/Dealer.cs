using UnityEngine;
using System.Collections;

public class Dealer {
	
	/// <summary>
	/// ロータスゲームの掛け金処理.
	/// </summary>
	public void paymentLotus()
	{
		if( IsLotusPlayerWin != PLAYER_WIN )
		{
			PlayerData.Payment = 0;
			return;
		}
		
		PlayerData.Payment = getWinPayment( getLevel() );
	}
	/// <summary>
	/// ダブルアップモード時の掛け金処理.
	/// </summary>
	/// <param name='isWin'>
	/// Is window.
	/// </param>
	public void paymentDoubleUp()
	{
		if( IsDoubleUpJudge == PLAYER_DRAW )	return;
		
		if( IsDoubleUpJudge == PLAYER_LOSE )
		{
			PlayerData.Payment = 0;
			return;
		}
		
		PlayerData.Payment *= 2;
	}
	/// <summary>
	/// 掛け金レートを返す.
	/// </summary>
	/// <returns>
	/// The rate.
	/// </returns>
	/// <param name='level'>
	/// Level.
	/// </param>
	public static float getRate( int level )
	{
		float rate = 2;
		for( int i=0; i<level; ++i )
		{
			rate *= 2.4f;
		}
		
		return 1.0f + (rate / 10.0f);
	}
	/// <summary>
	/// コンボカウントによるレベルを返す.
	/// </summary>
	/// <returns>
	/// The level.
	/// </returns>
	private int getLevel()
	{
		for( int i=0; i<MAX_LEVEL; ++i )
		{
			if( Utility.IsBetweenMinAndMax( PlayerData.ComboCount, getBetweenValue( i ), getBetweenValue( i+1 ) ) )
			{
				return i;
			}
		}
		
		return MAX_LEVEL;
	}
	/// <summary>
	/// 勝利時の金額を返す.
	/// </summary>
	/// <returns>
	/// The window payment.
	/// </returns>
	/// <param name='level'>
	/// Level.
	/// </param>
	public static int getWinPayment( int level )
	{
		return (int)(PlayerData.Payment * getRate( level ));
	}
	/// <summary>
	/// 掛け金の倍数適用値を返す.
	/// </summary>
	/// <returns>
	/// The between value.
	/// </returns>
	/// <param name='id'>
	/// Identifier.
	/// </param>
	public static int getBetweenValue( int id )
	{
		int[] between = {
			10,
			13,
			16,
			20,
			22,
			26,
			30,
			33,
			37,
			40,
			44,
			48,
			52
		};
		
		return between[id];
	}
	/// <summary>
	/// ダブルアップの特殊な勝利パターンであるか？.
	/// </summary>
	/// <returns>
	/// The unique jadge.
	/// </returns>
	/// <param name='disTrump'>
	/// If set to <c>true</c> dis trump.
	/// </param>
	private static bool isUniqueJadge( TrumpData disTrump )
	{
		return disTrump.Number == Global.KING || disTrump.Number == Global.ACE;
	}
	/// <summary>
	/// ダブルアップの特殊な勝利パターンを返す.
	/// </summary>
	/// <returns>
	/// The jadge.
	/// </returns>
	/// <param name='choiseTrump'>
	/// If set to <c>true</c> choise trump.
	/// </param>
	/// <param name='disTrump'>
	/// If set to <c>true</c> dis trump.
	/// </param>
	private static bool uniqueJadge( TrumpData choiseTrump, TrumpData disTrump )
	{
		return
			disTrump.Number == Global.KING && choiseTrump.Number == Global.ACE ||
			disTrump.Number == Global.ACE && choiseTrump.Number == Global.KING;
	}
	/// <summary>
	/// ダブルアップモードにて引き分けであるか？.
	/// </summary>
	/// <returns>
	/// The double up draw.
	/// </returns>
	/// <param name='choiseTrump'>
	/// If set to <c>true</c> choise trump.
	/// </param>
	/// <param name='disTrump'>
	/// If set to <c>true</c> dis trump.
	/// </param>
	private static bool isDoubleUpDraw( TrumpData choiseTrump, TrumpData disTrump )
	{
		return choiseTrump.Number == disTrump.Number;
	}
	/// <summary>
	/// ロータスでプレイヤーが勝利しているか？.
	/// </summary>
	/// <value>
	/// <c>true</c> if this instance is player window; otherwise, <c>false</c>.
	/// </value>
	public static int IsLotusPlayerWin
	{
		get{ return (PlayerData.ComboCount >= getBetweenValue( 0 )) ? PLAYER_WIN : PLAYER_LOSE; }
	}
	/// <summary>
	/// ダブルアップでの勝敗結果を返す.
	/// </summary>
	/// <value>
	/// <c>true</c> if this instance is double up player window; otherwise, <c>false</c>.
	/// </value>
	public static int IsDoubleUpJudge
	{
		get
		{
			TrumpData choiseTrump = ObjectUtil.getTrumpData( ObjectUtil.DoubleUpChoiseTrumpScript.ChoiseTrump );
			TrumpData disTrump = ObjectUtil.getTrumpData( ObjectUtil.DisTrumpManagerScript.CurrentDisTrump );
			
			if( isDoubleUpDraw( choiseTrump, disTrump ) )	return PLAYER_DRAW;
			
			if( isUniqueJadge( disTrump ) )
			{
				return uniqueJadge( choiseTrump, disTrump ) ? PLAYER_WIN : PLAYER_LOSE;
			}
			
			return (disTrump.Number < choiseTrump.Number) ? PLAYER_WIN : PLAYER_LOSE;
		}
	}
	
	/// <summary>
	/// レベルの最大値.
	/// </summary>
	public const int MAX_LEVEL = 12;
	
	public const int PLAYER_WIN = 1;
	
	public const int PLAYER_LOSE = 0;
	
	public const int PLAYER_DRAW = 2;
}
