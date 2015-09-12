using UnityEngine;
using System.Collections;

// Product object. These products are producted by the business once unlocked.

public class Product : MonoBehaviour {

    /*===================== Variables =====================================================================================*/

    public int Number { get; set; }
    public string Name { get; set; }
    public int ResourceCost { get; set; }
    public int PowerUsage { get; set; }
    public float MarketValue { get; set; }


} // class
