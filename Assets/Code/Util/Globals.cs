using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals
	:
	MonoBehaviour
{
	void Awake()
	{
		self = this;
	}

	public static Globals Get()
	{
		return( self );
	}

	static Globals self;

	[SerializeField] public Transform Player = null;

	[SerializeField] public Transform AIMoveSpots = null;
}
