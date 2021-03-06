﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;

public class MainUIControl : MonoBehaviour {
 
	/*===================== GameObjects =====================================================================================*/

	public GameObject playerInfo;
	public GameObject businessInfo;
	public GameObject worldInfo;


	/*===================== UI Elements =====================================================================================*/

	/*===================== Main Info Bar =====================================================================================*/

	// Shown on main game UI
	public Text playersAccountText;
	public Text businessAccountText;
	public Text employeeCountText;
	public Text profitsText;
	public Text costsText;
	public Text worldDateText;


	/*===================== Information Windows =====================================================================================*/

	// Player text
	public Text playerNameText;
	public Text playerGenderText;
	public Text playerBankAccountText;
	public Text playerSalaryText;
	public Text playerPositionText;
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


	/*===================== Methods =====================================================================================*/

	/*===================== InformationBarUpdate() =====================================================================================*/

	public void InformationBarUpdate(Player player, Business business, TimeDateManager timeDateManager){

		StringBuilder str = new StringBuilder ();

		// Update Game Information

		// Update players bankAccount
		playersAccountText.text = str.Append("$").Append(player.BankAccount.ToString ("F")).ToString();
		str.Length = 0; // clear string

		// Update business bankAccount
		businessAccountText.text = str.Append("$").Append(business.BankAccount.ToString ("F")).ToString();
		str.Length = 0; // clear string

		// Update business' employee Count
		employeeCountText.text = business.Employees.Count.ToString();

		// Update business Profits
		profitsText.text = str.Append ("$").Append (business.Profits.ToString("F")).ToString ();
		str.Length = 0; // clear string

		// Update business Costs
		costsText.text = str.Append ("$").Append (business.Costs.ToString("F")).ToString ();
		str.Length = 0; // clear string

		// update world date
		worldDateText.text = timeDateManager.worldDate.Date ();

	} // InformationBarUpdate()

	
	/*===================== PlayerInformationUpdate() =====================================================================================*/
	
	public void PlayerInformationUpdate(Player player){

		StringBuilder str = new StringBuilder ();
		string gender = "";

		// Update player info text

		// Display player name
		playerNameText.text = str.Append("Name: ").Append(player.Name).ToString();
		str.Length = 0; // clear string

		// Get player's Gender
		if(player.Gender == 'M'){
			gender = "Male";
		} else if(player.Gender == 'F'){
			gender = "Female";
		} // if

		// Display player Gender
		playerGenderText.text = str.Append ("Gender: ").Append (gender).ToString ();
		str.Length = 0; // clear string

		// display players bank account
		playerBankAccountText.text = str.Append("Bank Account: $").Append(player.BankAccount.ToString("F")).ToString();
		str.Length = 0; // clear string

		// display player Salary
		playerSalaryText.text = str.Append ("Salary: $").Append (player.Salary.ToString ("F")).Append(" Per Hour").ToString ();
		str.Length = 0; // clear string

		// display player Position
		playerPositionText.text = str.Append ("Position: ").Append(player.Position).ToString();
		str.Length = 0; // clear string

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
	
	public void WorldInformationUpdate(GameManager gameManager){
	

		
	} // WorldInformationUpdate()


} // class
