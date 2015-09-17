using UnityEngine;
using System.Collections;
using System.Collections.Generic; 	// to use Lists
using System.Text; 					// to use StringBuilder

public class Business : MonoBehaviour {

	/*===================== GameObjects =====================================================================================*/

	public GameObject employeePrefab;

    private GameObject businessEmployees;
    private GameObject businessProducts;


    /*===================== Scripts =====================================================================================*/

    public CharacterInfo characterInfoScript;


	/*===================== Variables =====================================================================================*/

	public string Name { get; set;}
	public float BankAccount { get; set;}
	public int Reputation { get; set;}
	public int BuildingSize { get; set;} // no. of rooms
	private float buildingUpgradeCost;
	public float BuildingMaintenance { get; set;}
	private int maxEmployees;
	private int maxDealers;
	public float EmployeeSalary { get; set;} // Per Hour
	private float totalEmployeeSalary; // total salary paid to all employees
	public int BusinessAge { get; set;} // in months
	private int productivityBonus;
	public int EquipmentUpgrades { get; set;} // + 10% productivity bonus per upgrade
	private float equipmentUpgradeCost;
	public float MoneyEarned { get; set;}
	public float Profits { get; set;}
	public float Costs { get; set;}
    public List<GameObject> products = new List<GameObject>();

	
	/*===================== List of Employee GameObjects =====================================================================================*/
	[SerializeField]
	private List<GameObject> employees = new List<GameObject> ();
	public List<GameObject> Employees 
	{
		get{ return employees;}
		set{ employees = value;}
	}


	/*===================== List of New Available Employee GameObjects =====================================================================================*/
	[SerializeField]
	private List<GameObject> newAvailableEmployees = new List<GameObject> ();
	public List<GameObject> NewAvailableEmployees 
	{
		get{ return newAvailableEmployees;}
		set{ newAvailableEmployees = value;}
	}


	/*===================== Get and Set Properties =====================================================================================*/

	/*===================== get/set BuildingUpgradeCost =====================================================================================*/

	public float BuildingUpgradeCost {

		get{ 
			buildingUpgradeCost = 0;

			// the cost of every room upgrade is 1000 more then the last
			buildingUpgradeCost = (BuildingSize + 1) * 1000;

			return buildingUpgradeCost;
		}
		set{ buildingUpgradeCost = value;}
	}
	
	/*===================== get/set MaxEmployees =====================================================================================*/

	public int MaxEmployees{

		get{ 
			maxEmployees = 0;

			// maximum number of employees business can have
			// is 5 employees per room
			maxEmployees = BuildingSize * 5;

			return maxEmployees;
		}
		set{ maxEmployees = value;}
	}

	/*===================== get/set MaxDealers =====================================================================================*/

	public int MaxDealers{

		get{ 
			maxDealers = 0;

			// maximum number of dealers a business can have
			// is 1 dealer per room
			maxDealers = BuildingSize;

			return maxDealers;
		}
		set{ maxDealers = value;}
	}

	 
	/*===================== get/set TotalEmployeeSalary =====================================================================================*/

	public float TotalEmployeeSalary {

		// total employee salary is calculated
		// using employees salary * 8 (hours worked in a day)
		get{ 
			totalEmployeeSalary = 0;

			// if there are employees
			if (Employees.Count != 0) {

				// Loop through all employees and calculate salary
				for(int i = 0; i < Employees.Count; i++){

					// sum all employees salaries for one day
				 	totalEmployeeSalary += Employees [i].GetComponent<Employee> ().Salary * 8;
				} // for

				return totalEmployeeSalary;
			} // if

			// otherwise return 0
			return 0;
		}
		set{ totalEmployeeSalary = value;}
	}
	
	/*===================== get/set ProductivityBonus =====================================================================================*/

	public int ProductivityBonus{

		get{
			productivityBonus = 0;

			// adds 1% + or - bonus for each 5 rep, per employee
			productivityBonus += employees.Count * (Reputation / 5); 

			// Adds 10% bonus for each equipment upgrade
			productivityBonus += (EquipmentUpgrades * 10); 
			
			return productivityBonus;
		}
		set{ productivityBonus = value;}
	}
	
	/*===================== get/set EquipmentUpgradeCost =====================================================================================*/

	public float EquipmentUpgradeCost{

		// the equipment upgrades +1 is to get the cost of next upgrade
		// not the cost of the current upgrade number
		get{
			equipmentUpgradeCost = 0;

			// each upgrade costs 20000 more then the last
			equipmentUpgradeCost = (EquipmentUpgrades + 1) * 20000;

			return equipmentUpgradeCost;
		} 
		set{ equipmentUpgradeCost = value;}
	}


