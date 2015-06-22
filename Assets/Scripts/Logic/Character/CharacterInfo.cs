using UnityEngine;
using System.Collections;

// this script has all the info needed for characters when they are being created

public class CharacterInfo : MonoBehaviour {

	// Variables

	// Pool of selectable player traits
	
	private string[] traitsSelection = { 	"People Person", "Marketing Master", "Organiser", "Opertunist", "Charming",
		"Greedy", "Spitful", "Alcoholic", "Reckless", "Seedy"};
	
	// Pool of random first and last names for employees
	
	private string[] randomFName = { "John", "Mike", "Carl", "Jim", "Conor", "Bob", "Tom",
		"Rachael", "Samantha", "Mary", "Ciara", "Jennifer", "Jane", "Sarah"};
	
	private string[] randomLName = {		" Power", " Sullivan", " Smith", " McCarthy", " White", " Rodrigue", " Jones",
		" Browne", " Butler", " Byrne", " Daly", " Kelly", " Harrington", " Jameson"};

	// get and set properties

	public string[] TraitsSelection {

		get{ return traitsSelection;}
		set{ traitsSelection = value;}
	}

	public string[] RandomFName {

		get{ return randomFName;}
		set{ randomFName = value;}
	}

	public string[] RandomLName {

		get{ return randomLName;}
		set{ randomLName = value;}
	}
	
} // class
