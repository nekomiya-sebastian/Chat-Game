using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageProjectile
	:
	DamageBox
{
	void OnCollisionEnter2D( Collision2D coll )
	{
		DealDamage( coll.transform );
		Destroy( gameObject );
	}
}
