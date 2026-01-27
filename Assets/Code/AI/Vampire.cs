using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampire
	:
	MonoBehaviour
{
	void Start()
	{
		body = GetComponent<Rigidbody2D>();
		animCtrl = GetComponent<Animator>();

		var dir = new Vector2( Random.Range( -1.0f,1.0f ),Random.Range( -1.0f,1.0f ) );
		body.AddForce( dir.normalized * bounceForce.RandFloat(),ForceMode2D.Impulse );
		UpdateXScale();
	}

	void OnCollisionEnter2D( Collision2D coll )
	{
		// var diff = coll.transform.position - transform.position;
		// body.AddForce( diff.normalized * bounceForce.RandFloat(),ForceMode2D.Impulse );
		
		UpdateXScale();

		var enemyVampScr = coll.gameObject.GetComponent<Vampire>();
		if( enemyVampScr )
		{
			if( enemyVampScr.isHunter )
			{
				Destroy( body );
				Destroy( GetComponent<BoxCollider2D>() );
				animCtrl.SetTrigger( "defeat" );
			}

			if( isHunter ) animCtrl.SetTrigger( "stab" );
		}
	}

	void UpdateXScale()
	{
		float xScale = transform.localScale.x;
		if( body.velocity.x > velLookThresh ) xScale = 1.0f;
		else if( body.velocity.x < velLookThresh ) xScale = -1.0f;
		var scale = transform.localScale;
		scale.x = xScale;
		transform.localScale = scale;
	}

	Rigidbody2D body;
	Animator animCtrl;

	[SerializeField] RangeF bounceForce = new RangeF( 0.7f,8.0f );
	const float velLookThresh = 0.2f;

	[SerializeField] bool isHunter = false;
}
