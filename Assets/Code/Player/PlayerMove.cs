using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove
	:
	Entity
{
	protected override void Update()
	{
		base.Update();

		var move = new Vector2(
			Input.GetAxis( "Horizontal" ),
			Input.GetAxis( "Vertical" )
			);
		if( move.sqrMagnitude > 0.0f )
		{
			move.Normalize();
			Move( move );

			UpdateXScale();
		}
	}
}
