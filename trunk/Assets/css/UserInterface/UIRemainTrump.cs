using UnityEngine;
using System.Collections;

public class UIRemainTrump : MonoBehaviour {

	// Use this for initialization
	void Start () {
		initRemainSpheres();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	/// <summary>
	/// 手札に入ったトランプのデータからスフィアオブジェクトの色を変える.
	/// </summary>
	/// <param name='data'>
	/// Data.
	/// </param>
	public void inHand( TrumpData data )
	{
		changeRemainSphereColor( data );
	}
	public void destroyRemainSphere( TrumpData data )
	{
		Destroy( m_remainObject[getID( data )] );
	}
	/// <summary>
	/// 残りトランプを示すスフィアオブジェクトの初期化.
	/// </summary>
	private void initRemainSpheres()
	{
		m_remainObject = new GameObject[Global.TRUMP_MAX];
		
		for( int i=0; i<4; ++i )
		{
			for( int j=0; j<13; ++j )
			{
				int id = (i * 13) + j;
				m_remainObject[id] = (GameObject)Instantiate(
					m_u_remainSphere,
					getPosition( j, i ),
					Quaternion.AngleAxis( 180, Vector3.up )
					);
				m_remainObject[id].transform.parent = transform;
			}
		}
	}
	private void changeRemainSphereColor( TrumpData data )
	{
		m_remainObject[getID( data )].renderer.material.color = Color.blue;
	}
	/// <summary>
	/// 残りトランプを示すスフィアオブジェクトの座標を返す.
	/// </summary>
	/// <returns>
	/// The position.
	/// </returns>
	/// <param name='x'>
	/// X.
	/// </param>
	/// <param name='y'>
	/// Y.
	/// </param>
	private Vector3 getPosition( int x, int y )
	{
		return m_u_remainSphere.transform.position + new Vector3( INTERVAL.x * x, INTERVAL.y * y, transform.position.z + 1 );
	}
	/// <summary>
	/// トランプデータからIDを返す.
	/// </summary>
	/// <returns>
	/// The I.
	/// </returns>
	/// <param name='data'>
	/// Data.
	/// </param>
	private int getID( TrumpData data )
	{
		return (data.Type * 13) + (data.Number - 1);
	}
	
	/// <summary>
	/// 残りトランプを示すスフィアオブジェクト.
	/// </summary>
	public GameObject m_u_remainSphere;
	
	private GameObject[] m_remainObject;
	
	private static Vector2 INTERVAL = new Vector2( -0.141f, -0.1416f );
}
