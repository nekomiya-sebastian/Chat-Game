using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMove
	:
	Entity
{
	protected override void Start()
	{
		base.Start();

		moveVec = new Vector2( Random.Range( -1.0f,1.0f ),Random.Range( -1.0f,1.0f ) )
			.normalized * moveSpdRange.RandFloat();
		UpdateXScale();
	}

	protected override void Update()
	{
		base.Update();

		Move( moveVec );
	}

	void OnCollisionEnter2D( Collision2D coll )
	{
		if( coll.contactCount > 0 )
		{
			var diff = ( Vector2 )transform.position - coll.contacts[0].point;
			moveVec = diff.normalized * moveSpdRange.RandFloat();
			UpdateXScale();
		}
	}

	Vector3 moveVec = Vector3.zero;

	[SerializeField] RangeF moveSpdRange = new RangeF( 0.7f,1.3f );
}
