using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampireHunter
	:
	MonoBehaviour
{
	void Start()
	{
		animCtrl = GetComponent<Animator>();
	}

	void OnCollisionEnter2D( Collision2D coll )
	{
		var enemyVampScr = coll.gameObject.GetComponent<Vampire>();
		if( enemyVampScr ) animCtrl.SetTrigger( "stab" );
	}

	Animator animCtrl;
}
