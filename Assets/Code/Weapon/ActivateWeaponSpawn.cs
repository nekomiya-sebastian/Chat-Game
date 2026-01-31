using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWeaponSpawn
	:
	ActivateWeapon
{
	void Start()
	{
		spawnSpot = transform.Find( "SpawnSpot" );
	}

	public override void Activate()
	{
		base.Activate();

		Instantiate( spawnPrefab,spawnSpot.position,Quaternion.identity );
	}

	Transform spawnSpot = null;

	[SerializeField] GameObject spawnPrefab = null;
}
