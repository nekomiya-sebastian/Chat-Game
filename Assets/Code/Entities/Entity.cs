using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Entity
	:
	MonoBehaviour
{
	protected virtual void Start()
	{
		body = GetComponent<Rigidbody2D>();
	}

	protected virtual void Update() {}

	void FixedUpdate()
	{
		body.velocity *= velDecay;
	}

	protected void Move( Vector3 dir )
	{
		const float dtOffset = 60.0f;
		body.AddForce( dir * moveSpd * Time.deltaTime * dtOffset,ForceMode2D.Force );

		LookDir( ( int )Mathf.Sign( dir.x ) );
	}

	public void LookDir( int dir )
	{
		Assert.IsTrue( Mathf.Abs( dir ) == 1 );
		
		var scale = transform.localScale;
		scale.x = dir;
		transform.localScale = scale;
	}

	Rigidbody2D body;

	[SerializeField] float moveSpd = 5.0f;

	[SerializeField] float velDecay = 0.85f;
	
	const float velLookThresh = 0.2f;
}
