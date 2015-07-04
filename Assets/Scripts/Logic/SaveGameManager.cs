using UnityEngine;
using System.Collections;
using System.Collections.Generic;						// for using Lists
using System;											// For saving to file
using System.Runtime.Serialization.Formatters.Binary;	// For saving to file
using System.IO;										// For saving to file

public class SaveGameManager : MonoBehaviour {

	/*===================== Save() =====================================================================================*/
	
	// Saves the players game to save game file
	public void Save(Player player, Business business, GameManager gameManager)
	{
		BinaryFormatter bf = new BinaryFormatter ();

		// Creates new Save file
		FileStream file = File.Create(Application.persistentDataPath + "/ManagementMayhem.dat");

		// Creates new object to hold games data
		GameData data = new GameData ();

		// Save games data to GameData Object
	
		// Saving players state to save file
		data.playerName = player.Name;
		data.playerTrait0 = player.Traits[0];
		data.playerTrait1 = player.Traits[1];
		data.playerTrait2 = player.Traits[2];
		data.playerTrait3 = player.Traits[3];
		data.playerTrait4 = player.Traits[4];
		data.playerBankAccount = player.BankAccount;
		
		// Saving business' state to save file
		data.businessName = business.Name;
		data.businessBankAccount = business.BankAccount;
		data.businessReputation = business.Reputation;
		data.businessBuildingSize = business.BuildingSize;
		data.businessEmployeeSalary = business.EmployeeSalary;
		data.businessTotalEmployeeSalary = business.TotalEmployeeSalary;
		data.businessBuildingMaintenance = business.BuildingMaintenance;
		data.businessAge = business.BusinessAge;
		data.businessEquipmentUpgrades = business.EquipmentUpgrades;
		
		// Saving Employees (NO of employees and their details)
		data.numberOfEmployees = business.Employees.Count;

		// loops through all employees and gets there details
		for(int i = 0; i < business.Employees.Count; i++) {

			// saves employees names
			data.employeeNames.Add(business.Employees [i].GetComponent<Employee> ().Name);
		} // for
		
		// Saving Game Info
		data.gameDifficulty = gameManager.GameDifficulty;
		data.canStartSellingDrugs = gameManager.CanStartSellingDrugs;
		data.canStartMakingDrugs = gameManager.CanStartMakingDrugs;

		// save gamedata object to file
		bf.Serialize (file, data);

		// close file
		file.Close ();
	} // Save()
	
	
	/*===================== Load() =====================================================================================*/
	
	// Loads players game from save game file
	public void Load(Player player, Business business, GameManager gameManager)
	{
		if (File.Exists (Application.persistentDataPath + "/ManagementMayhem.dat")) {

			BinaryFormatter bf = new BinaryFormatter();

			// opens save game file
			FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

			// makes gamedata object with saved game data
			GameData data = (GameData)bf.Deserialize(file);

			// close file
			file.Close();
			
			// copy data from GameData class to local variables
			
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
	public string playerTrait0;
	public string playerTrait1;
	public string playerTrait2;
	public string playerTrait3;
	public string playerTrait4;
	public float playerBankAccount;
	
	// For Saving business' state to save file
	public string businessName;
	public float businessBankAccount;
	public int businessReputation;
	public int businessBuildingSize;
	public float businessEmployeeSalary;
	public float businessTotalEmployeeSalary;
	public float businessBuildingMaintenance;
	public int businessAge;
	public int businessEquipmentUpgrades;
	
	// For Saving Employees (NO of employees and their details)
	public int numberOfEmployees;
	public List<string> employeeNames = new List<string> ();

	// For Saving Game Info
	public char gameDifficulty;
	public bool canStartSellingDrugs;
	public bool canStartMakingDrugs;

} // class

