using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Timer
{
	public Timer( float duration )
	{
		this.duration = duration;
	}

	public bool Update( float dt )
	{
		if( curTime <= duration ) curTime += dt;

		return( IsDone() );
	}

	public bool Update()
	{
		return( Update( Time.deltaTime ) );
	}

	public bool UpdateIgnorePause()
	{
		Update( Time.deltaTime );
		return( IsDone( true ) );
	}

	public void Reset( bool preserveTime = false )
	{
		if( preserveTime ) curTime -= this.duration;
		else curTime = 0.0f;
	}

	public void Finish()
	{
		curTime = duration + 1.0f;
	}

	public void Randomize()
	{
		curTime = Random.Range( 0.0f,duration );
	}

	public void SetDuration( float dur )
	{
		duration = dur;
	}

	public void DivDur( float percent )
	{
		duration /= percent;
	}

	public void SetPercent( float percent )
	{
		curTime = duration * percent;
	}

	public bool IsDone( bool ignorePause = false )
	{
		return( curTime >= duration );
	}

	public float GetPercent()
	{
		return( Mathf.Min( curTime / duration,1.0f ) );
	}

	public float GetCurTime()
	{
		return( curTime );
	}

	public float GetDuration()
	{
		return( duration );
	}

	[SerializeField] float duration;
	float curTime = 0.0f;
}