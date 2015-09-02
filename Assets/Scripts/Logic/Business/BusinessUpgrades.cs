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
	public Text numOfEquipUpgradesText;
	public Text equipUpgradeCostText;
	
	/*===================== Methods =====================================================================================*/
	
	/*===================== SetUpMenu() =====================================================================================*/
	
	// Sets up the Menu to be used
	public void SetUpMenu(){
		
		// Open the AddRooms Menu by default
		gameObject.GetComponent<BusinessUpgradesMenuControl> ().AddRoomControl ();

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

		// Update vaules on UpgradeEquipmentMenu
		UpdateEquipmentUpgradesText ();

	} // SetUpMenu()


	/*===================== BuildRoomControl() =====================================================================================*/

	// Fires when BuildRoomButton is Clicked
	public void BuildRoomControl(){

		// Upgrades the building by added a new Room
		GameManager.businessScript.UpgradeBuilding ();

		// Update building to show upgrade
		GameManager.gameManager.theBuilding.GetComponent<BusinessBuildingGeneration> ().UnlockBuildingRooms ();

		// Update the number of rooms and cost of next upgrade
		UpdateRoomUpgradeText ();

	} // BuildRoomControl()


	/*===================== UpgradeEquipmentControl() =====================================================================================*/
	
	// Fires when UpgradeEquipmentButton is Clicked
	public void UpgradeEquipmentControl(){
		
		// Upgrades the buildings equipment
		GameManager.businessScript.UpgradeEquipment ();
		
		// Update the number of equipment upgrades and cost of next upgrade
		UpdateEquipmentUpgradesText ();
		
	} // UpgradeEquipmentControl()


	/*===================== UpdateRoomUpgradeText() =====================================================================================*/

	public void UpdateRoomUpgradeText(){
	
		// Update numOfRoomsText
		numOfRoomsText.text = GameManager.businessScript.BuildingSize.ToString ();

		// update the cost of next building next room
		buildingUpgradeCostText.text = string.Format ("${0}", GameManager.businessScript.BuildingUpgradeCost.ToString("F"));

	} // UpdateRoomUpgradeText()


	/*===================== UpdateEquipmentUpgradesText() =====================================================================================*/
	
	public void UpdateEquipmentUpgradesText(){
		
		// Update numOfEquipUpgradesText
		numOfEquipUpgradesText.text = GameManager.businessScript.EquipmentUpgrades.ToString ();
		
		// update the cost of next equipment upgrade
		equipUpgradeCostText.text = string.Format ("${0}", GameManager.businessScript.EquipmentUpgradeCost.ToString ("F"));
		
	} // UpdateEquipmentUpgradesText()


} // class
