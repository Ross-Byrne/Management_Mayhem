using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	/*===================== Variables =====================*/
	
	public string playerName;
	public float bankAccount;
	public string[] traits = new string[5]; // string array to store 5 player traits
	
	
	/*===================== Methods =====================*/


	void Start(){

		playerName = "Player";
	}
} // class
