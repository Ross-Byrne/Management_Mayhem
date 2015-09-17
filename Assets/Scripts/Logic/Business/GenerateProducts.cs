using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Script that handles the generation of products the business can produce.

public class GenerateProducts : MonoBehaviour {

    /*===================== GameObjects =====================================================================================*/

    public GameObject productPrefab;


    /*===================== Variables =====================================================================================*/

    public int numOfProducts;
    public string[] names = {"Micro Chips", "Circuit Boards", "Memory Modules", "Hard Drives", "Optical Drives", "Video Cards" };
    public int[] resourceCost = { 2, 3, 6, 7, 9, 12 };
    public int[] powerUsage = { 5, 5, 5, 5, 5, 10};
    public float[] profit = { 4f, 5.50f, 7f, 9f, 12f, 15f };

    // the cost of each resource unit
    public float costOfResourceUnits = 5f;

    /*===================== Methods =====================================================================================*/

    /*===================== SetUpProducts() =====================================================================================*/

    // sets up the product values
    public void SetUpProducts(List<GameObject> products, GameObject businessProducts) {

        Debug.Log("Entered");


        numOfProducts = 0;

        // get the number of products, based on number of names
        numOfProducts = names.Length;

        // if there aren't enough values to populate products
        if(resourceCost.Length != numOfProducts ||
            powerUsage.Length != numOfProducts ||
            profit.Length != numOfProducts) {

            // exit 
            return;

        } // if

        Debug.Log("Passed");

        // populate product values
        for(int i = 0; i < numOfProducts; i++) {

            // instantiate product
            GameObject newProduct = (GameObject)Instantiate(productPrefab);

            // make newProduct a child of businessProducts
            newProduct.transform.SetParent(businessProducts.transform, false);

            // give products their number
            newProduct.GetComponent<Product>().Number = i + 1;

            // give products their names
            newProduct.GetComponent<Product>().Name = names[i];

            // give products thier resource cost
            newProduct.GetComponent<Product>().ResourceCost = resourceCost[i];

            // give products their power usage
            newProduct.GetComponent<Product>().PowerUsage = powerUsage[i];

            // calculate products market value
            newProduct.GetComponent<Product>().MarketValue = ((resourceCost[i] * costOfResourceUnits) + profit[i]);

            products.Add(newProduct);

        } // for

    } // SetUpProducts()


} // class
