﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class hud : MonoBehaviour {

	public Sprite[] HeartSprites;

	public Image HeartUI;
	private PlayerController player;

	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		HeartUI.sprite = HeartSprites[player.fVida];
	}
}
