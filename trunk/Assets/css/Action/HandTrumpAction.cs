using UnityEngine;
using System.Collections;

class HandTrumpAction : A_Action {
	
	/// <summary>
	/// アクション処理.
	/// </summary>
	public override void action ()
	{
		lotusModeAction();
		doubleUpModeAction();
	}
	/// <summary>
	/// ロータスモード時のアクション処理.
	/// </summary>
	private void lotusModeAction()
	{
		if( !PlayerData.isCurrentMode( PlayerData.LOTUS_MODE ) )	return;
		
		disTrump();
	}
	/// <summary>
	/// ダブルアップモード時のアクション処理.
	/// </summary>
	private void doubleUpModeAction()
	{
		if( !PlayerData.isCurrentMode( PlayerData.DOUBLE_UP_MODE ) )	return;
		if( ObjectUtil.DoubleUpChoiseTrumpScript.IsEndChoise )	return;

		gameObject.SendMessage( "acceptRotateFlag", true );
		ObjectUtil.DoubleUpChoiseTrumpScript.acceptChoiseTrump( gameObject );
		createDeploymentSound();
	}
	/// <summary>
	/// 捨てられるトランプであるか？.
	/// </summary>
	/// <returns>
	/// The dis trump.
	/// </returns>
	private bool isDisTrump()
	{
		return ObjectUtil.DisTrumpManagerScript.isAccept( m_u_drawer.GetTrumpData );
	}
	/// <summary>
	/// 自分自身を捨てトランプにする.
	/// </summary>
	private void disTrump()
	{
		if( !isDisTrump() )	return;
		
		ObjectUtil.DisTrumpManagerScript.acceptTrump( gameObject );
		++PlayerData.ComboCount;
		Destroy( gameObject );
		ObjectUtil.UIRemainTrumpScript.destroyRemainSphere( ObjectUtil.getTrumpData( gameObject ) );
	}
	
	private void createDeploymentSound()
	{
		Instantiate(
			m_u_deploymentSound,
			m_u_deploymentSound.transform.position,
			m_u_deploymentSound.transform.rotation
			);
	}
	/// <summary>
	/// 自分自身のトランプデータ.
	/// </summary>
	public TrumpDrawer m_u_drawer;
	
	/// <summary>
	/// ダブルアップモード時の展開した時のサウンドオブジェクト.
	/// </summary>
	public GameObject m_u_deploymentSound;
}
