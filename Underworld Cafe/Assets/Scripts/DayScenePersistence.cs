using UnityEngine;
using UnityEngine.SceneManagement;

public class DayScenePersistence : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        foreach (GameObject obj in SceneManager.GetActiveScene().GetRootGameObjects())
        {
            DontDestroyOnLoad(obj);
        }
    }
}
