using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;			// to use StringBuilder

public class UIManager : MonoBehaviour 
{
	/*===================== UIs =====================================================================================*/
	
	public Canvas mainCanvas;
	

	/*===================== StartMenus =====================================================================================*/

	public GameObject mainMenuPrefab;
	public GameObject characterCreationMenuPrefab;

	public GameObject mainMenu;
	public GameObject characterCreationMenu;
	

	/*===================== Main Game UIs =====================================================================================*/

	public GameObject mainUIPrefab;

	public GameObject mainUI;


	/*===================== MainGameMenus =====================================================================================*/

	public GameObject escapeMenuPrefab;

	public GameObject escapeMenu;

	
	/*===================== Scripts =====================================================================================*/

	public static UIManager uiManager;


	/*===================== Variables =====================================================================================*/

	public bool IsMainUISetup { get; set;}
	public bool IsEscapeMenuActivated { get; set;}


	/*===================== Methods =====================================================================================*/

	/*===================== Awake() =====================================================================================*/

	// Initialisation
	void Awake()
	{
		// Variable initialisation
		IsMainUISetup = false;
		IsEscapeMenuActivated = false;

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


	/*===================== Update() =====================================================================================*/

	// Runs code every Frame
	void Update()
	{
		// If in the main game Scene
		if (Application.loadedLevelName.Equals ("Main")) {

			// If escape key is pressed
			if(Input.GetKeyDown(KeyCode.Escape) == true ){

				// flags escapeMenu as toggled
				if(!IsEscapeMenuActivated){
					// if escapeMenu is not already activated, activate it
					IsEscapeMenuActivated = true;
				} else{
					// if menu is already activated, deactivate it
					IsEscapeMenuActivated = false;
				} // if
			
				// Opens/closes escapeMenu
				ManageEscapeMenu(IsEscapeMenuActivated);
			} // if


		} // if
	} // Update()


	/*===================== SetUpStartMenuScene() =====================================================================================*/

	void SetUpStartMenuScene()
	{
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


	/*===================== SetUpMainScene() =====================================================================================*/

	void SetUpMainScene()
	{
		// instantiate The Main UI
		mainUI = (GameObject)Instantiate(mainUIPrefab);
		
		// make mainUI a child of "MainCanvs"
		mainUI.transform.SetParent(mainCanvas.transform, false);

		// Setup escape menu

		// instantuate escape menu
		escapeMenu = (GameObject)Instantiate (escapeMenuPrefab);

		// make escape menu a child of mainCanvas
		escapeMenu.transform.SetParent (mainCanvas.transform, false);

		// Deactivates escapeMenu
		escapeMenu.gameObject.SetActive (false);


		// MainUI is finished Setting up
		IsMainUISetup = true;

	} // SetUpMainScene()


	/*===================== ManageEscapeMenu() =====================================================================================*/

	// Manages when the escapeMenu is active and disabled
	public void ManageEscapeMenu(bool isActive)
	{
		if (isActive) {
			// pauses game
			GameManager.gameManager.PauseGame(true);

			// Activates escapeMenu
			escapeMenu.gameObject.SetActive (true);
		} else {
			// Deactivates escapeMenu
			escapeMenu.gameObject.SetActive(false);

			// unpauses game
			GameManager.gameManager.PauseGame(false);
		} // if
	} // ManageEscapeMenu()


	/*===================== ExitEscapeMenu() =====================================================================================*/

	public void ExitEscapeMenu()
	{
		IsEscapeMenuActivated = false;
		ManageEscapeMenu (IsEscapeMenuActivated);

	} // ExitEscapeMenu()


	/*===================== DisplayNewGameDetails() =====================================================================================*/

	public void DisplayNewGameDetails(Player player, Business business, GameManager gameManager)
	{
	/*	mainUI.GetComponentInChildren<Text>().text = player.Name + "\n"
			+ player.Traits[0] + "\n"
			+ player.Traits[1] + "\n"
			+ player.Traits[2] + "\n"
			+ player.Traits[3] + "\n"
			+ player.Traits[4] + "\n"
			+ business.Name + "\n";
*/
		 switch (gameManager.GameDifficulty) 
		{
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
	} // DisplayNewGameDetails()
	
} // class
