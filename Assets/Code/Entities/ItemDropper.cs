using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemDropper
{
	public void RollDrop( Vector3 spawnPos )
	{
		if( dropItemPrefab && Random.Range( 0.0f,1.0f ) < dropChance ) SpawnItem( spawnPos );
	}

	public void DropMultiple( Vector3 spawnPos,int amount )
	{
		for( int i = 0; i < amount; ++i ) SpawnItem( spawnPos );
	}

	void SpawnItem( Vector3 spawnPos )
	{
		var drop = GameObject.Instantiate( dropItemPrefab,spawnPos,
			Quaternion.Euler( 0.0f,0.0f,itemSpawnAngleDev.RandFloat() ) );
		drop.GetComponent<Rigidbody2D>().AddForce( drop.transform.up *
			itemLaunchForceDev.RandFloat(),ForceMode2D.Impulse );
	}

	[SerializeField] GameObject dropItemPrefab = null;
	[SerializeField] float dropChance = 0.4f;
	[SerializeField] RangeF itemSpawnAngleDev = new RangeF( -45.0f,45.0f );
	[SerializeField] RangeF itemLaunchForceDev = new RangeF( 1.0f,5.0f );
}
