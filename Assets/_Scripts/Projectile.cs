﻿using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	[SerializeField]
	private WeaponType _type;

	// This public property masks the field _type and takes action when it is set
	public WeaponType type {
		get {
			return(_type);
		}
		set {
			SetType(value);
		}
	}

	public void Awake(){
		// Test to see whether this has passed off scren every 2 seconds
		InvokeRepeating ("CheckOffScreen", 2f, 2f);
	}

	public void SetType(WeaponType eType){
		// Set the _type
		_type = eType;
		WeaponDefinition def = Main.GetWeaponDefinition (_type);
		GetComponent<Renderer>().material.color = def.projectileColor;
	}

	void CheckOffscreen(){
		if (Utils.ScreenBoundsCheck (GetComponent<Collider>().bounds, BoundsTest.offScreen) != Vector3.zero) {
			Destroy (this.gameObject);
		}
	}
}
