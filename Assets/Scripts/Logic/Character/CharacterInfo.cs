using UnityEngine;
using System.Collections;
using System.Text;					// for StringBuilder
using Random = UnityEngine.Random;	// to use random number generater

// this script has all the info needed for characters when they are being created

public class CharacterInfo : MonoBehaviour {

	// Variables

	// Pool of selectable player traits
	
	private string[] traitsSelection = { 	"People Person", "Marketing Master", "Organiser", "Opportunist", "Charming",
		"Greedy", "Spiteful", "Alcoholic", "Reckless", "Seedy"};
	
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


	/*===================== Methods =====================================================================================*/

	/*===================== GenerateRandomName() =====================================================================================*/

	// Generates a random name
	public string GenerateRandomName()
	{
		StringBuilder randomName = new StringBuilder ();
		int rndValue;

		// Get a random index for a random first name
		rndValue = Random.Range (0, RandomFName.Length);

		// append random first name to name string
		randomName.Append(RandomFName [rndValue]);

		// get random index for a random last name
		rndValue = Random.Range (0, RandomLName.Length);

		// append random last name to name string
		randomName.Append(RandomLName [rndValue]);

		// return the random name
		return randomName.ToString();
	} // GenerateRandomName()
	
} // class
