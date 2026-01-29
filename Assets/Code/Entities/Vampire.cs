using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampire
	:
	AIMove
{
	void OnCollisionEnter2D( Collision2D coll )
	{
		if( coll.gameObject.GetComponent<VampireHunter>() != null ) VampireDefeat();
	}

	void VampireDefeat()
	{
		Destroy( GetComponent<Rigidbody2D>() );
		Destroy( GetComponent<BoxCollider2D>() );
		GetComponent<Animator>().SetTrigger( "defeat" );

		if( Random.Range( 0.0f,1.0f ) < dropChance )
		{
			var drop = Instantiate( dropItemPrefab,transform.position,
				Quaternion.Euler( 0.0f,itemSpawnAngleDev.RandFloat(),0.0f ) );
			drop.GetComponent<Rigidbody2D>().AddForce( drop.transform.up *
				itemLaunchForceDev.RandFloat(),ForceMode2D.Impulse );

		}

		Destroy( this );
	}

	[SerializeField] GameObject dropItemPrefab = null;
	[SerializeField] float dropChance = 0.4f;
	[SerializeField] RangeF itemSpawnAngleDev = new RangeF( -45.0f,45.0f );
	[SerializeField] RangeF itemLaunchForceDev = new RangeF( 1.0f,5.0f );
}
