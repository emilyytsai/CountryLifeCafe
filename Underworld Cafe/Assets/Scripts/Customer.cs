using UnityEngine;

public class Customer : MonoBehaviour
{
    private MoneyScript moneyScript; //reference to money script

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        customer_controller = GameObject.FindGameObjectWithTag("Customer").GetComponent<CustomerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
