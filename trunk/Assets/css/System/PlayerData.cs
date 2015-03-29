using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour {
	
	public static void initialize()
	{
		initMoney();
		firstMoney();
		initComboCount();
		initPayment();
		initBonusCount();
	}
	/// <summary>
	/// 初回プレイ時の所持金初期化処理.
	/// </summary>
	private static void firstMoney()
	{
		if( PlayCount != 0 )	return;
		
		Money = INIT_MONEY;
	}
	/// <summary>
	/// 所持金の初期化.
	/// </summary>
	private static void initMoney()
	{
		if( Money > 10 )	return;
		
		Money = INIT_MONEY;
	}
	/// <summary>
	/// 連続捨て札数の初期化.
	/// </summary>
	private static void initComboCount()
	{
		ComboCount = 0;
	}
	/// <summary>
	/// 掛け金の初期化.
	/// </summary>
	private static void initPayment()
	{
		Payment = 0;
	}
	/// <summary>
	/// ボーナス回数の初期化.
	/// </summary>
	private static void initBonusCount()
	{
		m_s_mediationCount = 0;
		m_s_continuityCount = 0;
		m_s_challengerCount = 0;
	}
	/// <summary>
	/// 現在のモードと引数のモードが一致しているか？.
	/// </summary>
	/// <returns>
	/// The current mode.
	/// </returns>
	/// <param name='mode'>
	/// If set to <c>true</c> mode.
	/// </param>
	public static bool isCurrentMode( int mode )
	{
		return m_s_playMode == mode;
	}
	/// <summary>
	/// ダブルアップシーンへ移行するときの処理.
	/// </summary>
	public static void migratingDoubleUpScene()
	{
	}
	/// <summary>
	/// ハーフアップシーンへ移行するときの処理.
	/// </summary>
	public static void migratingHalfUpScene()
	{
		PlayerData.Money += PlayerData.Payment / 2;
		PlayerData.Payment /= 2;
	}
	/// <summary>
	/// ロータスシーンへ移行するときの処理.
	/// </summary>
	public static void migratingLotusScene()
	{
		PlayerData.Money += PlayerData.Payment;
	}
	/// <summary>
	/// ボーナスによる掛け金増加処理.
	/// </summary>
	/// <param name='bonusPattern'>
	/// Bonus pattern.
	/// </param>
	public static void bonusPayment( int bonusPattern )
	{
		if( bonusPattern == BONUS_MEDIATION )
		{
			++m_s_mediationCount;
			Payment += ( m_s_mediationCount * ADD_MEDIATION );
		}
		else if( bonusPattern == BONUS_CONTINUITY )
		{
			++m_s_continuityCount;
			Payment += ( m_s_continuityCount * ADD_CONTINUITY );
		}
		else if( bonusPattern == BONUS_CHALLENGER )
		{
			++m_s_challengerCount;
			Payment *= 2;
		}
	}
	/// <summary>
	/// 現在のモードを返す.
	/// </summary>
	/// <value>
	/// The play mode.
	/// </value>
	public static int PlayMode
	{
		set
		{
			m_s_playMode = value;
		}
		get
		{
			return m_s_playMode;
		}
	}
	/// <summary>
	/// プレイ回数プロパティ.
	/// </summary>
	/// <value>
	/// The play count.
	/// </value>
	public static int PlayCount
	{
		set
		{
			PlayerPrefs.SetInt( PlayCountString, value );
		}
		get
		{
			return PlayerPrefs.GetInt( PlayCountString );
		}
	}
	/// <summary>
	/// 所持金プロパティ.
	/// </summary>
	/// <value>
	/// The money.
	/// </value>
	public static int Money
	{
		set
		{
			PlayerPrefs.SetInt( MoneyString, value );
		}
		get
		{
			return PlayerPrefs.GetInt( MoneyString );
		}
	}
	/// <summary>
	/// 裏面画像IDプロパティ.
	/// </summary>
	/// <value>
	/// The back texture I.
	/// </value>
	public static int BackTextureID
	{
		set
		{
			int id = Mathf.Max( Mathf.Min( value, TrumpBackDrawer.BACK_NUM - 1 ), 0 );
			PlayerPrefs.SetInt( BackTextureString, id );
			
		}
		get
		{
			return PlayerPrefs.GetInt( BackTextureString );
		}
	}
	/// <summary>
	/// 掛け金プロパティ.
	/// </summary>
	/// <value>
	/// The payment.
	/// </value>
	public static int Payment
	{
		set
		{
			m_s_payment = value;
		}
		get
		{
			return m_s_payment;
		}
	}
	/// <summary>
	/// 連続捨て札数プロパティ.
	/// </summary>
	/// <value>
	/// The combo count.
	/// </value>
	public static int ComboCount
	{
		set
		{
			m_s_comboCount = value;
		}
		get
		{
			return m_s_comboCount;
		}
	}
	/// <summary>
	/// ゲームオーバーであるか？.
	/// </summary>
	/// <value>
	/// <c>true</c> if this instance is game over; otherwise, <c>false</c>.
	/// </value>
	public static bool IsGameOver
	{
		get{ return Money < 10; }
	}
	/// <summary>
	/// 所持金のキーを返す.
	/// </summary>
	/// <value>
	/// The money string.
	/// </value>
	public static string MoneyString
	{
		get{ return "Money"; }
	}
	/// <summary>
	/// プレイ回数のキーを返す.
	/// </summary>
	/// <value>
	/// The play count string.
	/// </value>
	public static string PlayCountString
	{
		get{ return "PlayCount"; }
	}
	/// <summary>
	/// 裏面画像IDのキーを返す.
	/// </summary>
	/// <value>
	/// The back texture string.
	/// </value>
	public static string BackTextureString
	{
		get{ return "BackTextureID"; }
	}

	/// <summary>
	/// プレイモード.
	/// </summary>
	private static int m_s_playMode = LOTUS_MODE;
	
	/// <summary>
	/// 掛け金.
	/// </summary>
	private static int m_s_payment;
	
	/// <summary>
	/// 連続捨て札数.
	/// </summary>
	private static int m_s_comboCount;
	
	/// <summary>
	/// 橋渡し成功回数.
	/// </summary>
	private static int m_s_mediationCount;
	
	/// <summary>
	/// タイプ連続捨て成功回数.
	/// </summary>
	private static int m_s_continuityCount;
	
	/// <summary>
	/// チャレンジャー成功回数.
	/// </summary>
	private static int m_s_challengerCount;
	
	/// <summary>
	/// 初期所持金.
	/// </summary>
	private const int INIT_MONEY = 1000;
	
	/// <summary>
	/// ロータスモード.
	/// </summary>
	public const int LOTUS_MODE = 0;
	
	/// <summary>
	/// ダブルアップモード.
	/// </summary>
	public const int DOUBLE_UP_MODE = 1;
	
	/// <summary>
	/// 説明書展開モード.
	/// </summary>
	public const int HOW_TO_MODE = 2;
	
	/// <summary>
	/// 橋渡しボーナス.
	/// </summary>
	public const int BONUS_MEDIATION = 0;
	
	/// <summary>
	/// タイプ連続捨てボーナス.
	/// </summary>
	public const int BONUS_CONTINUITY = 1;
	
	/// <summary>
	/// チャレンジャーボーナス.
	/// </summary>
	public const int BONUS_CHALLENGER = 2;
	
	/// <summary>
	/// 橋渡し成功時に加算される数値.
	/// </summary>
	private const int ADD_MEDIATION = 2;
	
	/// <summary>
	/// タイプ連続捨て成功時に加算される数値.
	/// </summary>
	private const int ADD_CONTINUITY = 10;
	
	/// <summary>
	/// チャレンジャー成功時に加算される数値.
	/// </summary>
	private const int ADD_CHALLENGER = 5;
}
