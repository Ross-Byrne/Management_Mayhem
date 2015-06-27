using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// UIManager is a singlton

public class UIManager : MonoBehaviour {
	
	// UIs

	// StartMenus

	public GameObject mainMenuPrefab;
	public GameObject characterCreationMenuPrefab;

	public Canvas mainCanvas;
	public GameObject mainMenu;
	
	// Main Game UIs

	public GameObject mainUIPrefab;

	public GameObject mainUI;

	// MainGameMenus


	// Scripts

	public static UIManager uiManager;

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


		// to make sure code is running in the right scene
		if (Application.loadedLevelName.Equals ("StartMenu")) {

			// Only one instance of UIManager exsists, so start is only run in start scene

			// Setup Main Menu
			SetUpStartMenuScene();

		} // if

	} // Awake()


	// Runs code every Frame
	void Update(){

		// If in the main game Scene
		if (Application.loadedLevelName.Equals ("Main")) {

			// If escape key is pressed
			if(Input.GetKeyDown(KeyCode.Escape) == true ){

				// Games Main Menu Appears
				Debug.Log("MainMEnu Appears");
			} // if
			
		} // if


	} // Update()

	
	// When the main scene loads
	void OnLevelWasLoaded(int level){

		// if the scene "StartMenu" loads
		if(level == 0){
			Debug.Log("StartMenu");

			// Setup main Menu
			SetUpStartMenuScene();
		} // if

		// if the scene "Main" loads
		if (level == 1) {
			Debug.Log("Main");

			// instantiate The Main UI
			mainUI = (GameObject)Instantiate(mainUIPrefab);

			// make mainUI a child of "MainCanvs"
			mainUI.transform.SetParent(mainCanvas.transform, false);

			// should be a method that is called in GameManger
		/*	mainUI.GetComponentInChildren<Text>().text = GameManager.gameManager.playerScript.Name;
				/*+ GameManager.gameManager.playerScript.Traits[0] + " "
				+ GameManager.gameManager.playerScript.Traits[1] + "/n"
				+ GameManager.gameManager.playerScript.Traits[2] + "/n"
				+ GameManager.gameManager.playerScript.Traits[3] + "/n"
				+ GameManager.gameManager.playerScript.Traits[4] + "/n"
				+ GameManager.gameManager.businessScript.Name + "/n"
				+ GameManager.gameManager.gameDifficulty; */
		
		} // if

	} // OnLevelWasLoaded()

	void SetUpStartMenuScene(){

		// instantiate Main Menu
		mainMenu = (GameObject)Instantiate (mainMenuPrefab);
		
		// make mainMenu a child of "MainCanvas"
		mainMenu.transform.SetParent (mainCanvas.transform, false);
		
		// instantiate Character Creation Menu
		GameObject characterCreationMenu = (GameObject)Instantiate (characterCreationMenuPrefab);
		
		// make characterCreationMenu a child of "MainCanvas"
		characterCreationMenu.transform.SetParent (mainCanvas.transform, false);
		
		// Activate mainMenu
		mainMenu.gameObject.SetActive (true);

	} // SetUpStartMenuScene()
} // class
