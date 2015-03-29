using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour {
	
	
	/// <summary>
	/// デフォルトのスクリーンサイズ.
	/// </summary>
	public static Vector2 DEFAULT_SCREEN = new Vector2( 800.0f, 480.0f );
	
	/// <summary>
	/// トランプ最大数.
	/// </summary>
	public const int TRUMP_MAX = 52;
	
	/// <summary>
	/// エース.
	/// </summary>
	public const int ACE = 1;
	
	/// <summary>
	/// ジャック.
	/// </summary>
	public const int JACK = 11;
	
	/// <summary>
	/// クイーン.
	/// </summary>
	public const int QUEEN = 12;
	
	/// <summary>
	/// キング.
	/// </summary>
	public const int KING = 13;
}
