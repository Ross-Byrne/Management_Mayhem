using UnityEngine;
using System.Collections;

// GameManager is a singleton.

public class GameManager : MonoBehaviour 
{
	/*===================== GameObjects =====================================================================================*/

	public GameObject uiManagerPrefab;
	public GameObject businessPrefab;
	public GameObject playerPrefab;

	
	/*===================== Scripts =====================================================================================*/

	public static GameManager gameManager = null;
	public static UIManager uiManager;
	public static SaveGameManager saveGameManager;

	public static Player playerScript;
	public static Business businessScript;


	/*===================== Variables =====================================================================================*/

	public bool gameRunning = false;
	public float gameSpeed = 1f;

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
	void Awake () {
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

		// If in Main Scene
		if (Application.loadedLevelName.Equals ("Main")) {

			// Instanstiate Business
			GameObject business = (GameObject)Instantiate (businessPrefab);

			// Instantiate Player
			GameObject player = (GameObject)Instantiate (playerPrefab);

			// Get reference for script
			businessScript = business.GetComponent<Business>();
			playerScript = player.GetComponent<Player>();
		} // if

		// get references for scripts
		uiManager = uiManagerObject.GetComponent<UIManager> ();
		saveGameManager = gameObject.GetComponent<SaveGameManager> ();

		// if in Main Scene
		if (Application.loadedLevelName.Equals ("Main")) {


		} // if


	} // Awake()


	/*===================== OnLevelWasLoaded() =====================================================================================*/

	// runs when a Scene is loaded, after Awake() has run
	void OnLevelWasLoaded(int level){

		// if scene loaded is Main Scene
		if (level == 1) {

			// Because GameManager is a singleton, when the main gameManager
			// destroys a new gameManger, both OnLevelWasLoaded() get run
			// this if makes sure only the main gameManager runs its code
			if(gameManager == this){

				// Sets up the game
				SetupGame();
			} // if
		} // if
	} // OnLevelWasLoaded()
	

	/*===================== Update() =====================================================================================*/

	void Update(){

		// if in Main Scene
		if (Application.loadedLevelName.Equals ("Main")) {

			// update game information

			// Update player info
			uiManager.mainUI.GetComponent<MainUIControl>().PlayerInformationUpdate(playerScript);

			// update business info
			uiManager.mainUI.GetComponent<MainUIControl>().BusinessInformationUpdate(businessScript);

			// update world info
			//uiManager.mainUI.GetComponent<MainUIControl>().WorldInformationUpdate(0f, 0f);

		} // if

	} // Update()


	/*===================== Update() =====================================================================================*/

	void FixedUpdate(){

		// if in Main Scene
		if (Application.loadedLevelName.Equals ("Main")) {

			if(!gameRunning){

				// runs the business
				InvokeRepeating("RunBusiness", 0f, gameSpeed);
				gameRunning = true;

			} // if

		} // if

	} // FixedUpdate()


	/*===================== RunBusiness() =====================================================================================*/

	// Manages the running of the business
	void RunBusiness(){

		float businessProfits = 0f;
		float businessCosts = 0f;
		
		// produceProducts
		businessScript.ProduceProducts();
		businessProfits = businessScript.MoneyEarned;
		
		// If player can start selling drugs
		/*	if(gameManager.CanStartSellingDrugs){

				// Sell drugs
				businessScript.SellDrugs(playerScript);

				// Divide by 2 because the business only gets half while the player gets the other half
				businessProfits += businessScript.MoneyEarned / 2; 
			} // if
			*/
		
		// if business can start producing drugs
		/*	if(gameManager.CanStartMakingDrugs){

				businessScript.MakeDrugs(player);
				// divided by 2 because the business only gets half while the player gets the other half
				businessProfits += businessScript.MoneyEarned / 2;
			} // if
		*/

		// Pay employees
		businessScript.PayEmployees ();

		// Gets cost of employee salarys
		businessCosts = businessScript.TotalEmployeeSalary;

		// Pays building Maintenance
		businessScript.PayMaintenance ();

		// get cost of building Maintenance
		businessCosts += businessScript.BuildingMaintenance;

		// Display business Profits and Costs
		uiManager.mainUI.GetComponent<MainUIControl> ().WorldInformationUpdate (businessProfits, businessCosts);


	} // RunBusiness()


	/*===================== SetupGame() =====================================================================================*/
	
	void SetupGame(){

		// if a new game has been created, setup variables
		if(IsNewGameCreated == true){
			
			SetupNewGame();
			Debug.Log("New game made");
			
		} else { // else load a game

			Debug.Log("Starting to load game");
			// load last save Game
			SetupLoadedGame();
		} // if
	} // SetupGame()


	/*===================== SetupNewGame() =====================================================================================*/

	void SetupNewGame(){
	
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
			businessScript.BankAccount = 100000f;
			break;
		case 'N':	// Normal
			// if game is normal, you start with 50,000 in bank account
			businessScript.BankAccount = 50000f;
			break;
		case 'H':	// Hard
			// if game is hard, you start with 10,000 in bank account
			businessScript.BankAccount = 10000f;
			break;
		} // switch

		// Hire 3 Employees. The default starting number of employees
		businessScript.HireEmployees (3);

		// set IsNewGameCreated to false after new game setup
		IsNewGameCreated = false;
	
	} // SetupNewGame()


	/*===================== SetupLoadedGame() =====================================================================================*/
	
	void SetupLoadedGame(){

		
		Debug.Log ("Loading Game");

		// Loads last saved game
		saveGameManager.Load ();

		if (gameManager.IsGameLoaded) {

			Debug.Log ("Game Loaded");
		} else {

			Debug.Log ("Game Not Loaded");
		} // if

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


	/*===================== PauseGame() =====================================================================================*/

	public void PauseGame(bool pause){

		// Pauses or Unpauses game
		if (pause) {
			// Pause game
			Time.timeScale = 0f;
		} else {
			// Unpause game
			Time.timeScale = 1f;
		} // if
	} // PauseGame()


	/*===================== ResumeGame() =====================================================================================*/

	public void ResumeGame(){

		// Closes escape Menu
		uiManager.ExitEscapeMenu ();

		// unpauses game
		PauseGame (false);

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
		
		// Loads game
		SetupLoadedGame();
		
		// Resumes
		ResumeGame ();
	} // LoadGame()


	/*===================== ExitToMainMenu() =====================================================================================*/

	public void ExitToMainMenu(){

		// loads StartMenu Scene (first scene)
		Application.LoadLevel (0);
	} // ExitToMainMenu()


	/*===================== CheckReputation() =====================================================================================*/
	
	// checks if player can do certain things because of reputation level
	public void CheckReputation(Business business){

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

