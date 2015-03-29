using UnityEngine;
using System.Collections;
using System;

public class Utility : MonoBehaviour {
	
	/// <summary>
	/// スクリーンをマトリックスにして返す.
	/// </summary>
	/// <returns>
	/// The screen matrix.
	/// </returns>
	/// <param name='screen'>
	/// Screen.
	/// </param>
	public static Matrix4x4 getScreenMatrix( Vector2 screen )
	{
		return Matrix4x4.TRS(
			Vector3.zero,
			Quaternion.identity,
			new Vector3( Screen.width / screen.x, Screen.height / screen.y, 1 )
			);
	}
	/// <summary>
	/// Gets the screenスクリーンをマトリックスにして返す.
	/// </summary>
	/// <returns>
	/// The screen matrix.
	/// </returns>
	public static Matrix4x4 getScreenMatrix()
	{
		return getScreenMatrix( Global.DEFAULT_SCREEN );
	}
	/// <summary>
	/// 一番目の引数がminとmaxの間であるか？.
	/// 値がminを含めていたら真を返す
	/// </summary>
	/// <returns>
	/// <c>true</c> if this instance is between minimum and max the specified value min max; otherwise, <c>false</c>.
	/// </returns>
	/// <param name='value'>
	/// If set to <c>true</c> value.
	/// </param>
	/// <param name='min'>
	/// If set to <c>true</c> minimum.
	/// </param>
	/// <param name='max'>
	/// If set to <c>true</c> max.
	/// </param>
	public static bool IsBetweenMinAndMax( int value, int min, int max )
	{
		return value >= min && value < max;
	}
	
	public static float sin( float angle )
	{
		return (float)Math.Sin( angle );
	}
}
