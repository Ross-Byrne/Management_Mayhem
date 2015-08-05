using UnityEngine;
using System.Collections;
using System.Collections.Generic;						// for using Lists
using System;											// For saving to file
using System.Runtime.Serialization.Formatters.Binary;	// For saving to file
using System.IO;										// For saving to file

public class SaveGameManager : MonoBehaviour {

	/*===================== Save() =====================================================================================*/
	
	// Saves the players game to save game file
	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter ();

		// Creates new Save file
		FileStream file = File.Create(Application.persistentDataPath + "/ManagementMayhem.dat");

		// Creates new object to hold games data
		GameData data = new GameData ();

		// Save games data to GameData Object
	
		// Saving players state to save file
		data.playerName = GameManager.playerScript.Name;
		data.playerGender = GameManager.playerScript.Gender;
		data.playerSalary = GameManager.playerScript.Salary;
		data.playerBankAccount = GameManager.playerScript.BankAccount;
		data.playerPosition = GameManager.playerScript.Position;
		data.playerTrait0 = GameManager.playerScript.Traits[0];
		data.playerTrait1 = GameManager.playerScript.Traits[1];
		data.playerTrait2 = GameManager.playerScript.Traits[2];
		data.playerTrait3 = GameManager.playerScript.Traits[3];
		data.playerTrait4 = GameManager.playerScript.Traits[4];

		// Saving business' state to save file
		data.businessName = GameManager.businessScript.Name;
		data.businessBankAccount = GameManager.businessScript.BankAccount;
		data.businessReputation = GameManager.businessScript.Reputation;
		data.businessBuildingSize = GameManager.businessScript.BuildingSize;
		data.businessEmployeeSalary = GameManager.businessScript.EmployeeSalary;
		data.businessBuildingMaintenance = GameManager.businessScript.BuildingMaintenance;
		data.businessAge = GameManager.businessScript.BusinessAge;
		data.businessEquipmentUpgrades = GameManager.businessScript.EquipmentUpgrades;
		
		// Saving Employees (NO of employees and their details)
		data.numberOfEmployees = GameManager.businessScript.Employees.Count;

		// loops through all employees and gets there details
		for(int i = 0; i < GameManager.businessScript.Employees.Count; i++) {

			data.employeeNames.Add(GameManager.businessScript.Employees [i].GetComponent<Employee> ().Name);
			data.employeeGenders.Add(GameManager.businessScript.Employees[i].GetComponent<Employee>().Gender);
			data.employeeBankAccounts.Add(GameManager.businessScript.Employees[i].GetComponent<Employee>().BankAccount);
			data.employeeSalaries.Add(GameManager.businessScript.Employees[i].GetComponent<Employee>().Salary);
			data.employeePosition.Add(GameManager.businessScript.Employees[i].GetComponent<Employee>().Position);

		} // for
		
		// Saving Game Info
		data.gameDifficulty = GameManager.gameManager.GameDifficulty;
		data.canStartSellingDrugs = GameManager.gameManager.CanStartSellingDrugs;
		data.canStartMakingDrugs = GameManager.gameManager.CanStartMakingDrugs;

		// save gamedata object to file
		bf.Serialize (file, data);

