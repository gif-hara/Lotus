using UnityEngine;
using System.Collections;

class HowtoAction : A_Action {
	
	public override void action ()
	{
		m_u_uiHowtoFrame.deployment();
	}
	
	public UIHowtoFrame m_u_uiHowtoFrame;
}
