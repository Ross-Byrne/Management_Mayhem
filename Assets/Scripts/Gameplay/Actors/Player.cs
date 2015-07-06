using UnityEngine;
using System.Collections;
using System.Text; 			// to use StringBuilder

public class Player : Person {

	/*===================== Variables =====================================================================================*/
	
	//Inherits public string name; from Person
	public string Name { 
		get{ return name;} 
		set{ name = value;}
	}
	public float BankAccount { get; set; }
	private string[] traits = new string[5]; // string array to store 5 player traits
	public string[] Traits {

		get { return traits;}
		set { traits = value;}
	}


	/*===================== Methods =====================================================================================*/

	/*===================== Awake() =====================================================================================*/
	
	void Awake(){

		Name = "Player";
		BankAccount = 1000f;
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
