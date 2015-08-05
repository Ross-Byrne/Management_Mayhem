using UnityEngine;
using System.Collections;

// abstract person class to act as base for all people actors in game

public abstract class Person : MonoBehaviour {

	protected new string name;
	protected char gender;
	protected float bankAccount;
	protected float salary; 		// salary is hourly rate
	protected string position;
	 
} // class
