using UnityEngine;
using System.Collections;

class UIHowtoDoubleUpFrame : UIHowtoFrame {
	
	protected override void depot ()
	{
		PlayerData.PlayMode = PlayerData.DOUBLE_UP_MODE;
	}
}
