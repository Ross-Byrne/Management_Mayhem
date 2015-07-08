using UnityEngine;
using System.Collections;
using System.Text; 			// to use StringBuilder

public class Player : Person {

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

	private string[] traits = new string[5]; // string array to store 5 player traits
	public string[] Traits {

		get { return traits;}
		set { traits = value;}
	}


	/*===================== Methods =====================================================================================*/

	/*===================== Awake() =====================================================================================*/
	
	void Awake(){

		// initialise variables
		Name = "Player";
		Gender = ' ';
		BankAccount = 1000f;
		Salary = 10f;			// $10/hr

	} // Awake()


	/*===================== DisplayPlayerInfo() =====================================================================================*/

	public string DisplayPlayerInfo(){

		StringBuilder str = new StringBuilder();

		// Add Players name
		str.Append ("Name: ").Append (Name);

		// Add players BankBalance
		str.Append ("\nBank Account: ").Append (string.Format("${0:00}", BankAccount));

		return str.ToString ();
	} // DisplayPlayerInfo()

} // class
