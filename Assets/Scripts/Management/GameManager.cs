using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// GameObjects

	public GameObject player;
	public GameObject business;

	// Scripts

	private Player playerScript;
	private Business businessScript;
	private DisplayText displayScript;

	// Variables

	private string gameDifficulty;
	private bool isCharacterCreated = false;
	private bool isBusinessSetup = false;
	private bool isNewGameCreated = false;
	private bool isGameLoaded = false;
	private bool canHireDealers = false;
	private bool canBuildDrugLab = false;
	private bool canStartSellingDrugs = false;
	private bool canStartMakingDrugs = false;
	private bool appliedForGrant = false;

	// Pool of selectable player traits

	private string[] playerTraitsSelection = { 	"People Person", "Marketing Master", "Organiser", "Opertunist", "Charming",
		"Greedy", "Spitful", "Alcoholic", "Reckless", "Seedy"};

	// Pool of random first and last names for employees

	private string[] randomFName = { "John", "Mike", "Carl", "Jim", "Conor", "Bob", "Tom",
		"Rachael", "Samantha", "Mary", "Ciara", "Jennifer", "Jane", "Sarah"};
	
	private string[] randomLName = {		" Power", " Sullivan", " Smith", " McCarthy", " White", " Rodrigue", " Jones",
		" Browne", " Butler", " Byrne", " Daly", " Kelly", " Harrington", " Jameson"};

	// Methods

	// Initialization
	void Awake () 
	{
		// get references for scripts
		playerScript = player.GetComponent<Player>();
		businessScript = business.GetComponent<Business>();
		displayScript = GetComponent<DisplayText> ();


		displayScript.ShowText ("Player's Name: " + playerScript.playerName);
	} // Start()
	
	// Update is called once per frame
	void Update () {
		//displayScript.ShowText ("Player's Name: " + playerScript.playerName);
	} // 


}
