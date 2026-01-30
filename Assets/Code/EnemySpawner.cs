using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner
	:
	MonoBehaviour
{
	void Start()
	{
		spawnRate = new Timer( spawnRateRange.RandFloat() );
	}

	void Update()
	{
		if( spawnRate.Update() )
		{
			spawnRate.SetDuration( spawnRateRange.RandFloat() );
			spawnRate.Reset();

			for( int i = 0; i < curEnemies.Count; ++i )
			{
				if( !curEnemies[i] ) curEnemies.RemoveAt( i-- );
			}

			if( curEnemies.Count < maxEnemies )
			{
				curEnemies.Add( Instantiate( enemyPrefab,transform.position,Quaternion.identity ) );
			}
		}
	}

	[SerializeField] GameObject enemyPrefab = null;
	[SerializeField] RangeF spawnRateRange = new RangeF( 3.0f,7.0f );
	Timer spawnRate;
	[SerializeField] int maxEnemies = 5;

	List<GameObject> curEnemies = new List<GameObject>();
}
