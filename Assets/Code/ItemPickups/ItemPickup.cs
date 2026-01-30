using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup
	:
	MonoBehaviour
{
	void OnTriggerEnter2D( Collider2D coll )
	{
		if( coll.tag == "Player" && !collected )
		{
			OnPickup();
			collected = true;
		}
	}

	protected virtual void OnPickup()
	{
		Destroy( gameObject );
	}

	bool collected = false;
}
