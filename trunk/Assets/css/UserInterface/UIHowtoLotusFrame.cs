using UnityEngine;
using System.Collections;

class UIHowtoLotusFrame : UIHowtoFrame {
	
	protected override void depot ()
	{
		PlayerData.PlayMode = PlayerData.LOTUS_MODE;
	}
}
