using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryItemPickup
	:
	ItemPickup
{
	protected override void OnPickup()
	{
		base.OnPickup();

		CherryCounter.CollectCherries( cherryValue );
	}

	[SerializeField] int cherryValue = 1;
}
