﻿using UnityEngine;
using System.Collections;

public class Player : Person {

	// Variables
	
	//Inherits public string name; from Person
	public float bankAccount;
	public string[] traits = new string[5]; // string array to store 5 player traits

	// Methods
	
	void Awake(){

		name = "Player";
	} // Awake()

} // class
