using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private string Name;
    //for mouse click sound effect
    private AudioManager audio_manager;
    
    private void Start()
    {
        audio_manager = FindAnyObjectByType<AudioManager>();
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(Name); // will load the game/change scenes when button is pressed
    }

    public void click_sound()
    {
        audio_manager.Play("Button Click"); //play this sfx when a menu UI button is clicked
    }

}
