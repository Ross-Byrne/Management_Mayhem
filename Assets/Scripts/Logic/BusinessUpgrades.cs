using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Script to manage the business upgrades menu

public class BusinessUpgrades : MonoBehaviour {

	/*===================== GameObjects =====================================================================================*/
	
	// businessUpgrades Menu Window
	public GameObject businessUpgradeMenuWindow;


	/*===================== UI Elements =====================================================================================*/
	
	// Buttons

	public Button upgradeDrugLabButton;

	// Text

	public Text numOfRoomsText;
	public Text buildingUpgradeCostText;
	
	/*===================== Methods =====================================================================================*/
	
	/*===================== SetUpMenu() =====================================================================================*/
	
	// Sets up the Menu to be used
	public void SetUpMenu(){
		
		// Open the AddRooms Menu by default
		businessUpgradeMenuWindow.GetComponent<BusinessUpgradesMenuControl> ().AddRoomControl ();

		// Check if player has a drug lab
		if (GameManager.gameManager.CanStartMakingDrugs) { // if yes

			// name hidden menu
			upgradeDrugLabButton.GetComponent<UpgradeDrugLabButton> ().buttonText.text = "Drug Lab";
		} else { // if no

			// name hidden menu
			upgradeDrugLabButton.GetComponent<UpgradeDrugLabButton> ().buttonText.text = "???????";
		} // if

		// Updates values on AddRoomMenu
		UpdateRoomUpgradeText ();

	} // SetUpMenu()


	/*===================== BuildRoomControl() =====================================================================================*/

	// Fires when BuildRoomButton is Clicked
	public void BuildRoomControl(){

		// Upgrades the building by added a new Room
		GameManager.businessScript.UpgradeBuilding ();

		// Update the number of rooms and cost of next upgrade
		UpdateRoomUpgradeText ();

	} // BuildRoomControl()


	/*===================== UpdateRoomUpgradeText() =====================================================================================*/

	public void UpdateRoomUpgradeText(){
	
		// Update numOfRoomsText
		numOfRoomsText.text = GameManager.businessScript.BuildingSize.ToString ();

		// update the cost of next building next room
		buildingUpgradeCostText.text = string.Format ("${0}", GameManager.businessScript.BuildingUpgradeCost.ToString ("F"));

	} // UpdateRoomUpgradeText()



} // class
