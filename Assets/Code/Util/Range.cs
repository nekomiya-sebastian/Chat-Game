using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RangeF
{
	public RangeF( float min,float max )
	{
		this.min = min;
		this.max = max;
	}

	public float RandFloat()
	{
		return( Random.Range( min,max ) );
	}

	public float GetLerpVal( float amount )
	{
		if( amount < 0.0f ) amount = 0.0f;
		else if( amount > 1.0f ) amount = 1.0f;
		
		return( ( max - min ) * amount + min );
	}

	[SerializeField] public float min;
	[SerializeField] public float max;
}

[System.Serializable]
public class RangeI
{
	public RangeI( int min,int max )
	{
		this.min = min;
		this.max = max;
	}

	public int RandInt()
	{
		return( Random.Range( min,max ) );
	}

	public int GetLerpVal( int amount )
	{
		if( amount < 0 ) amount = 0;
		else if( amount > 1 ) amount = 1;
		
		return( ( max - min ) * amount + min );
	}

	[SerializeField] public int min;
	[SerializeField] public int max;
}
