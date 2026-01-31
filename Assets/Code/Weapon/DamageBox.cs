using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBox
	:
	MonoBehaviour
{
	void OnTriggerEnter2D( Collider2D coll )
	{
		DealDamage( coll.transform );
	}

	protected void DealDamage( Transform coll )
	{
		var dmgScr = coll.GetComponent<Damageable>();
		if( dmgScr ) dmgScr.Damage( damage );
	}

	[SerializeField] int damage = 1;
}
