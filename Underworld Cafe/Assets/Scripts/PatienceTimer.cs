using UnityEngine;
using UnityEngine.UI; 
using TMPro;

//change lerpSpeed to the according customer patience per day
//day 1 timer = 30 seconds, day 2 timer = 20 seconds, day 3 timer = 12 seconds

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
    private float timer;

    //timer for each day
    //NOTE* for demo purposes day 1 is set to 10 sec temporarily
    private float day1_time = 10f;

    //track if timer ran out
    private bool timer_expired = false;

    //private float day1_time = 30f;
    //private float day2_time = 20f;
    //private float day3_time = 12f;

    private void Start()
    {
        //intialize w/ day 1 time
        timer = day1_time;
        timer_expired = false;
    }

    private void Update()
    {
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
        float current_patience = Mathf.Clamp(timer / day1_time, 0f, 1f);

        patienceBar.fillAmount = current_patience;

        //stop decreasing at 0 sec
        if (timer <= 0f && !timer_expired)
        {
            timer = 0f;
            timer_expired = true;
            feedback.SetActive(true);

            if (customer != null)
            {
                StartCoroutine(customer.Leave(true));
            }

            //destroy the patience bar/shadow, salad order, & text bubble after serving customer
            UIManager.Instance.hide_order();
        }
    }

    void ColorChanger()
    {
        ////https://docs.unity3d.com/ScriptReference/Color.Lerp.html

        float patience_ratio = Mathf.Clamp(timer / day1_time, 0f, 1f);

        Color bar_color = Color.Lerp(start_color, end_color, 1f - patience_ratio); //lerpspeed is now based off the ratio
        patienceBar.color = bar_color;
    }

    public void reset_timer()
    {
        timer = day1_time;
        timer_expired = false;
        
        patienceBar.fillAmount = 1f;
        patienceBar.color = start_color;
        
        feedback.SetActive(false);
    }
}