using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// UIManager is a singlton

public class UIManager : MonoBehaviour {
	
	// UIs

	public GameObject canvasPrefab;
	public GameObject canvasHolder;
	public Canvas mainCanvas;

	// StartMenus

	public GameObject mainMenuPrefab;
	public GameObject characterCreationMenuPrefab;

	public GameObject mainMenu;
	public GameObject characterCreationMenu;
	
	// Main Game UIs

	public GameObject mainUIPrefab;

	public GameObject mainUI;

	// MainGameMenus


	// Scripts

	public static UIManager uiManager;

	// Variables

	public bool IsMainUISetup { get; set;}

	// Methods

	// Initialisation
	void Awake(){

		// to make sure only one version of UIManager exisits
		// to enforce singlton patern
		if (uiManager == null) {
			DontDestroyOnLoad (gameObject);
			uiManager = this;
		} else if (uiManager != this) {
			Destroy (gameObject);
		} // if

		// Variable initialisation
		IsMainUISetup = false;

		// to make sure code is running in the right scene
		if (Application.loadedLevelName.Equals ("StartMenu")) {

			// Setup Main Menu
			SetUpStartMenuScene();

		} // if

		if (Application.loadedLevelName.Equals ("Main")) {

			// setup main scene UIs
			SetUpMainScene();

		} // if

	} // Awake()


	// Runs code every Frame
	void Update(){

		// If in the main game Scene
		if (Application.loadedLevelName.Equals ("Main")) {

			// If escape key is pressed
			if(Input.GetKeyDown(KeyCode.Escape) == true ){

				// Games Main Menu Appears
				Debug.Log("MainMenu Appears");
			} // if
		} // if
	} // Update()

	
	// When the main scene loads
	void OnLevelWasLoaded(int level){
		Debug.Log ("Setting up UIManager");
		// if the scene "StartMenu" loads
		if(level == 0){

			// Setup main Menu
			SetUpStartMenuScene();
		} // if

		// if the scene "Main" loads
		if (level == 1) {
		
			// setup main scene UIs
			SetUpMainScene();
		} // if

	} // OnLevelWasLoaded()

	void SetUpStartMenuScene(){

		// instantiate Main Canvas Holder
		canvasHolder = (GameObject)Instantiate (canvasPrefab);

		// make canvasHolder a child of "UIManager"
		canvasHolder.transform.SetParent (gameObject.transform, false);

		// Get reference to mainCanvas from canvasHolder
		mainCanvas = canvasHolder.GetComponentInChildren<Canvas> ();

		// instantiate Main Menu
		mainMenu = (GameObject)Instantiate (mainMenuPrefab);
		
		// make mainMenu a child of "MainCanvas"
		mainMenu.transform.SetParent (mainCanvas.transform, false);
		
		// instantiate Character Creation Menu
		characterCreationMenu = (GameObject)Instantiate (characterCreationMenuPrefab);
		
		// make characterCreationMenu a child of "MainCanvas"
		characterCreationMenu.transform.SetParent (mainCanvas.transform, false);
		
		// Activate mainMenu
		mainMenu.gameObject.SetActive (true);

	} // SetUpStartMenuScene()


	void SetUpMainScene(){

		// instantiate Main Canvas Holder
		canvasHolder = (GameObject)Instantiate (canvasPrefab);

		// make canvasHolder a child of "UIManager"
		canvasHolder.transform.SetParent (gameObject.transform, false);
		
		// Get reference to mainCanvas from canvasHolder
		mainCanvas = canvasHolder.GetComponentInChildren<Canvas> ();

		// instantiate The Main UI
		mainUI = (GameObject)Instantiate(mainUIPrefab);
		
		// make mainUI a child of "MainCanvs"
		mainUI.transform.SetParent(mainCanvas.transform, false);
		
		// MainUI is finished Setting up
		IsMainUISetup = true;

	} // SetUpMainScene()


	public void displayNewGameDetails(Player player, Business business, GameManager gameManager){
		mainUI.GetComponentInChildren<Text>().text = player.Name + "\n"
			+ player.Traits[0] + "\n"
			+ player.Traits[1] + "\n"
			+ player.Traits[2] + "\n"
			+ player.Traits[3] + "\n"
			+ player.Traits[4] + "\n"
			+ business.Name + "\n";

		 switch (gameManager.gameDifficulty) {
		case 'E':
				mainUI.GetComponentInChildren<Text>().text += "Easy";
				break;
		case 'N':
				mainUI.GetComponentInChildren<Text>().text += "Normal";
				break;
		case 'H':
				mainUI.GetComponentInChildren<Text>().text += "Hard";
				break;
		} // Switch
	} // displayNewGameDetails()
} // class
