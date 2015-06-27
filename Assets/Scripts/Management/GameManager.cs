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
	public Player playerScript;
	public Business businessScript;
	public DisplayText displayScript;

	// Variables

	public char gameDifficulty;
	public bool isNewGameCreated = false;
	public bool isGameLoaded = false;
	public bool canHireDealers = false;
	public bool canBuildDrugLab = false;
	public bool canStartSellingDrugs = false;
	public bool canStartMakingDrugs = false;
	public bool appliedForGrant = false;

	// New Game info - for saving bewteen scenes
	[SerializeField]
	public string PName { get; set;}
	[SerializeField] 							// to show in editor
	private string[] pTraits = new string[5];
	public string[] PTraits {
		get{ return pTraits;}
		set{ pTraits = value;}
	}
	public string BName { get; set;}
	public char GDif { get; set;}

	// Methods

	// Initialisation
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

		/*// display the players name on output text
		displayScript.ShowText ("Player's Name: " + playerScript.name);
		Save ();
		Load ();*/
	} // Awake()
	
	// Update is called once per frame
	void Update () {
		//displayScript.ShowText ("Player's Name: " + playerScript.playerName);
	} // Update()


	// runs when a Scene is loaded
	void OnLevelWasLoaded(int level){

		// if scene loaded is Main Scene
		if (level == 1) {

			// if a new game has been created, setup variables
			if(isNewGameCreated == true){

				// set the players new name to players name
				Debug.Log(playerScript.Name);
				playerScript.Name = PName;
				Debug.Log(playerScript.Name);

				// set the players selected traits to players traits
				for(int i = 0; i < 5; i++){

					playerScript.Traits[i] = PTraits[i];
				} // for

				// set players business name to business name
				businessScript.Name = BName;

				// set players selected game dif to gameDifficulty
				gameDifficulty = GDif;

			} // if

		} // if

	} // OnLevelWasLoaded()

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
