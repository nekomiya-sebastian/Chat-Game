using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

public class CherryCounter
	:
	MonoBehaviour
{
	void Start()
	{
		self = this;

		UpdateCherryText();
	}

	public static void CollectCherries( int amount )
	{
		self.nCherries += amount;

		self.UpdateCherryText();
	}

	public static void LoseCherries( int amount,bool safe = false )
	{
		if( amount > self.nCherries && !safe ) Assert.IsTrue( false );

		self.nCherries -= amount;
		if( self.nCherries < 0 ) self.nCherries = 0;
		self.UpdateCherryText();
	}

	public static int GetNCherries()
	{
		return( self.nCherries );
	}

	void UpdateCherryText()
	{
		cherryText.text = nCherries.ToString();
	}

	static CherryCounter self;

	[SerializeField] TMP_Text cherryText = null;

	int nCherries = 0;
}
