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

		StartCoroutine( DelayedStartRetarget() );
	}

	IEnumerator DelayedStartRetarget()
	{
		yield return( new WaitForEndOfFrame() );
		yield return( new WaitForEndOfFrame() );
		minResetInterval.Finish();
		Retarget();
	}

	protected override void Update()
	{
		base.Update();

		minResetInterval.Update();
		if( maxRetargetInterval.Update() )
		{
			maxRetargetInterval.Reset();
			Retarget();
		}

		Move( moveVec );
	}

	void OnCollisionEnter2D( Collision2D coll )
	{
		if( coll.contactCount > 0 ) Retarget();
	}

	void Retarget()
	{
		if( minResetInterval.IsDone() )
		{
			minResetInterval.Reset();
			maxRetargetInterval.Reset();

			var moveSpots = Globals.Get().AIMoveSpots;
			var target = moveSpots.GetChild( Random.Range( 0,moveSpots.childCount ) );
			moveVec = ( target.position - transform.position ).normalized * moveSpdRange.RandFloat();
		}
	}

	Vector3 moveVec = Vector3.zero;

	[SerializeField] RangeF moveSpdRange = new RangeF( 0.7f,1.3f );

	Timer minResetInterval = new Timer( 0.7f );
	Timer maxRetargetInterval = new Timer( 3.0f );
}
