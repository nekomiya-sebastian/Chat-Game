using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimHandler
	:
	MonoBehaviour
{
	void Start()
	{
		if( weapon )
		{
			hasWep = true;
			hitbox = weapon.GetComponentInChildren<Collider2D>();
			hitbox.enabled = false;
			activateWep = weapon.GetComponent<ActivateWeapon>();
		}
	}

	public void EnableHitbox()
	{
		if( hasWep ) hitbox.enabled = true;
	}
	public void DisableHitbox()
	{
		if( hasWep ) hitbox.enabled = false;
	}

	public void ActivateWeapon()
	{
		activateWep?.Activate();
	}

	bool hasWep;
	[SerializeField] GameObject weapon = null;
	Collider2D hitbox;
	ActivateWeapon activateWep = null;
}
