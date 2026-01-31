using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CherryTree
	:
	MonoBehaviour
{
	void Update()
	{
		if( Input.GetKeyDown( KeyCode.Space ) )
		{
			// spawn cherries :D
			SpawnCherries();
		}
	}

	void SpawnCherries()
	{
		int nCherries = randCherryAmount.RandInt();

		var cherrySpawnSpots = new Transform[cherrySpots.childCount];
		for( int i = 0; i < nCherries; ++i )
		{
			var cherry = Instantiate( cherryPrefab,
				cherrySpots.GetChild( Random.Range( 0,cherrySpots.childCount ) ).position,
				Quaternion.Euler( 0.0f,cherrySpawnAngleDev.RandFloat(),0.0f ) );
			cherry.GetComponent<Rigidbody2D>().AddForce( cherry.transform.up *
				cherryLaunchForceDev.RandFloat(),ForceMode2D.Impulse );
		}
	}

	[SerializeField] GameObject cherryPrefab = null;
	[SerializeField] Transform cherrySpots = null;
	[SerializeField] RangeI randCherryAmount = new RangeI( 1,20 + 1 );
	[SerializeField] RangeF cherrySpawnAngleDev = new RangeF( -45.0f,45.0f );
	[SerializeField] RangeF cherryLaunchForceDev = new RangeF( 1.0f,5.0f );
}
