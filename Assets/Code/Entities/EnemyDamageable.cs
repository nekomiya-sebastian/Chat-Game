using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class EnemyDamageable
	:
	Damageable
{
	public override void Damage( int amount )
	{
		base.Damage( amount );

		hp -= amount;

		if( hp <= 0 && !defeated )
		{
			defeated = true;
			Defeat();
		}
	}

	void Defeat()
	{
		Destroy( GetComponent<Rigidbody2D>() );
		Destroy( GetComponent<BoxCollider2D>() );
		Destroy( GetComponent<AIMove>() );
		GetComponent<Animator>().SetTrigger( "defeat" );

		itemDrop.RollDrop( transform.position );

		var partSpawnPos = transform.Find( "PartSpawnPos" );
		var partSpawnLoc = ( partSpawnPos ? partSpawnPos.position : transform.position );
		var dissipateParts = Instantiate( defeatPartsPrefab,partSpawnLoc,Quaternion.identity );
		Destroy( gameObject,dissipateParts.GetComponent<ParticleSystem>().main.duration );

		Destroy( this );
	}

	bool defeated = false;

	[SerializeField] int hp = 1;

	[SerializeField] ItemDropper itemDrop = null;
	[SerializeField] GameObject defeatPartsPrefab = null;
}
