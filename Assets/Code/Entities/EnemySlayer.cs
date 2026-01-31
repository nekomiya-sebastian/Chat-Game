using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlayer
	:
	MonoBehaviour
{
	void Start()
	{
		animCtrl = GetComponent<Animator>();
		selfEntity = GetComponent<Entity>();
	}

	void HandleCollision( Collision2D coll )
	{
		if( coll.gameObject.tag == "Enemy" )
		{
			animCtrl.SetTrigger( "stab" );
			int dir = ( int )Mathf.Sign( ( coll.transform.position - transform.position ).x );
			if( setDir ) selfEntity.LookDir( dir );
		}
	}
	void OnCollisionEnter2D( Collision2D coll )
	{
		HandleCollision( coll );
	}
	void OnCollisionStay2D( Collision2D coll )
	{
		HandleCollision( coll );
	}

	Animator animCtrl;
	Entity selfEntity;

	[SerializeField] bool setDir = true;
}
