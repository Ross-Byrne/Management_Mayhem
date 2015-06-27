using UnityEngine;
using System.Collections;

public class Player : Person {

	// Variables
	
	//Inherits public string name; from Person
	public string Name { 
		get{ return name;} 
		set{ name = value;}
	}
	public float BankAccount { get; set; }
	[SerializeField]
	private string[] traits = new string[5]; // string array to store 5 player traits
	public string[] Traits {

		get { return traits;}
		set { traits = value;}
	}

	// Methods
	
	void Awake(){

		Name = "Player";
	} // Awake()

} // class
