using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private string Name; // Name of the scene to load
    private AudioManager audio_manager;

    private void Start()
    {
        audio_manager = FindAnyObjectByType<AudioManager>();
    }

    public void ChangeScene()
    {
        StartCoroutine(WaitAndChangeScene()); // Start the coroutine to wait before changing the scene
    }

    public void click_sound()
    {
        audio_manager.Play("Button Click"); // Play the button click sound effect
    }

    public IEnumerator WaitAndChangeScene()
    {
        click_sound(); // Play the sound effect
        yield return new WaitForSeconds(0.3f); // Wait for 0.3 seconds
        SceneManager.LoadScene(Name); // Load the new scene after the delay
    }
}
