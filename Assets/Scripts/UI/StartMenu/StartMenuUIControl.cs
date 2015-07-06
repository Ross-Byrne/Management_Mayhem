using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartMenuUIControl : MonoBehaviour {

	// GameObjects

	public GameObject characterCreationMenuPrefab;
	
	// Menus

	public GameObject characterCreationMenu;

	// UI Elements

	public Button StartNewGameButton;
	public Button LoadGameButton;
	public Button GameInfoButton;
	public Button ExitGameButton;

	// Methods
	
	void Start(){
	
		// Setup the characterCreationMenu
		
		// Get reference for menu because it was instantiated 
		characterCreationMenu = GameObject.FindWithTag ("CharacterCreationMenu");

		// Set characterCreationMenu's aphla to 0 (Makes transperent)
		characterCreationMenu.GetComponent<CanvasGroup> ().alpha = 0;
		
		// Block raycasts - making the menu not clickable
		characterCreationMenu.GetComponent<CanvasGroup> ().blocksRaycasts = false;
		
		// Activate CharacterCreationMenu
		characterCreationMenu.gameObject.SetActive (true);
		
		// Activate CharacterTraitsMenu
		characterCreationMenu.GetComponent<CharacterCreationUIControl> ().characterTraitsMenu.gameObject.SetActive (true);

	} // Start()

	// Fires when player clicks "StartNewGameButton"
	public void NewGame(){

		// Deactivates MainMenu 
		gameObject.SetActive(false);

		// Activates Character Creation Menu
		characterCreationMenu.gameObject.SetActive(true);

		// Runs setup needed for characterCreationMenu
		characterCreationMenu.GetComponent<CharacterCreationUIControl> ().SetUp ();
	} // NewGame()

	// Fires when player clicks "LoadGameButton"
	public void LoadGame(){

		Application.LoadLevel (1);

	} // LoadGame()

	// Fires when player clicks "GameInfoButton"
	public void GameInfo(){


	} // GameInfo()

	// Fires when player clicks "ExitGameButton"
	public void ExitGame(){

		// Exits the game
		Application.Quit();
	} // ExitGame()



} // class
