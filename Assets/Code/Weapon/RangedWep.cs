using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWep
	:
	MonoBehaviour
{
	void Start()
	{
		cam = Camera.main;
	}

	void Update()
	{
		if( refire.Update() && Input.GetAxis( "Attack" ) > 0.0f )
		{
			refire.Reset();

			var proj = Instantiate( projectilePrefab,transform.position,Quaternion.identity );
			var mousePos = cam.ScreenToWorldPoint( Input.mousePosition );
			var shotDir = mousePos - transform.position;
			shotDir.z = 0.0f;
			proj.GetComponent<Rigidbody2D>().AddForce( shotDir.normalized * launchForce +
				Vector3.up * launchUpForce,ForceMode2D.Impulse );
		}
	}

	Camera cam;

	[SerializeField] GameObject projectilePrefab = null;
	[SerializeField] float launchForce = 10.0f;
	[SerializeField] float launchUpForce = 3.0f;
	[SerializeField] Timer refire = new Timer( 0.7f );
}
