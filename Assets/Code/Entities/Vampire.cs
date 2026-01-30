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

		itemDrop.RollDrop( transform.position );

		var dissipateParts = Instantiate( dissipatePartsPrefab,
			transform.Find( "PartSpawnPos" ).position,Quaternion.identity );
		Destroy( gameObject,dissipateParts.GetComponent<ParticleSystem>().main.duration );

		Destroy( this );
	}

	[SerializeField] ItemDropper itemDrop = null;

	[SerializeField] GameObject dissipatePartsPrefab = null;
}
