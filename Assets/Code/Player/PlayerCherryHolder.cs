using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCherryHolder
	:
	Damageable
{
	public override void Damage( int amount )
	{
		base.Damage( amount );

		int nCherries = CherryCounter.GetNCherries();
		int lostCherries = ( int )Mathf.Ceil( ( float )nCherries * hitLosePercent );

		cherryLossDropper.DropMultiple( transform.position,lostCherries );

		CherryCounter.LoseCherries( lostCherries,true );
	}

	[SerializeField] ItemDropper cherryLossDropper = null;

	[SerializeField] float hitLosePercent = 0.5f;
}