    /*===================== Methods =====================================================================================*/

    /*===================== Awake() =====================================================================================*/

    void Awake() {

        // get Script References
        characterInfoScript = gameObject.GetComponent<CharacterInfo>();

        // Sets up business by setting variables to default values
        SetupBusiness();

        // Create Empty GameObject to hold Employees
        businessEmployees = new GameObject("BusinessEmployees");

        // create empty GameObject to hold products
        businessProducts = new GameObject("BusinessProducts");

        // make businessEmployees a child of Business
        businessEmployees.transform.SetParent(gameObject.transform, false);

        // make businessProducts a child of Business
        businessProducts.transform.SetParent(gameObject.transform, false);

        // Populate products array with products
        gameObject.GetComponent<GenerateProducts>().SetUpProducts(products, businessProducts);

    } // Awake()


	/*===================== SetupBusiness() =====================================================================================*/

	// sets up the business to its default values
	public void SetupBusiness() {

		Name = "";
		BankAccount = 0f;
		Reputation = 0; // +25 because of 100 for maintenance and -25 because salary is 800
		BuildingSize = 4;
		BuildingUpgradeCost = BuildingSize *1000;
		BuildingMaintenance = 100; // medium maintenance level
		MaxEmployees = 0;
		EmployeeSalary = 800;
		BusinessAge = 0;
		ProductivityBonus = 0;
		EquipmentUpgrades = 0;

	} // SetupBusiness()


	/*===================== ProduceProducts() =====================================================================================*/
	
	// generates money for business
	// by producing products + selling them
	public void ProduceProducts()
	{
		float bonus = 0;

		// if there are employees to actually work
		if (Employees.Count != 0) {

			MoneyEarned = employees.Count * 20 * 8; // business makes $20 per employee per hour (8 hour day)
		
			bonus = ((float)ProductivityBonus / 100); // getting the productivity bonus %
		
			MoneyEarned = MoneyEarned + (MoneyEarned * bonus); // Adding the productivity bonus on to money earned
		
			BankAccount += MoneyEarned; // adds money earned into bank account
		} // if
	} // ProduceProducts()


	/*===================== SellDrugs() =====================================================================================*/
	
/*	public void SellDrugs(Player player)
	{
		MoneyEarned = dealers.Count * 500;
		
		BankAccount = BankAccount + (MoneyEarned / 2); // half goes to business
		player.BankAccount = player.BankAccount + (MoneyEarned / 2); // half goes to the player
	} // SellDrugs()*/


	/*===================== MakeDrugs() =====================================================================================*/
	
	public void MakeDrugs(Player player)
	{
		MoneyEarned = 5000; // drugs produced = 5,000 a month
		
		BankAccount += (MoneyEarned / 2); // half goes to business
		player.BankAccount += (MoneyEarned / 2); // half goes to the player
	} // MakeDrugs()


	/*===================== PayEmployees() =====================================================================================*/
	
	// pays employees for the month
	public void PayEmployees(){

		float totalSal = 0;

		// get copy of total sal (otherwise a for loop will run everytime TotalEmployeeSalary is called)
		totalSal = TotalEmployeeSalary;

		if(totalSal > BankAccount)
		{
			// flag business as not able to pay salary without going into debt
			Debug.Log("Cannot Afford Employees Salary Without Entering Debt!");
			return;
		} // if

		// if there is a salary to pay
		if (totalSal > 0) {

			// takes the total salary out of the business bank account
			BankAccount -= totalSal;
		} // if
	} // PayEmployees()


	/*===================== PayEmployeesAnyway() =====================================================================================*/
	
	public void PayEmployeesAnyway()
	{
		// takes the total salary out of the business bank account
		// Even when the business is in debt
		BankAccount -= TotalEmployeeSalary;
	} // PayEmployeesAnyway()


	/*===================== GenerateEmployeeApplicants() =====================================================================================*/

	// Creates employees that the player can choose to hire
	public void GenerateEmployeeApplicants(int theAmount){

		for(int i = 0; i < theAmount; i++){

			char gender;

			// instantiate employee
			GameObject newEmployee = (GameObject)Instantiate(employeePrefab); 

			// make employee a child of businessEmployees
			newEmployee.transform.SetParent(businessEmployees.transform, false);

			// get gender for employee
			gender = characterInfoScript.GenerateRandomGender();

			// name the employee
			newEmployee.GetComponent<Employee>().Name = characterInfoScript.GenerateRandomName(gender); 

			// Give Employee Gender
			newEmployee.GetComponent<Employee>().Gender = gender;

			// Give Employee a  work Position
			newEmployee.GetComponent<Employee>().Position = characterInfoScript.GenerateEmployeePosition(Reputation);

			// add employee to NewAvailableEmployees list
			NewAvailableEmployees.Add(newEmployee);
		} // for
	} // GenerateEmployeeApplicants()


