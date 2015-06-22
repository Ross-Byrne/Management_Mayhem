using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartMenuUIControl : MonoBehaviour {

	// Menus
	//public StartMenuUIControl mainMenu;
	public GameObject characterCreationMenu;

	// UI Elements
	public Button StartNewGameButton;
	public Button LoadGameButton;
	public Button GameInfoButton;
	public Button ExitGameButton;

	// Methods

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
