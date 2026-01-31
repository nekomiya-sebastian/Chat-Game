using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterDelay
	:
	MonoBehaviour
{
	void Update()
	{
		if( destTimer.Update() ) Destroy( gameObject );
	}

	[SerializeField] Timer destTimer = new Timer( 1.0f );
}
