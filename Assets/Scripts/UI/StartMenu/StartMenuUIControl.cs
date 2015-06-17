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

		// Deactivates MainMenu and Activates Character Creation Menu
		gameObject.SetActive(false);
		characterCreationMenu.gameObject.SetActive(true);
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
