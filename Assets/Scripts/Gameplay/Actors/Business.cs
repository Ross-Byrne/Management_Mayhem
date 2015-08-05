using UnityEngine;
using System.Collections;
using System.Collections.Generic; 	// to use Lists
using System.Text; 					// to use StringBuilder

public class Business : MonoBehaviour {

	/*===================== GameObjects =====================================================================================*/

	public GameObject employeePrefab;


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

	
	/*===================== List of Employee GameObjects =====================================================================================*/

	private List<GameObject> employees = new List<GameObject> ();
	public List<GameObject> Employees 
	{
		get{ return employees;}
		set{ employees = value;}
	}


	/*===================== List of New Available Employee GameObjects =====================================================================================*/
	
	private List<GameObject> newAvailableEmployees = new List<GameObject> ();
	public List<GameObject> NewAvailableEmployees 
	{
		get{ return newAvailableEmployees;}
		set{ newAvailableEmployees = value;}
	}


	/*===================== Get and Set Properties =====================================================================================*/

	/*===================== get/set BuildingUpgradeCost =====================================================================================*/

	public float BuildingUpgradeCost 
	{
		get{ return BuildingSize * 1000;}
		set{ buildingUpgradeCost = value;}
	}
	
	/*===================== get/set MaxEmployees =====================================================================================*/

	public int MaxEmployees
	{
		// maximum number of employees business can have
		// is 5 employees per room
		get{ return BuildingSize * 5;}
		set{ maxEmployees = value;}
	}

	/*===================== get/set MaxDealers =====================================================================================*/

	public int MaxDealers
	{
		// maximum number of dealers a business can have
		// is 1 dealer per room
		get{ return BuildingSize;}
		set{ maxDealers = value;}
	}

	 
	/*===================== get/set TotalEmployeeSalary =====================================================================================*/

	public float TotalEmployeeSalary
	{
		// total employee salary is calculated
		// using employees salary * number of employees * 8 (hours worked in a day)
		get{ return Employees.Count * Employees[0].GetComponent<Employee>().Salary * 8;}
		set{ totalEmployeeSalary = value;}
	}
	
	/*===================== get/set ProductivityBonus =====================================================================================*/

	public int ProductivityBonus
	{
		get{
			int bonus = 0;

			// adds 1% + or - bonus for each 5 rep, per employee
			bonus += employees.Count * (Reputation / 5); 

			// Adds 10% bonus for each equipment upgrade
			bonus += (EquipmentUpgrades * 10); 
			
			return bonus;
		}
		set{ productivityBonus = value;}
	}
	
	/*===================== get/set EquipmentUpgradeCost =====================================================================================*/

	public float EquipmentUpgradeCost
	{
		// the equipment upgrades +1 is to get the cost of next upgrade
		// not the cost of the current upgrade number
		get{return (EquipmentUpgrades + 1) * 20000;} // each upgrade costs 20000 more then the last
		set{ equipmentUpgradeCost = value;}
	}


	/*===================== Methods =====================================================================================*/

	/*===================== Awake() =====================================================================================*/

	void Awake()
	{
		// get Script References
		characterInfoScript = gameObject.GetComponent<CharacterInfo>();

		// Sets up business by setting variables to default values
		SetupBusiness();
	} // Awake()


	/*===================== SetupBusiness() =====================================================================================*/

