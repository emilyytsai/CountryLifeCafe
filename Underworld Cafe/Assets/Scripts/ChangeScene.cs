// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class MainMenu : MonoBehaviour
// {
//     [SerializeField]
//     private string Name; // Name of the scene to load
//     private AudioManager audio_manager;
//     [SerializeField] RectTransform fader;

//     private void Start()
//     {
//         audio_manager = FindAnyObjectByType<AudioManager>();
//     }

//     public void ChangeScene()
//     {
//         StartCoroutine(WaitAndChangeScene()); // Start the coroutine to wait before changing the scene
//     }

// public void OpenCreditsScene() {
//     // Activate the fader so it's visible
//     fader.gameObject.SetActive(true);
    
//     // Instantly set the scale to zero (hidden)
//     LeanTween.scale(fader, Vector3.zero, 0f);
    
//     // Scale the fader to (1,1,1) over 1 second with an ease in/out quad effect.
//     LeanTween.scale(fader, new Vector3(1, 1, 1), 1.0f)
//              .setEase(LeanTweenType.easeInOutQuad)
//              .setOnComplete(() => {
//                  // Additional delay example: after scaling is done, wait another second before changing scene.
//                  Invoke("WaitAndChangeScene", 1.0f);
//              });
// }

//     // public void OpenCreditsScene() {
//     //     fader.gameObject.SetActive(true);
//     //     // Instantly set to zero so it's not visible
//     //     fader.transform.localScale = Vector3.zero;

//     //     // Animate from scale (0,0,0) to (1,1,1) over 1 second.
//     //     // Ensure your fader's RectTransform is set up to cover the screen at (1,1,1).
//     //     LeanTween.scale(fader.gameObject, Vector3.one, 0.5f)
//     //          .setEase(LeanTweenType.easeInOutQuad)
//     //          .setOnComplete(() => {
//     //              // Additional code after animation completes.
//     //          });
//     // }

//     // public void OpenCreditsScene() {
//     //     fader.gameObject.SetActive(true);
//     //     LeanTween.scale(fader, new Vector3(1, 1, 1), 0f); // Start at full size
//     //     LeanTween.scale(fader, Vector3.zero, 0.2f) // Shrink to zero
//     //         .setEase(LeanTweenType.easeInOutQuad)
//     //         .setOnComplete(() => {
//     //             // Perform any actions after the animation completes
//     //         });
//     // }

//     public void OpenGameObjectiveScene() {
//         fader.gameObject.SetActive(true);
//         LeanTween.scale(fader, new Vector3(1, 1, 1), 0f); // Start at full size
//         LeanTween.scale(fader, Vector3.zero, 0.2f) // Shrink to zero
//             .setEase(LeanTweenType.easeInOutQuad)
//             .setOnComplete(() => {
//                 // Perform any actions after the animation completes
//             });
//     }

//     public void click_sound()
//     {
//         audio_manager.Play("Button Click"); // Play the button click sound effect
//     }

//     public IEnumerator WaitAndChangeScene()
//     {
//         click_sound(); // Play the sound effect
//         yield return new WaitForSeconds(0.1f); // Wait for 0.1 seconds
//         SceneManager.LoadScene(Name); // Load the new scene after the delay
//     }
// }

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private string Name; // Name of the scene to load
    private AudioManager audio_manager;
    [SerializeField] RectTransform fader;

    private void Start()
    {
        // Find the AudioManager in the scene.
        audio_manager = FindAnyObjectByType<AudioManager>();
    }

    public void ChangeScene()
    {
        // This is the function you'll attach to your button OnClick.
        StartCoroutine(WaitAndChangeScene());
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
}