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
		body.AddForce( dir * moveSpd,ForceMode2D.Force );

		UpdateXScale();
	}

	protected void UpdateXScale()
	{
		float xScale = transform.localScale.x;
		if( body.velocity.x > velLookThresh ) xScale = 1.0f;
		else if( body.velocity.x < velLookThresh ) xScale = -1.0f;
		var scale = transform.localScale;
		scale.x = xScale;
		transform.localScale = scale;
	}

	Rigidbody2D body;

	[SerializeField] float moveSpd = 5.0f;

	[SerializeField] float velDecay = 0.85f;
	
	const float velLookThresh = 0.2f;
}
