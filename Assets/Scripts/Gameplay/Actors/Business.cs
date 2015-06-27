using UnityEngine;
using System.Collections;

public class Business : MonoBehaviour {

	// Variables

	public string Name { get; set;}
	public float BankAccount { get; set;}
	public int Reputation { get; set;}
	public int BuildingSize { get; set;} // no. of rooms
	public float BuildingUpgradeCost { get; set;}
	public float BuildingMaintenance { get; set;}
	public int MaxEmployees { get; set;}
	public int MaxDealers { get; set;}
	public float EmployeeSalary { get; set;} // Per Month
	public float TotalEmployeeSalary { get; set;} // total salary paid to all employees
	public int BusinessAge { get; set;} // in months
	public int ProductivityBonus { get; set;}
	public int EquipmentUpgrades { get; set;} // + 10% productivity bonus per upgrade
	public float EquipmentUpgradeCost { get; set;}
	public float MoneyEarned { get; set;}

	// Methods

} // class