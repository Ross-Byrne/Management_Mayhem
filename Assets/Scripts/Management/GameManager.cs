using UnityEngine;
using System.Collections;
using System;											// For saving to file
using System.Runtime.Serialization.Formatters.Binary;	// For saving to file
using System.IO;										// For saving to file

// GameManager is a singlton.

public class GameManager : MonoBehaviour 
{
	/*===================== GameObjects =====================================================================================*/

	public GameObject uiManagerPrefab;
	public GameObject businessPrefab;

	public GameObject player;

	
	/*===================== Scripts =====================================================================================*/

	public static GameManager gameManager;
	public static UIManager uiManager;

	public Player playerScript;
	public static Business businessScript;
	public DisplayText displayScript;


	/*===================== Variables =====================================================================================*/

	public char GameDifficulty { get; set;}
	public bool IsNewGameCreated { get; set;}
	public bool IsGameLoaded { get; set;}
	public bool CanHireDealers { get; set;}
	public bool CanBuildDrugLab { get; set;}
	public bool CanStartSellingDrugs { get; set;}
	public bool CanStartMakingDrugs { get; set;}
	public bool AppliedForGrant { get; set;}

	// New Game info - for saving bewteen scenes
	public string PName { get; set;}
	private string[] pTraits = new string[5];
	public string[] PTraits {
		get{ return pTraits;}
		set{ pTraits = value;}
	}
	public string BName { get; set;}
	public char GDif { get; set;}


	/*===================== Methods =====================================================================================*/

	/*===================== Awake() =====================================================================================*/

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

		// Instanstiate UIManager 
		GameObject uiManagerObject = (GameObject)Instantiate (uiManagerPrefab);

		if (Application.loadedLevelName.Equals ("Main")) {

			// Instanstiate Business
			GameObject business = (GameObject)Instantiate (businessPrefab);

			// Get reference for script
			businessScript = business.GetComponent<Business>();
		}

		// get references for scripts
		uiManager = uiManagerObject.GetComponent<UIManager> ();
		playerScript = player.GetComponent<Player>();
		displayScript = GetComponent<DisplayText> ();

		// if in Main Scene
		if (Application.loadedLevelName.Equals ("Main")) {


			//Debug.Log ("Hiring Employees");
		//	businessScript.HireEmployees (gameManager, 2);

			// Wait until mainUI is read
			//StartCoroutine("WaitForMainUI");

			//uiManager.DisplayText(businessScript.PrintListOfEmployees());

		} // if


	} // Awake()


	/*===================== OnLevelWasLoaded() =====================================================================================*/

	// runs when a Scene is loaded, after Awake() has run
	void OnLevelWasLoaded(int level)
	{
		// if scene loaded is Main Scene
		if (level == 1) {

			// if a new game has been created, setup variables
			if(IsNewGameCreated == true){

				StartCoroutine("SetupNewGame");
			} // if
		} // if
	} // OnLevelWasLoaded()


	/*===================== SetupGame() =====================================================================================*/

	void SetupGame()
	{

	} // SetupGame()


	/*===================== SetupNewGame() =====================================================================================*/

	IEnumerator SetupNewGame()
	{
		// To make sure MainUI is set up first
		do{
			// Waits one frame
			yield return null;
			// loops while mainUI isn't finished being setup
		}while(!uiManager.IsMainUISetup);

		Debug.Log ("Starting New Game Setup");
		// set the players new name to players name
		playerScript.Name = PName;
		
		// set the players selected traits to players traits
		for(int i = 0; i < 5; i++){
			
			playerScript.Traits[i] = PTraits[i];
		} // for
		
		// set players business name to business name
		businessScript.Name = BName;
		
		// set players selected game dif to gameDifficulty
		GameDifficulty = GDif;

		// Displays New Games info
		uiManager.DisplayNewGameDetails (playerScript, businessScript, gameManager);

	} // SetupNewGame()


	/*===================== WaitForMainUI() =====================================================================================*/

	IEnumerator WaitForMainUI(){

		// To make sure MainUI is set up first
		do{
			// Waits one frame
			yield return null;
			// loops while mainUI isn't finished being setup
		}while(!uiManager.IsMainUISetup);
	} // WaitForMainUI()


	/*===================== ResumeGame() =====================================================================================*/

	public void ResumeGame()
	{
		uiManager.ExitEscapeMenu ();
	} // ResumeGame()


	/*===================== ExitToMainMenu() =====================================================================================*/

	public void ExitToMainMenu()
	{
		// loads StartMenu Scene (first scene)
		Application.LoadLevel (0);
	} // ExitToMainMenu()


	/*===================== CheckBadReputation() =====================================================================================*/
	
	// checks if player can do bad things because of bad rep level
	public void CheckBadReputation(Business business)
	{
		if(business.Reputation > 39) // if at least 40 bad rep
		{
			// player can hire dealers
			CanHireDealers = true;
		}
		else
		{
			// if you cant sell, you cant hire and all dealers a fired
			CanHireDealers = false;
			CanStartSellingDrugs = false;
			//business.dealers.Clear();
		} // if
		
		if(business.Reputation > 59) // if at least 60 bad rep
		{
			// can build drug lab
			CanBuildDrugLab = true;
		}
		else
		{
			// cannot build drug lab
			CanBuildDrugLab = false;
		} // if
		
	} // CheckBadReputation()

	/*===================== Save() =====================================================================================*/

	// Save Data to file
	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

		PlayerData data = new PlayerData ();
		data.health = 100;
		data.experience = 1000;

		bf.Serialize (file, data);
		file.Close ();
	} // Save()


	/*===================== Load() =====================================================================================*/

	// Load data from file
	public void Load()
	{
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


/*===================== PlayerData Class =====================================================================================*/
[Serializable]
class PlayerData
{
	public float health;
	public float experience;
} // class
