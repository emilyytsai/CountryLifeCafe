using UnityEngine;
using UnityEngine.UI; 
using TMPro;

//customer's patience timer will be based off an old player health indicator i made
//change player -> customer
//change lerpSpeed to the according customer patience per day
//day 1 timer = 30 seconds, day 2 timer = 20 seconds, day 3 timer = 12 seconds

//*low priority task* - implement logic to change customer emotion based on time left
//(50% left = neutral face, 15% left = angry face)
//**note** this task can be implemented in timer script or customer script but use unity animator

//UNCOMMENT LINES WITH "//" IN FRONT AFTER THIS LINE
public class PatienceTimer : MonoBehaviour

{
    //public TextMeshProUGUI healthText;
    public Image patienceBar;
    
    private Customer customerScript; //reference customer script variables

    private float lerpSpeed;


    private void Start()
    {
        ////find player in the scene
        customer = FindObjectOfType<customer>();
    }


    private void Update()
    {
        ////speed that the health indicator gets filled
        lerpSpeed = 3f * Time.deltaTime;

        //healthText.text = " " + player.PlayerHealth.ToString();

        BarFiller(); //call here to also update the filler
        ColorChanger(); //updates color
    }


    void HealthFiller()
    {
        ////dividing health by max health since max fill amount is 1 so now value of health = between 0 and 1
        //////also convert the int to float for the division
        float current_patience = (float)customer.customer_patience / customer.max_patience;

        ////reference: https://docs.unity3d.com/ScriptReference/Mathf.Lerp.html
        //////https://gamedevbeginner.com/the-right-way-to-lerp-in-unity-with-examples/
        patienceBar.fillAmount = Mathf.Lerp(patienceBar.fillAmount, current_patience, lerpSpeed);
    }


    void ColorChanger()
    {
        float current_patience = (float)customer.customer_patience / customer.max_patience;

        ////https://docs.unity3d.com/ScriptReference/Color.Lerp.html
        Color bar_color = Color.Lerp(Color.red, Color.green, current_patience);
        patienceBar.color = bar_color;
    }
    
}