using UnityEngine;
using System.Collections;

class TouchAction : A_Action {
	
	public override void action ()
	{
	}
	
	void OnCollisionEnter( Collision collObj )
	{
		collisionHit( collObj );
	}
	
	void OnCollisionStay( Collision collObj )
	{
		collisionHit( collObj );
	}
	
	private void collisionHit( Collision collObj )
	{
		A_Action action = (A_Action)collObj.gameObject.GetComponent( "A_Action" );
		if( action == null )
		{
			return;
		}
		
		action.action();
		Destroy( gameObject );
	}
}
