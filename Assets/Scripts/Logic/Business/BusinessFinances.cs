using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Script to manage the Business Finances Menu

public class BusinessFinances : MonoBehaviour {

	/*===================== GameObjects =====================================================================================*/

	public GameObject financeBreakdownPanel;


	/*===================== UI Elements =====================================================================================*/




	/*===================== Methods =====================================================================================*/

	/*===================== SetUpMenu() =====================================================================================*/

	// Sets up the finances menu for use
	public void SetUpMenu(){

		// Select Maintenance as the default selected menu
		gameObject.GetComponent<BusinessFinancesMenuControl> ().maintenanceButtonControl ();

		// Check to see if can show drug related fields
		CheckIfSellingOrMakingDrugs ();
	} // SetUpMenu()


	/*===================== CheckIfSellingOrMakingDrugs() =====================================================================================*/
	
	// checks to see if player is making or selling drugs
	public void CheckIfSellingOrMakingDrugs(){
		
		if (GameManager.gameManager.CanStartMakingDrugs) { // if has drug lab

			// show profits from selling drugs
			financeBreakdownPanel.GetComponent<FinanceBreakdownPanel> ().dealerProfits.SetActive (true);

			// show profits from drug lab
			financeBreakdownPanel.GetComponent<FinanceBreakdownPanel> ().labProfits.SetActive (true);

		} else if (GameManager.gameManager.CanStartSellingDrugs) { // if dont have lab but selling

			// show profits from selling drugs
			financeBreakdownPanel.GetComponent<FinanceBreakdownPanel> ().dealerProfits.SetActive (true);
			
			// hide profits from drug lab
			financeBreakdownPanel.GetComponent<FinanceBreakdownPanel> ().labProfits.SetActive (false);

		} else { // if not selling or doesnt have lab

			// hide profits from selling drugs
			financeBreakdownPanel.GetComponent<FinanceBreakdownPanel> ().dealerProfits.SetActive (false);
			
			// hide profits from drug lab
			financeBreakdownPanel.GetComponent<FinanceBreakdownPanel> ().labProfits.SetActive (false);

		}// if
		
	} // CheckIfSellingOrMakingDrugs()
} // Class
