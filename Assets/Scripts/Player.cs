using UnityEngine;
using System.Collections;

/* This is the class that handles the characters details */

public class Player : MonoBehaviour {

	/*===================== Member Variables =====================*/

	public string PlayerName { get; set;}
	public float bankAccount;
	public string[] traits = {"", "", "", "", ""}; // string array to store 5 player traits

	
	/*===================== Methods =====================*/
	 
	
	/*===================== get/setTraits() =====================*/
	
	public void setTraits(int index, string trait)
	{
		traits[index] = trait;
	} // setTraits()
	
	// getTraits() is overloaded
	// returns traits number entered
	public string getTraits(int index)
	{
		string trait="";
		
		trait = traits[index];
		
		return trait;
	} // getTraits()
	
	// if no number is entered, all traits are returned
	public string getTraits()
	{
		string tempTraits="";
		int i=0;
		
		for(i=0; i<5; ++i)
			tempTraits += traits[i] + "\n\t";
		
		return tempTraits;
	} // getTraits()
	
	/*===================== embezzleGrant() =====================*/

	public void embezzleGrant(float amount)
	{
		// adds the amount of money the player wants to embezzle to their account
		bankAccount += bankAccount + amount;
	} // embezzleGrant()
	
	/*===================== displayPlayerInfo() =====================*/
	
	public string displayPlayerInfo()
	{
		string str="";
		
		str += "\nName: " + PlayerName +
			"\nPersonal Bank Account: €" + bankAccount +
				"\nTraits: " + getTraits();
		
		return str;
	} // displayePlayerInfo()

} // Class
