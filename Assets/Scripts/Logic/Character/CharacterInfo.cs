using UnityEngine;
using System.Collections;
using System.Text;					// for StringBuilder
using Random = UnityEngine.Random;	// to use random number generater

// this script has all the info needed for characters when they are being created

public class CharacterInfo : MonoBehaviour {

	/*===================== Variables =====================================================================================*/

	/*===================== Pool of selectable player traits =====================================================================================*/
	
	private string[] traitsSelection = { 	"People Person", "Marketing Master", "Organiser", "Opportunist", "Charming",
		"Greedy", "Spiteful", "Alcoholic", "Reckless", "Seedy"};


	/*===================== Pool of random first and last names for employees =====================================================================================*/
	
	private string[] randomFemaleFirstName = { "Rachael", "Samantha", "Mary", "Ciara", "Jennifer", "Jane", "Sarah"};

	private string[] randomMaleFirstName = { "John", "Mike", "Carl", "Jim", "Conor", "Bob", "Tom"};
	
	private string[] randomLastName = { " Power", " Sullivan", " Smith", " McCarthy", " White", " Rodrigue", " Jones",
		" Browne", " Butler", " Byrne", " Daly", " Kelly", " Harrington", " Jameson"};


	/*===================== Pool of Selectable Positions =====================================================================================*/

	private string[] employeePositions = { "Manager", "Engineer", "Lawyer", "Factory Worker", "Office Worker", "Dealer",
		"Chemist", "Chemical Engineer"};


	/*===================== Get and Set Properties =====================================================================================*/

	public string[] TraitsSelection {

		get{ return traitsSelection;}
		set{ traitsSelection = value;}
	}

	public string[] RandomFemaleFirstName {

		get{ return randomFemaleFirstName;}
		set{ randomFemaleFirstName = value;}
	}

	public string[] RandomMaleFirstName {
		
		get{ return randomMaleFirstName;}
		set{ randomMaleFirstName = value;}
	}

	public string[] RandomLastName {

		get{ return randomLastName;}
		set{ randomLastName = value;}
	}

	public string[] EmployeePositions {

		get{ return employeePositions;}
		set{ employeePositions = value;}
	}


	/*===================== Methods =====================================================================================*/

	/*===================== GenerateRandomName() =====================================================================================*/

	// Generates a random name
	public string GenerateRandomName(char gender)
	{
		StringBuilder randomName = new StringBuilder ();
		int rndValue;

		// get first name depending on gender
		if (gender == 'F') { // if female

			// Get a random index for a random first name
			rndValue = Random.Range (0, RandomFemaleFirstName.Length);

			// append random first name to name string
			randomName.Append(RandomFemaleFirstName [rndValue]);
		} else if (gender == 'M') {

			// Get a random index for a random first name
			rndValue = Random.Range (0, RandomMaleFirstName.Length);

			// append random first name to name string
			randomName.Append(RandomMaleFirstName [rndValue]);
		} // if

		// get random index for a random last name
		rndValue = Random.Range (0, RandomLastName.Length);

		// append random last name to name string
		randomName.Append(RandomLastName [rndValue]);

		// return the random name
		return randomName.ToString();
	} // GenerateRandomName()


	/*===================== GenerateRandomGender() =====================================================================================*/

	public char GenerateRandomGender(){
		int rndValue;
		char gender = ' ';

		rndValue = Random.Range (0, 2); // 0 = female, 1 = male

		switch (rndValue) {
		case 0: // Female
			
			gender = 'F';
			break;
		case 1: // Male

			gender = 'M'; 
			break;
		} // switch

		return gender;
	} // GenerateRandomGender()


	/*===================== GenerateEmployeePosition() =====================================================================================*/

	// gives employees a position when creating them.
	// if rep is at correct level, can hire dealers etc
	// Returns the position as a string
	public string GenerateEmployeePosition(int rep){
		int rndValue;

		// if Reputation is -20 or less
		if (rep <= -20) {

			// get random position including dealer
			rndValue = Random.Range (0, EmployeePositions.Length -2); // not including last 2 pos
		} else  if (rep <= -30) { // if Reputation is -30 or less

			// get random position including drug related ones
			rndValue = Random.Range (0, EmployeePositions.Length);
		} else { // if Not

			// just good positions
			rndValue = Random.Range(0, EmployeePositions.Length -3); // not including last 3 bad positions
		} // if

		// return the position selected
		return EmployeePositions[rndValue];

	} // GenerateEmployeePosition()

} // class
