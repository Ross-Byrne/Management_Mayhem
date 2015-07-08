using UnityEngine;
using System.Collections;

public class ManagementMenuControl : MonoBehaviour {

	/*===================== Menus =====================================================================================*/

	public GameObject managementMenu;
	public GameObject playerManagementMenu;
	public GameObject businessManagementMenu;
	public GameObject worldManagementMenu;


	/*===================== Methods =====================================================================================*/

	/*===================== PlayerMenuControl =====================================================================================*/

	public void PlayerMenuControl(){

		// if menu is on
		if (playerManagementMenu.activeSelf) {

			// turn off
			playerManagementMenu.SetActive (false);

			// turn of background menu
			managementMenu.SetActive (false);
		} else {	// if off, turn on

			// make sure even other menu is off
			businessManagementMenu.SetActive(false);
			worldManagementMenu.SetActive(false);

			// turn on background menu
			managementMenu.SetActive(true);

			// turn on menu
			playerManagementMenu.SetActive(true);
		} // if
	} // PlayerMenuControl()


	/*===================== BusinessMenuControl =====================================================================================*/
	
	public void BusinessMenuControl(){
		
		// if menu is on
		if (businessManagementMenu.activeSelf) {
			
			// turn off
			businessManagementMenu.SetActive (false);
			
			// turn of background menu
			managementMenu.SetActive (false);
		} else {	// if off, turn on
			
			// make sure even other menu is off
			playerManagementMenu.SetActive(false);
			worldManagementMenu.SetActive(false);
			
			// turn on background menu
			managementMenu.SetActive(true);
			
			// turn on menu
			businessManagementMenu.SetActive(true);
		} // if
	} // BusinessMenuControl()


	/*===================== WorldMenuControl =====================================================================================*/
	
	public void WorldMenuControl(){
		
		// if menu is on
		if (worldManagementMenu.activeSelf) {
			
			// turn off
			worldManagementMenu.SetActive (false);
			
			// turn of background menu
			managementMenu.SetActive (false);
		} else {	// if off, turn on
			
			// make sure even other menu is off
			playerManagementMenu.SetActive(false);
			businessManagementMenu.SetActive(false);
			
			// turn on background menu
			managementMenu.SetActive(true);
			
			// turn on menu
			worldManagementMenu.SetActive(true);
		} // if
	} // WorldMenuControl()


} // class
