using UnityEngine;
using System.Collections;
using System;											// For saving to file
using System.Runtime.Serialization.Formatters.Binary;	// For saving to file
using System.IO;										// For saving to file

// GameManager is a singlton.

public class GameManager : MonoBehaviour {

	// GameObjects

	public GameObject player;
	public GameObject business;

	// Scripts

	public static GameManager gameManager;
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
		// to make sure only one version of GameManager exisits
		// to enforce singlton patern
		if (gameManager == null) {
			DontDestroyOnLoad (gameObject);
			gameManager = this;
		} else if (gameManager != this) {
			Destroy(gameObject);
		} // if

		// get references for scripts
		playerScript = player.GetComponent<Player>();
		businessScript = business.GetComponent<Business>();
		displayScript = GetComponent<DisplayText> ();

		// display the players name on output text
		displayScript.ShowText ("Player's Name: " + playerScript.name);
		Save ();
		Load ();
	} // Awake()
	
	// Update is called once per frame
	void Update () {
		//displayScript.ShowText ("Player's Name: " + playerScript.playerName);
	} // Update()

	// Save Data to file
	public void Save(){

		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

		PlayerData data = new PlayerData ();
		data.health = 100;
		data.experience = 1000;

		bf.Serialize (file, data);
		file.Close ();
	} // Save()

	// Load data from file
	public void Load(){

		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize(file);
			file.Close();

			// copy data from PlayerData class to local variables
			displayScript.ShowText("Health: " + data.health + " Exp: " + data.experience);
		} // if
	} // Load()
	
} // class

[Serializable]
class PlayerData
{
	public float health;
	public float experience;
} // class
