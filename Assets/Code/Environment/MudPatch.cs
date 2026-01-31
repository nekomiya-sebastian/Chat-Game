using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudPatch
	:
	MonoBehaviour
{
	void OnTriggerEnter2D( Collider2D coll )
	{
		var rb = coll.GetComponent<Rigidbody2D>();
		if( rb ) rb.drag += dragAdd;
	}

	void OnTriggerExit2D( Collider2D coll )
	{
		var rb = coll.GetComponent<Rigidbody2D>();
		if( rb ) rb.drag -= dragAdd;
	}

	[SerializeField] float dragAdd = 25.0f;
}
