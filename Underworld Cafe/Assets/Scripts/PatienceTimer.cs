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
    //public Image healthRing;
    
    //public PlayerScript player;

    //private float lerpSpeed;


    //private void Start()
    //{
        ////find player in the scene
        //player = FindObjectOfType<PlayerScript>();
    //}


    //private void Update()
    //{
        ////speed that the health indicator gets filled
        //lerpSpeed = 3f * Time.deltaTime;

        //healthText.text = " " + player.PlayerHealth.ToString();

        //HealthFiller(); //call here to also update the filler
        //ColorChanger(); //updates color
    //}


    //void HealthFiller()
    //{
        ////dividing health by max health since max fill amount is 1 so now value of health = between 0 and 1
        //////also convert the int to float for the division
        //float currentHealth = (float)player.PlayerHealth / player.MaxPlayerHealth;

        ////reference: https://docs.unity3d.com/ScriptReference/Mathf.Lerp.html
        //////https://gamedevbeginner.com/the-right-way-to-lerp-in-unity-with-examples/
        //healthRing.fillAmount = Mathf.Lerp(healthRing.fillAmount, currentHealth, lerpSpeed);
    //}


    //void ColorChanger()
    //{
        //float currentHealth = (float)player.PlayerHealth / player.MaxPlayerHealth;

        ////https://docs.unity3d.com/ScriptReference/Color.Lerp.html
        //Color healthColor = Color.Lerp(Color.red, Color.green, currentHealth);
        //healthRing.color = healthColor;
    //}
    
}