		// close file
		file.Close ();
	} // Save()
	
	
	/*===================== Load() =====================================================================================*/
	
	// Loads players game from save game file
	public void Load()
	{
		if (File.Exists (Application.persistentDataPath + "/ManagementMayhem.dat")) {

			BinaryFormatter bf = new BinaryFormatter ();

			// opens save game file
			FileStream file = File.Open (Application.persistentDataPath + "/ManagementMayhem.dat", FileMode.Open);

			// makes gamedata object with saved game data
			GameData data = (GameData)bf.Deserialize (file);

			// close file
			file.Close ();
			
			// say game has not been loaded
			GameManager.gameManager.IsGameLoaded = false;

			// before loading a save file, the current values for employees  must be cleared
			GameManager.businessScript.FireAllEmployees ();
			
			// setting other values to default
			GameManager.gameManager.AppliedForGrant = false;
			GameManager.gameManager.CanStartSellingDrugs = false;

			// copy data from GameData class to local variables
			
			// to make sure the values load correctly
			// try to load them, if it fails, set values to default
			
			try {
				// Loading players state from save file data
				GameManager.playerScript.Name = data.playerName;
				GameManager.playerScript.Gender = data.playerGender;
				GameManager.playerScript.Salary = data.playerSalary;
				GameManager.playerScript.BankAccount = data.playerBankAccount;
				GameManager.playerScript.Position = data.playerPosition;
				GameManager.playerScript.Traits [0] = data.playerTrait0;
				GameManager.playerScript.Traits [1] = data.playerTrait1;
				GameManager.playerScript.Traits [2] = data.playerTrait2;
				GameManager.playerScript.Traits [3] = data.playerTrait3;
				GameManager.playerScript.Traits [4] = data.playerTrait4;
				
				// Loading business' state from save file data
				GameManager.businessScript.Name = data.businessName;
				GameManager.businessScript.BankAccount = data.businessBankAccount;
				GameManager.businessScript.Reputation = data.businessReputation;
				GameManager.businessScript.BuildingSize = data.businessBuildingSize;
				GameManager.businessScript.EmployeeSalary = data.businessEmployeeSalary;
				GameManager.businessScript.BuildingMaintenance = data.businessBuildingMaintenance;
				GameManager.businessScript.BusinessAge = data.businessAge;
				GameManager.businessScript.EquipmentUpgrades = data.businessEquipmentUpgrades;
				
				// Loading Employees and their deatials

				// Create employees
				GameManager.businessScript.LoadEmployees (data.numberOfEmployees);

				// load employees details
				for (int i = 0; i < data.numberOfEmployees; i++) {

					GameManager.businessScript.Employees [i].GetComponent<Employee> ().Name = data.employeeNames [i];
					GameManager.businessScript.Employees[i].GetComponent<Employee>().Gender = data.employeeGenders[i];
					GameManager.businessScript.Employees[i].GetComponent<Employee>().BankAccount = data.employeeBankAccounts[i];
					GameManager.businessScript.Employees[i].GetComponent<Employee>().Salary = data.employeeSalaries[i];
					GameManager.businessScript.Employees[i].GetComponent<Employee>().Position = data.employeePosition[i];

				} // for

				// Loading Game Info
				GameManager.gameManager.GameDifficulty = data.gameDifficulty;
				GameManager.gameManager.CanStartSellingDrugs = data.canStartSellingDrugs;
				GameManager.gameManager.CanStartMakingDrugs = data.canStartMakingDrugs;
				
				// saying the game loaded
				GameManager.gameManager.IsGameLoaded = true;

			} catch (Exception e) { // if loading fails, set everything to default
				// prints exception message
				Debug.Log (e);

				// saying game didn't load
				GameManager.gameManager.IsGameLoaded = false;
				
				// set all the values being loaded back to default

				// Sets business variables back to default
				GameManager.businessScript.SetupBusiness ();

				// Clears all employees
				GameManager.businessScript.FireAllEmployees ();

			} // try catch
			
		} else {	// if save file doesnt exsist

			// tell gameManager game not loaded
			GameManager.gameManager.IsGameLoaded = false;
		} // if
	} // Load()

} // class


/*===================== PlayerData Class =====================================================================================*/

// Class for holding all game data to make a save game
[Serializable]
class GameData
{
	// For Saving players state to save file
	public string playerName;
	public char playerGender;
	public float playerSalary;
	public float playerBankAccount;
	public string playerPosition;
	public string playerTrait0;
	public string playerTrait1;
	public string playerTrait2;
	public string playerTrait3;
	public string playerTrait4;
	
	// For Saving business' state to save file
	public string businessName;
	public float businessBankAccount;
	public int businessReputation;
	public int businessBuildingSize;
	public float businessEmployeeSalary;
	public float businessBuildingMaintenance;
	public int businessAge;
	public int businessEquipmentUpgrades;
	
	// For Saving Employees (NO of employees and their details)
	public int numberOfEmployees;
	public List<string> employeeNames = new List<string> ();
	public List<char> employeeGenders = new List<char> ();
	public List<float> employeeBankAccounts = new List<float> ();
	public List<float> employeeSalaries = new List<float> ();
	public List<string> employeePosition = new List<string> ();

	// For Saving Game Info
	public char gameDifficulty;
	public bool canStartSellingDrugs;
	public bool canStartMakingDrugs;

} // class

