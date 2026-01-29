using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupSpawn
	:
	MonoBehaviour
{
	void OnTriggerEnter2D( Collider2D coll )
	{
		if( coll.tag == "Player" && !spawned )
		{
			Instantiate( spawnPrefab,transform.position,Quaternion.identity );
			Destroy( gameObject );
			spawned = true;
		}
	}

	[SerializeField] GameObject spawnPrefab = null;

	bool spawned = false;
}
