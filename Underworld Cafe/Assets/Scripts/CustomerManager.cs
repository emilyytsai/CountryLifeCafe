using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    //customer container
    public GameObject[] customers; //array of customer game objects

    private int current_customer_index = 0; //customer counter

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        next_customer();
    }
    //move thru the array only when this function is called
    public void next_customer()
    {
        if (current_customer_index < customers.Length)
        {
            customers[current_customer_index].SetActive(true); //spawn the current customer
            current_customer_index++;
        }
        else //once counter is 3
        {
            Debug.Log("day 1 complete");
            //later this is where the day summary will be setactive
        }
    }
}
