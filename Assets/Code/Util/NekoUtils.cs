using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

public static class NekoUtils
{
	public static bool Chance()
	{
		return( Random.Range( 0.0f,1.0f ) < 0.5f );
	}

	public static void ShuffleArr<T>( List<T> arr )
	{
		int ind = arr.Count;

		while( ind > 0 )
		{
			int curInd = ( int )Mathf.Floor( Random.Range( 0.0f,1.0f ) * ( float )ind-- );

			T temp = arr[ind];
			arr[ind] = arr[curInd];
			arr[curInd] = temp;
		}
	}

	public static T ArrayChooseRand<T>( T[] items )
	{
		return( items[Random.Range( 0,items.Length )] );
	}
	public static T ListChooseRand<T>( List<T> items )
	{
		return( items[Random.Range( 0,items.Count )] );
	}

	public static Vector3 GetRandSpot( BoxCollider area )
	{
		Assert.IsNotNull( area );

		var extents = area.size / 2.0f;
		var randPoint = new Vector3(
			Random.Range( -1.0f,1.0f ) * extents.x,
			Random.Range( -1.0f,1.0f ) * extents.y,
			Random.Range( -1.0f,1.0f ) * extents.z
			);
		return( area.transform.TransformPoint( randPoint ) );
	}

	public static Vector3 RandVec3( float randVariation = 1.0f )
	{
		return( new Vector3(
			Random.Range( -1.0f,1.0f ) * randVariation,
			Random.Range( -1.0f,1.0f ) * randVariation,
			Random.Range( -1.0f,1.0f ) * randVariation ) );
	}

	public static void ItemExplosion( GameObject itemPrefab,float itemRadius,int quantity,
		float upForce,float sideForce,Vector3 spawnPos )
	{
		for( int i = 0; i < quantity; ++i )
		{
			var item = GameObject.Instantiate( itemPrefab );
			
			var launchVec = new Vector3(
				Random.Range( -sideForce,sideForce ),
				upForce,
				Random.Range( -sideForce,sideForce ) );
			
			item.transform.position = spawnPos + launchVec.normalized * itemRadius * i;
			item.transform.up = launchVec;

			item.GetComponent<Rigidbody>().AddForce( launchVec,ForceMode.Impulse );
		}
	}

	public static bool IsWebBuild()
	{
		return( Application.platform == RuntimePlatform.WebGLPlayer );
	}

	public static float CalcJumpHeight( float yPos,float objTop )
	{
		float jumpHeight = objTop - yPos;
		if( jumpHeight > 0.0f ) return( Mathf.Sqrt( Mathf.Abs( jumpHeight * 2.0f * Physics.gravity.y ) ) );
		else return( 0.0f );
	}

	// remove the "field is assigned but value is never used" compiler warnings on build
	// doing it this way cuz I want to keep them for debug, but don't want to lock each one behind a #if
	// cuz it might mess with the serializefield var order & I want as much consistency between editor &
	//  build as possible & preemptively prevent any possibilities of hard to track bugs
	public static void FakeUseBool( bool var )
	{
		Assert.IsTrue( var || !var );
	}
	public static void FakeUseInt( int var )
	{
		Assert.IsTrue( var == 0 || var != 0 );
	}
}
