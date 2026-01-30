using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollBoss
	:
	AIMove
{
	protected override void Start()
	{
		base.Start();

		animCtrl = GetComponent<Animator>();
		player = Globals.Get().Player;

		club.SetActive( false );
		stone.SetActive( false );
	}

	protected override void Update()
	{
		// no call base update

		if( !groundPoundRest.Update() ) return;

		var playerDiff = player.transform.position - transform.position;
		bool playerInClubRange = ( playerDiff.sqrMagnitude < Mathf.Pow( attackRange,2 ) );
		stone.SetActive( !playerInClubRange );
		club.SetActive( playerInClubRange );
		if( playerInClubRange )
		{
			animCtrl.SetTrigger( "groundPound" );
			groundPoundRest.Reset();
			LookDir( ( player.position.x > transform.position.x ? 1 : -1 ) );
		}
		else if( stoneRefire.Update() )
		{
			stoneRefire.Reset();

			var stoneProj = Instantiate( stoneProjectilePrefab,stone.transform.position,
				Quaternion.Euler( 0.0f,0.0f,Random.Range( 0.0f,360.0f ) ) );
			var throwDir = Mathf.Sign( playerDiff.x );
			stoneProj.GetComponent<Rigidbody2D>().AddForce( new Vector2(
				throwDir * stoneThrowForceRange.RandFloat(),
				stoneUpForceRange.RandFloat() ),ForceMode2D.Impulse );
		}

		Move( playerDiff.normalized );
	}

	Animator animCtrl;
	Transform player;

	[SerializeField] float attackRange = 4.5f;
	[SerializeField] Timer groundPoundRest = new Timer( 3.0f );

	[SerializeField] Timer stoneRefire = new Timer( 2.5f );
	[SerializeField] RangeF stoneThrowForceRange = new RangeF( 1.0f,5.0f );
	[SerializeField] RangeF stoneUpForceRange = new RangeF( 1.0f,5.0f );

	[SerializeField] GameObject club = null;
	[SerializeField] GameObject stone = null;
	[SerializeField] GameObject stoneProjectilePrefab = null;
}
