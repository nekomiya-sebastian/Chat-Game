using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedItem
	:
	MonoBehaviour
{
	void Start()
	{
		dropY = transform.position.y;
	}

	void Update()
	{
		if( landStartTimer.Update() && transform.position.y < dropY + yBuffer && !done )
		{
			Destroy( GetComponent<Rigidbody2D>() );
			if( setTriggerOnLand ) GetComponent<Collider2D>().isTrigger = true;
			Destroy( this );
			done = true;
		}
	}

	float dropY;

	bool done = false;

	[SerializeField] bool setTriggerOnLand = false;

	Timer landStartTimer = new Timer( 0.3f );
	const float yBuffer = 0.5f;
}
