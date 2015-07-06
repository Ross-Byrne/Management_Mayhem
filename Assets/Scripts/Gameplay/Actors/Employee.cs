using UnityEngine;
using System.Collections;

public class Employee : Person {

	/*===================== Variables =====================================================================================*/

	// Inherits public string name; from Person
	public string Name { 
		get{ return name;} 
		set{ name = value;}
	}


	/*===================== Methods =====================================================================================*/

	void Awake(){

		Name = "Employee"; 
	} // Awake()

} // class
