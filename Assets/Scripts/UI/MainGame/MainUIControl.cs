using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainUIControl : MonoBehaviour {

	/*===================== GameObjects =====================================================================================*/

	public GameObject playerInfo;
	public GameObject businessInfo;
	public GameObject worldInfo;


	/*===================== Menus =====================================================================================*/

	public GameObject manageBusinessMenu;


	/*===================== UI Elements =====================================================================================*/

	/*===================== InforBar Text Elements =====================================================================================*/

	// Player text
	public Text playerNameText;
	public Text playerBankAccountText;
	public Text playerLevelText;
	public Text playerXPText;
	public Text playerTrait1Text;
	public Text playerTrait2Text;
	public Text playerTrait3Text;
	public Text playerTrait4Text;
	public Text playerTrait5Text;

	 
	// Business info Text
	public Text businessNameText;
	public Text businessBankAccountText;
	public Text businessAgeText;
	public Text businessRepText;
	public Text businessSizeText;
	public Text BusinessEmployeeCountText;
	public Text businessTotalSalaryText;
	public Text businessMaintenanceText;
	public Text businessProdcutivtyBonusText;
	public Text businessEquipUpgradesText;


	// World Info Text
	public Text businessProfitsText;
	public Text businessCostsText;


	/*===================== Methods =====================================================================================*/

	/*===================== MenuControl() =====================================================================================*/
	
	// controls if a menu is turned on or off
	public void MenuControl(GameObject menu){

		// if menu is active, turn off
		if (menu.activeSelf) {

			// deactivate menu
			menu.SetActive(false);
		} else { // if menu is turned off, turn it on

			// activate menu
			menu.SetActive(true);
		} // if

	} // MenuControl()





} // class
