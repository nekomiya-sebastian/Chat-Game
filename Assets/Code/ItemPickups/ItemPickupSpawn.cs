using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupSpawn
	:
	ItemPickup
{
	protected override void OnPickup()
	{
		base.OnPickup();
		
		Instantiate( spawnPrefab,transform.position,Quaternion.identity );
	}

	[SerializeField] GameObject spawnPrefab = null;
}