	/*===================== HireEmployee() =====================================================================================*/
	
	// Hire an employee that is selected
	public void HireEmployee(GameObject employee){
		
		// Remove employee from the list of new applicants
		NewAvailableEmployees.Remove (employee);

		// Add employee to the list of hired employees
		Employees.Add (employee);
		
	} // HireEmployee()

	/*===================== HireEmployee() =====================================================================================*/

	// Overloaded Method to Hire an employee for specific position
	public void HireEmployee(string position){
	
		char gender;
		
		// instantiate employee
		GameObject newEmployee = (GameObject)Instantiate(employeePrefab); 
		
		// make employee a child of businessEmployees
		newEmployee.transform.SetParent(businessEmployees.transform, false);
		
		// get gender for employee
		gender = characterInfoScript.GenerateRandomGender();
		
		// name the employee
		newEmployee.GetComponent<Employee>().Name = characterInfoScript.GenerateRandomName(gender); 
		
		// Give Employee Gender
		newEmployee.GetComponent<Employee>().Gender = gender;
		
		// Give Employee a work Position
		newEmployee.GetComponent<Employee>().Position = position;
		
		// add employee to employees list
		Employees.Add(newEmployee);
	
	} // HireEmployee()


	/*===================== LoadEmployees() =====================================================================================*/

	// For loading employees when loading save game
	public void LoadEmployees(int theAmount){

		for(int i = 0; i < theAmount; i++){

			// instantiate employee
			GameObject newEmployee = (GameObject)Instantiate(employeePrefab); 
			
			// make employee a child of businessEmployees
			newEmployee.transform.SetParent(businessEmployees.transform, false); 
			
			// add employee to employees list
			Employees.Add(newEmployee);
		} // for
	} // LoadEmployees()


	/*===================== FireEmployee() =====================================================================================*/
	
	public void FireEmployee(GameObject employee){

		// Destroy the employee Object that is selected
		Destroy (employee);

		// Remove it from the list of employees
		Employees.Remove (employee);
	
	} // FireEmployee()


	/*===================== FireAllEmployees() =====================================================================================*/

	// fires all employees
	public void FireAllEmployees()
	{
		// destroys and removes employees from list, start at the back (better performance on list)
		for (int i = Employees.Count; i > 0; i--) {
		
			// destroys employee gameobject
			Destroy (Employees [i-1]);
		
			// removes destroyed employee from list
			Employees.Remove (Employees [i-1]);
		} // for
	} // FireAllEmployees()


	/*===================== RemoveEmployeeApplicant() =====================================================================================*/
	
	public void RemoveEmployeeApplicant(GameObject employee){
		
		// Destroy the employee Object that is selected
		Destroy (employee);
		
		// Remove it from the list of employeeApplicants
		NewAvailableEmployees.Remove (employee);
		
	} // RemoveEmployeeApplicant()


	/*===================== PayMaintenance() =====================================================================================*/
	
	// to pay the buildings monthly maintenance bill
	public void PayMaintenance()
	{
		if(BuildingMaintenance > BankAccount)
		{
			// flag business not being able to pay maintenance without going into debt
			Debug.Log("Cannot Afford Building Maintenance!");
			return;
		}
		// takes the Maintenance out of the business bank account
		BankAccount -= BuildingMaintenance;
	} // PayMaintenance()


	/*===================== SetBuildingMaintenanceLevel() =====================================================================================*/
	
	public void SetBuildingMaintenanceLevel(int theLevel)
	{
		float oldMaintenanceCost=0;
		oldMaintenanceCost = BuildingMaintenance; // to make sure player doesn't keep changing 
		// maintenance to endless get reputation

		// return reputation that was given for a particular
		// maintenance level
		if(oldMaintenanceCost == 0)
		{
			Reputation += 50; // give back 50 rep lost
		}
		else if(oldMaintenanceCost == 50)
		{
			Reputation += 25; // give back 25 rep lost
		}
		else if(oldMaintenanceCost == 100)
		{
			Reputation -= 25; // take back 25 rep given
		}
		else if(oldMaintenanceCost == 150)
		{
			Reputation -= 50; // take back 50 rep given
		} // if

		// set the new maintenance level and give rep
		switch(theLevel)
		{
		case 1: // no maintenance
			BuildingMaintenance = 0f; // sets maintenance cost
			Reputation -= 50; // loose 50 rep
			break;
		case 2: // low maintenance
			BuildingMaintenance = 50f; // sets maintenance cost
			Reputation -= 25; // loose 25 rep
			break;
		case 3: // medium maintenance
			BuildingMaintenance = 100f; // sets maintenance cost
			Reputation += 25; // get 25 rep
			break;
		case 4: // high maintenance
			BuildingMaintenance = 150f; // sets maintenance cost
			Reputation += 50; // get 50 rep
			break;
		} // switch
	} // SetBuildingMaintenanceLevel()


