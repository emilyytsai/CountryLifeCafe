using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private string Name; // Name of the scene to load
    private AudioManager audio_manager;
    [SerializeField] RectTransform fader;

    //to stop the moon/sun glow particle effect during the salad transition
    public GameObject glow_effect;

    private void Start()
    {
        // Find the AudioManager in the scene.
        audio_manager = FindAnyObjectByType<AudioManager>();
    }

    public void ChangeScene()
    {
        // This is the function you'll attach to your button OnClick.
        StartCoroutine(WaitAndChangeScene());

        //stop the moon/sun glow effect
        StartCoroutine(stop_glow());
    }

    public void OpenScene()
    {
        // Activate the fader so it's visible
        fader.gameObject.SetActive(true);
        // Instantly set the scale to zero (hidden)
        LeanTween.scale(fader, Vector3.zero, 0f);
        // Scale the fader to (1,1,1) over 1 second with an ease in/out quad effect.
        LeanTween.scale(fader, new Vector3(1, 1, 1), 1.0f)
                 .setEase(LeanTweenType.easeInOutQuad)
                 .setOnComplete(() => {
                     // After scaling, wait another second before changing the scene.
                     Invoke("DelayedChangeScene", 1.0f);
                 });
    }

    public void OpenCreditsScene()
    {
        // Activate the fader so it's visible
        fader.gameObject.SetActive(true);
        // Instantly set the scale to zero (hidden)
        LeanTween.scale(fader, Vector3.zero, 0f);
        // Scale the fader to (1,1,1) over 1 second with an ease in/out quad effect.
        LeanTween.scale(fader, new Vector3(1, 1, 1), 1.0f)
                 .setEase(LeanTweenType.easeInOutQuad)
                 .setOnComplete(() => {
                     // After scaling, wait another second before changing the scene.
                     Invoke("DelayedChangeScene", 1.0f);
                 });
    }


    // New helper method for invoking the scene change
    private void DelayedChangeScene()
    {
        StartCoroutine(WaitAndChangeScene());
    }

    public void OpenGameObjectiveScene()
    {
        fader.gameObject.SetActive(true);
        // Instantly set to full size
        LeanTween.scale(fader, new Vector3(1, 1, 1), 0f);
        // Shrink to zero over 0.2f seconds
        LeanTween.scale(fader, Vector3.zero, 0.2f)
                 .setEase(LeanTweenType.easeInOutQuad)
                 .setOnComplete(() => {
                     // Perform any actions after the animation completes
                 });
    }

    public void click_sound()
    {
        // This calls the AudioManager to play your "Button Click" sound.
        audio_manager.Play("Button Click");
    }

    public IEnumerator WaitAndChangeScene()
    {
        click_sound(); // Play the sound effect
        yield return new WaitForSeconds(0.9f); // Wait 0.1 seconds
        SceneManager.LoadScene(Name); // Load the new scene after the delay
    }

    //add a slight delay before the glow effect is stopped
    public IEnumerator stop_glow()
    {
        yield return new WaitForSeconds(0.5f);
        
        if (glow_effect != null)
        {
            glow_effect.SetActive(false);
        }
    }

    //only for quit button**
    //moved from separate quit button script to here for better organization
    public void QuitGame() 
    {
        Application.Quit();
        Debug.Log("game quit");
    }
}