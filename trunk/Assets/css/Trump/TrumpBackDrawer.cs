using UnityEngine;
using System.Collections;

public class TrumpBackDrawer : MonoBehaviour {
	
	void Start()
	{
		renderer.material.mainTextureOffset = getTextureOffset();
	}
	
	private Vector2 getTextureOffset()
	{
		float x = PlayerData.BackTextureID * BACK_SIZE.x;
		
		return new Vector2( x, 0.0f );
	}
	
	/// <summary>
	/// 裏面のバリエーション数.
	/// </summary>
	public const int BACK_NUM = 10;
	
	private static Vector2 BACK_SIZE = new Vector2( 0.1f, 1.0f );
}