	/*===================== SetEmployeeSalaryLevel() =====================================================================================*/
	
	public void SetEmployeeSalaryLevel(int theLevel)
	{
		float oldSalary=0;
		oldSalary = EmployeeSalary; // to make sure player doesn't keep changing 
		// Salary to endless get reputation

		// return rep given for setting salary level
		if(oldSalary == 400)
		{
			Reputation += 50; // give back 50 rep
		}
		else if(oldSalary == 800)
		{
			Reputation += 25; // give back 25 rep
		}
		else if(oldSalary == 1000)
		{
			Reputation -= 25; // take back 25 rep
		}
		else if(oldSalary == 1200)
		{
			Reputation -= 50; // take back 50 rep
		} // if

		// set new employeeSalary level
		switch(theLevel)
		{
		case 1: // Low
			EmployeeSalary = 400f; // sets Salary
			Reputation -= 50; // loose 50 rep
			break;
		case 2: // medium
			EmployeeSalary = 800f;
			Reputation -= 25; // loose 25 rep
			break;
		case 3: // good
			EmployeeSalary = 1000f;
			Reputation += 25; // get 25 rep
			break;
		case 4: // Great
			EmployeeSalary = 1200f;
			Reputation += 50; // get 50 rep
			break;
		} // switch
	} // SetEmployeeSalaryLevel()


	/*===================== UpgradeBuilding() =====================================================================================*/
	
	public void UpgradeBuilding()
	{
		if(BuildingUpgradeCost > BankAccount)
		{
			// flag business as not being able to afford upgrade
			Debug.Log("Cannot Afford Building Upgrade!");
			return;
		} // if
		
		BuildingSize += 1; // increase building size by 1

		// Pay for upgrade
		BankAccount -= BuildingUpgradeCost;
	} // UpgradeBuilding()


	/*===================== UpgradeEquipment() =====================================================================================*/
	
	public void UpgradeEquipment()
	{
		if(EquipmentUpgradeCost > BankAccount)
		{
			// flag business as not being able to afford equipment upgrade
			Debug.Log("Cannot Afford Equipment Upgrade!");
			return;
		} // if
		
		EquipmentUpgrades += 1; // increase equipment upgrades by 1

		// pay for upgrade
		BankAccount -= EquipmentUpgradeCost;
	} // UpgradeEquipment()


	/*===================== BuildDrugLab() =====================================================================================*/
	
	public void BuildDrugLab()
	{
		if(BankAccount < 50000)
		{
			// flag business as not being able to afford to build a drug lab
			Debug.Log("Cannot Afford To Build Drug Lab!");
			return;
		} // if

		// Pay for drug lab
		BankAccount -= 50000; // cost 50000 to build a lab
		
	} // BuildDrugLab()


	/*===================== DisplayBusinessInfo() =====================================================================================*/
	
	public string DisplayBusinessInfo()
	{
		StringBuilder str = new StringBuilder();


		// Add Business Name
		str.Append ("Name: ");
		str.Append (Name);

		// add business Age
		str.Append ("\nBusiness Age: ");
		str.Append (BusinessAge);
		str.Append (" Months");

		// Add business bank account
		str.Append ("\nBank Account: ");
		str.Append (BankAccount);

		// add business reputation]
		str.Append ("\nReputation: ");
		str.Append (Reputation);
	
		// add the size of the building
		str.Append ("\nRooms In The Building: ");
		str.Append (BuildingSize);

		// add cost of mantenance
		str.Append ("\nBuilding Maintenance: ");
		str.Append (BuildingMaintenance);

		// add employees salary per month
		str.Append ("\nEmployee Salary Per Month: ");
		str.Append (EmployeeSalary);

		// add business productivity bonus
		str.Append ("\nBusiness Productivity Bonus: ");
		str.Append (ProductivityBonus);
		str.Append("%");

		// add number of equipment upgrades
		str.Append ("\nBusiness Equipment Upgrades: ");
		str.Append (EquipmentUpgrades);

		// return string
		return str.ToString();
	} // DisplayBusinessInfo()
} // class