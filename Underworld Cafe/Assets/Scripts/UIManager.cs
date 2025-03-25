using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    //Day 1 Manager Script//
    
    public TextMeshProUGUI text;
    private Day1 day1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        day1 = FindAnyObjectByType<Day1>();
        // Check the current scene name
        if (SceneManager.GetActiveScene().name == "DaySummary")
        {
            // Perform actions specific to "MyScene"
            Debug.Log("Running actions for Day Summary");
            text.text = "Good job! Here are your statistics for the day!/nMoney earned:/nCustomers served:n/Customers unhappy";        

        }
        else if (SceneManager.GetActiveScene().name == "Half Kitchen & Half Window")
        {
            // Perform actions specific to "AnotherScene"
            Debug.Log("Running actions for Kitchen");
            text.text = "You're taking too long, I'm leaving!";     
            if (day1.orderCorrect)
            {
                text.text = "Thanks for the salad!";     
            }
            else 
            {
                text.text = "This isn't my order.";
            }
        }
    }

}
