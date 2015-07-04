using UnityEngine;
using System.Collections;

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
	public static SaveGameManager saveGameManager;

	public Player playerScript;
	public static Business businessScript;


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
		saveGameManager = gameObject.GetComponent<SaveGameManager> ();
		playerScript = player.GetComponent<Player>();

		// if in Main Scene
		if (Application.loadedLevelName.Equals ("Main")) {


			// Wait until mainUI is read
			//StartCoroutine("WaitForMainUI");



			//uiManager.DisplayText(businessScript.PrintListOfEmployees());

		} // if


	} // Awake()


	/*===================== OnLevelWasLoaded() =====================================================================================*/

	// runs when a Scene is loaded, after Awake() has run
	void OnLevelWasLoaded(int level){

		// if scene loaded is Main Scene
		if (level == 1) {

			// if a new game has been created, setup variables
			if(IsNewGameCreated == true){

				StartCoroutine("SetupNewGame");
				Debug.Log("New game made");
		
			} else {
				Debug.Log("Starting to load game");
				// load last save Game
				StartCoroutine("SetupLoadedGame");

			}
		} // if
	} // OnLevelWasLoaded()
	

	/*===================== Update() =====================================================================================*/

	void Update(){

		// if in Main Scene
		if (Application.loadedLevelName.Equals ("Main")) {

			// update game information
			uiManager.InformationBarUpdate (playerScript, businessScript, "World Info");

		} // if

	} // Update()

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

		// set business bank account depending on game difficulty
		switch (GameDifficulty) {
		case 'E':	// Easy
			// if game is easy, you start with 100,000 in bank account
			businessScript.BankAccount = 100000;
			break;
		case 'N':	// Normal
			// if game is normal, you start with 50,000 in bank account
			businessScript.BankAccount = 50000;
			break;
		case 'H':	// Hard
			// if game is hard, you start with 10,000 in bank account
			businessScript.BankAccount = 10000;
			break;
		} // switch

		// Displays New Games info

	} // SetupNewGame()


	/*===================== SetupLoadedGame() =====================================================================================*/
	
	IEnumerator SetupLoadedGame()
	{
		// To make sure MainUI is set up first
		do{
			// Waits one frame
			yield return null;
			// loops while mainUI isn't finished being setup
		}while(!uiManager.IsMainUISetup);
		
		Debug.Log ("Loading Game");

		// Loads last saved game
		saveGameManager.Load ();

		Debug.Log ("Game Loaded");

	} // SetupLoadedGame()


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

	public void ResumeGame(){

		uiManager.ExitEscapeMenu ();
	} // ResumeGame()


	/*===================== SaveGame() =====================================================================================*/
	
	public void SaveGame(){

		// Saves game
		saveGameManager.Save ();

		// Tells player game is saved
		Debug.Log ("Game Saved!");

		// Resumes
		ResumeGame ();
	} // SaveGame()


	/*===================== LoadGame() =====================================================================================*/
	
	public void LoadGame(){
		
		// Saves game
		saveGameManager.Load ();
		
		// Tells player game is Loaded
		Debug.Log ("Game Loaded!");
		
		// Resumes
		ResumeGame ();
	} // LoadGame()


	/*===================== ExitToMainMenu() =====================================================================================*/

	public void ExitToMainMenu()
	{
		// loads StartMenu Scene (first scene)
		Application.LoadLevel (0);
	} // ExitToMainMenu()


	/*===================== CheckReputation() =====================================================================================*/
	
	// checks if player can do certain things because of reputation level
	public void CheckReputation(Business business)
	{
		if(business.Reputation > 39) // if at least -40 rep
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
		
		if(business.Reputation > 59) // if at least -60 rep
		{
			// can build drug lab
			CanBuildDrugLab = true;
		}
		else
		{
			// cannot build drug lab
			CanBuildDrugLab = false;
		} // if
		
	} // CheckReputation()

} // class