	// sets up the business to its default values
	public void SetupBusiness()
	{
		Name = "";
		BankAccount = 0f;
		Reputation = 0; // +25 because of 100 for maintenance and -25 because salary is 800
		BuildingSize = 3;
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
		
		MoneyEarned = employees.Count * 20 * 8; // business makes $20 per employee per hour (8 hour day)
		
		bonus = ((float)ProductivityBonus / 100); // getting the productivity bonus %
		
		MoneyEarned = MoneyEarned + (MoneyEarned * bonus); // Adding the productivity bonus on to money earned
		
		BankAccount += MoneyEarned; // adds money earned into bank account
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
	public void PayEmployees()
	{
		if(TotalEmployeeSalary > BankAccount)
		{
			// flag business as not able to pay salary without going into debt
			Debug.Log("Cannot Afford Employees Salary Without Entering Debt!");
			return;
		}
		// takes the total salary out of the business bank account
		BankAccount -= TotalEmployeeSalary;
	} // PayEmployees()


	/*===================== PayEmployeesAnyway() =====================================================================================*/
	
	public void PayEmployeesAnyway()
	{
		// takes the total salary out of the business bank account
		// Even when the business is in debt
		BankAccount -= TotalEmployeeSalary;
	} // PayEmployeesAnyway()


	/*===================== HireEmployees() =====================================================================================*/
	
	public void HireEmployees(int theAmount){

		for(int i = 0; i < theAmount; i++){

			char gender;

			// instantiate employee
			GameObject newEmployee = (GameObject)Instantiate(employeePrefab); 

			// make employee a child of Business
			newEmployee.transform.SetParent(gameObject.transform, false);

			// get gender for employee
			gender = characterInfoScript.GenerateRandomGender();

			// name the employee
			newEmployee.GetComponent<Employee>().Name = characterInfoScript.GenerateRandomName(gender); 

			// Give Employee Gender
			newEmployee.GetComponent<Employee>().Gender = gender;

			// Give Employee a  work Position
			newEmployee.GetComponent<Employee>().Position = characterInfoScript.GenerateEmployeePosition(Reputation);

			// add employee to employees list
			Employees.Add(newEmployee);
		} // for
	} // HireEmployees()


	/*===================== HireEmployees() =====================================================================================*/

	// Overloaded method to hire a employee for specific position
	public void HireEmployees(string position){
	
		char gender;
		
		// instantiate employee
		GameObject newEmployee = (GameObject)Instantiate(employeePrefab); 
		
		// make employee a child of Business
		newEmployee.transform.SetParent(gameObject.transform, false);
		
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
	
	} // HireEmployees()


	/*===================== LoadEmployees() =====================================================================================*/

	// For loading employees when loading save game
	public void LoadEmployees(int theAmount){

		for(int i = 0; i < theAmount; i++){

			// instantiate employee
			GameObject newEmployee = (GameObject)Instantiate(employeePrefab); 
			
			// make employee a child of Business
			newEmployee.transform.SetParent(gameObject.transform, false); 
			
			// add employee to employees list
			Employees.Add(newEmployee);
		} // for
	} // LoadEmployees()


	/*===================== FireEmployees() =====================================================================================*/
	
	public void FireEmployees(int theAmount){

		int employeeCount = 0;

		// if the amount is = to all employees, clear list
		if(theAmount >= employees.Count) {

			// fires all employees
			FireAllEmployees();
		} else {

			// removes the number entered, starting at the back of the list (better performance on list)  
			while(theAmount > 0){

				// gets number of employees
				employeeCount = Employees.Count;
		
				// destroys employee gameobject
				Destroy(Employees[employeeCount-1]);

				// removes destroyed employee from list
				Employees.Remove(Employees[employeeCount-1]);

				// decrement
				theAmount--;
			} // while

		} // if else
	} // FireEmployees()


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


	/*===================== PrintListOfEmployees() =====================================================================================*/
	
	public string PrintListOfEmployees()
	{
		StringBuilder employeeNames = new StringBuilder();
		int i = 0;
		
		for (i = 0; i < Employees.Count; i++) {
			employeeNames.Append ("\n");
			employeeNames.Append (Employees [i].GetComponent<Employee> ().Name);
		}
		
		return employeeNames.ToString ();
	} // PrintListOfEmployees()


	/*===================== HireDealers() =====================================================================================*/
	
	/*public void HireDealers(GameManager gameManager, int theAmount)
	{
		Random rnd = new Random();
		int rndValue=0;
		String tempName="";
		
		for(int i = 0; i < theAmount; i++)
		{
			Employee dealer = new Dealer(); // create dealer - Polymorphism
			
			rndValue = rnd.nextInt(14); // get a random value 
			tempName = gameManager.getRandomFName(rndValue); // use value to get random first name
			
			rndValue = rnd.nextInt(14); // get another random value
			tempName += gameManager.getRandomLName(rndValue); // choose a random last name and add it on to the first name
			
			dealer.setName(tempName); // name the employee
			dealers.add(dealer); // add dealer to dealers list
		} // for
	} // HireDealers()*/


	/*===================== FireDealers() =====================================================================================*/
	
	/*	public void FireDealers(GameManager gameManager, int theAmount)
	{
		if(theAmount == dealers.size()) // if the amount is = to all dealers, clear list
		{
			dealers.clear();
		}
		else // remove the number entered
		{
			while(theAmount > 0)
				dealers.remove(theAmount--);
		} // if else
	} // FireDealers()*/


	/*===================== PrintListOfDealers() =====================================================================================*/
	
	/*public void PrintListOfDealers()
	{
		String tempNames = "";
		
		for(int i = 0; i < dealers.size(); i++)
			tempNames += "\n\t" + dealers.get(i);
		
		System.out.println("Dealers: " + tempNames);
	} // PrintListOfDealers()*/


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