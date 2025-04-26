using UnityEngine;
using UnityEngine.UI; 
using TMPro;
using UnityEngine.SceneManagement; //getting scene name for time by day function

//*low priority task* - implement logic to change customer emotion based on time left
//(50% left = neutral face, 15% left = angry face)
//**note** this task can be implemented in timer script or customer script but use unity animator

public class PatienceTimer : MonoBehaviour

{
    [SerializeField]
    private Customer customer; //reference to customer script
    public Image patienceBar;
    public Image patienceBar2; //this is the shadow of the bar
    public GameObject feedback;

    //custom colors for the bar
    private Color start_color = new Color(0.5f, 0.9f, 0.5f); //R,G,B, (optional) alpha 
    private Color end_color = new Color(0.9f, 0.5f, 0.5f);

    private float lerpSpeed;
    public float timer;
    public float day_time;

    //timer for each day
    //NOTE* for demo purposes day 1 is set to 10 sec temporarily

    //private float day1_time = 30f;
    //private float day2_time = 20f;
    //private float day3_time = 12f;

    private void Start()
    {
        //intialize timer accoring to what day
        time_by_day();
    }

    private void Update()
    {
        ////speed that the bar gets filled
        //lerpSpeed = 3f * Time.deltaTime;
        
        //lerpSpeed += Time.deltaTime;

        BarFiller(); //call here to also update the filler
        ColorChanger(); //updates color
    }

    void BarFiller()
    {
        ////reference: https://docs.unity3d.com/ScriptReference/Mathf.Lerp.html
        //////https://gamedevbeginner.com/the-right-way-to-lerp-in-unity-with-examples/

        //patienceBar.fillAmount -= 1.0f / 30f * Time.deltaTime;

        //reduce time on timer
        timer -= Time.deltaTime;

        //bar fill amount based off current timer and max patience
        float current_patience = Mathf.Clamp(timer / day_time, 0f, 1f);

        patienceBar.fillAmount = current_patience;

        //stop decreasing at 0 sec
        if (timer <= 0f)
        {
            timer = 0f;
            feedback.SetActive(true);
            StartCoroutine(customer.Leave());

            //destroy the patience bar/shadow, salad order, & text bubble after serving customer
            UIManager.Instance.hide_order();
        }
    }

    void ColorChanger()
    {
        ////https://docs.unity3d.com/ScriptReference/Color.Lerp.html

        float patience_ratio = Mathf.Clamp(timer / day_time, 0f, 1f);

        Color bar_color = Color.Lerp(start_color, end_color, 1f - patience_ratio); //lerpspeed is now based off the ratio
        patienceBar.color = bar_color;
    }

    //set time by using what day it is/scene name
    void time_by_day()
    {
        string scene_name = SceneManager.GetActiveScene().name;

        if (scene_name.Contains("Day 1"))
        {
            timer = 30f;
            day_time = 30f;
        }
        else if (scene_name.Contains("Day 2"))
        {
            timer = 20f;
            day_time = 20f;
        }
        else if (scene_name.Contains("Day 3"))
        {
            timer = 12f;
            day_time = 12f;
        }
        else
        {
            timer = 30f; //in case, set back to 30sec
            day_time = 30f;
        }
    }


    public void reset_timer()
    {
        time_by_day();
        
        patienceBar.fillAmount = 1f;
        patienceBar.color = start_color;
        
        feedback.SetActive(false);
    }
}