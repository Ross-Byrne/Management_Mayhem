using UnityEngine;
using System.Collections;

public class Employee : Person {

	/*===================== Variables =====================================================================================*/

	//Inherits string name from Person
	public string Name { 
		get{ return name;} 
		set{ name = value;}
	}
	
	// inherits char gender from Person
	public char Gender {
		get{ return gender;}
		set{ gender = value;}
	}
	
	// inherits float bankAccount from Person
	public float BankAccount { 
		get{ return bankAccount;} 
		set{ bankAccount = value;} 
	}
	
	// inherits float salary from Person
	public float Salary {
		get{ return salary;}
		set{ salary = value;}
	}

	private bool isDealer;
	public bool IsDealer {get; set;}


	/*===================== Methods =====================================================================================*/

	void Awake(){

		// initialise variables
		Name = "Employee"; 
		Gender = ' ';
		BankAccount = 500f;
		Salary = 10f;		// $10/hr
		IsDealer = false;
	} // Awake()

} // class
