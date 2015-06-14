using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterCreationUIControl : MonoBehaviour {

	// Menus
	public GameObject mainMenu;
	public GameObject characterCreationMenu;

	// UI Elements
	public Button ExitButton;
	
	// Methods

	public void Exit(){

		// Deactivates Character Creation Menu and Activates MainMenu
		characterCreationMenu.gameObject.SetActive(false);
		mainMenu.gameObject.SetActive(true);
	} // Exit()

} // class
