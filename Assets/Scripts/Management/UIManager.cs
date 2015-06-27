using UnityEngine;
using System.Collections;

// UIManager is a singlton

public class UIManager : MonoBehaviour {

	// GameObjects

	public Canvas mainCanvas;
	public GameObject mainMenu;
	
	// UIs

	// StartMenus
	public GameObject mainMenuPrefab;
	public GameObject characterCreationMenuPrefab;

	// MainGameMenus


	// Main Game UIs


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
			Destroy(gameObject);
		} // if

		// Only one instance of UIManager exsists, so start is only run in start scene
		
		// instantiate Main Menu
		mainMenu = (GameObject)Instantiate (mainMenuPrefab);
		
		// make mainMenu a child of "MainCanvas"
		mainMenu.transform.SetParent (mainCanvas.transform, false);
		
		// instantiate Character Creation Menu
		GameObject characterCreationMenu = (GameObject)Instantiate (characterCreationMenuPrefab);
		
		// make characterCreationMenu a child of "MainCanvas"
		characterCreationMenu.transform.SetParent (mainCanvas.transform, false);

	} // Awake()

	void Start(){
		
		// Activate mainMenu
		mainMenu.gameObject.SetActive (true);

	} // Start()

} // class
