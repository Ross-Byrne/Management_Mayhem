using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;

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


	/*===================== PlayerInformationUpdate() =====================================================================================*/
	
	public void PlayerInformationUpdate(Player player){

		StringBuilder str = new StringBuilder ();

		// Update player info text

		// Display player name
		playerNameText.text = str.Append("Name: ").Append(player.Name).ToString();
		str.Length = 0; // clear string

		// display players bank account
		playerBankAccountText.text = str.Append("Bank Account: $").Append(player.BankAccount.ToString("F")).ToString();
		str.Length = 0; // clear string

		// display player level
		playerLevelText.text = "Level: 0";

		// display player experience
		playerXPText.text = "Experience: 0/0";

		// Display players traits
		playerTrait1Text.text = str.Append("Trait 1: ").Append(player.Traits [0]).ToString();
		str.Length = 0; // clear string

		// Display players traits
		playerTrait2Text.text = str.Append("Trait 2: ").Append(player.Traits [1]).ToString();
		str.Length = 0; // clear string

		// Display players traits
		playerTrait3Text.text = str.Append("Trait 3: ").Append(player.Traits [2]).ToString();
		str.Length = 0; // clear string

		// Display players traits
		playerTrait4Text.text = str.Append("Trait 4: ").Append(player.Traits [3]).ToString();
		str.Length = 0; // clear string

		// Display players traits
		playerTrait5Text.text = str.Append("Trait 5: ").Append(player.Traits [4]).ToString();
		str.Length = 0; // clear string

	} // PlayerInformationUpdate()


	/*===================== BusinessInformationUpdate() =====================================================================================*/
	
	public void BusinessInformationUpdate(Business business){
	
		StringBuilder str = new StringBuilder ();

		// Update business info Text
		
		// Update Business Name
		businessNameText.text = str.Append("Name: ").Append(business.Name).ToString();
		str.Length = 0; // clear string

		// Update Business Bank Account
		businessBankAccountText.text = str.Append("Bank Account: $").Append(business.BankAccount.ToString("F")).ToString();
		str.Length = 0; // clear string

		// Update Business Age
		businessAgeText.text = str.Append("Age: ").Append(business.BusinessAge).Append(" Months").ToString();
		str.Length = 0; // clear string

		// Update Business Reputation
		businessRepText.text = str.Append ("Reputation: ").Append (business.Reputation).ToString ();
		str.Length = 0; // clear string

		// Update Business Building Size
		businessSizeText.text = str.Append("Number Of Rooms: ").Append(business.BuildingSize).ToString();
		str.Length = 0; // clear string

		// Update Business Employee Count
		BusinessEmployeeCountText.text = str.Append("Employees: ").Append(business.Employees.Count).ToString();
		str.Length = 0; // clear string

		// Update Business Employee Salary
		businessTotalSalaryText.text = str.Append("Total Salary Paid: $").Append(business.TotalEmployeeSalary.ToString("F")).ToString();
		str.Length = 0; // clear string

		// Update Business Maintenance Cost
		businessMaintenanceText.text = str.Append("Maintenance Cost: $").Append(business.BuildingMaintenance.ToString("F")).ToString();
		str.Length = 0; // clear string

		// Update Business Producivity Bonus
		businessProdcutivtyBonusText.text = str.Append ("Productivity Bonus: ").Append (business.ProductivityBonus).Append ("%").ToString ();
		str.Length = 0; // clear string

		// Update Business Equipment Upgrades
		businessEquipUpgradesText.text = str.Append("Equipment Upgrades: ").Append(business.EquipmentUpgrades).ToString();
		str.Length = 0; // clear string

	} // BusinessInformationUpdate()


	/*===================== WorldInformationUpdate() =====================================================================================*/
	
	public void WorldInformationUpdate(float businessProfits, float businessCosts){
	
		StringBuilder str = new StringBuilder();

		// Update world info
		
		// Update profits being made by the business
		businessProfitsText.text = str.Append("Business Profits: $").Append(businessProfits.ToString("F")).ToString();
		str.Length = 0; // clear string

		// Update business Costs
		businessCostsText.text = str.Append("Business Costs: $").Append(businessCosts.ToString("F")).ToString();
		str.Length = 0; // clear string
		
	} // WorldInformationUpdate()


} // class
