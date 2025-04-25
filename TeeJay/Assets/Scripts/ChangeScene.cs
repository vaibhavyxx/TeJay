using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

//Also lets you reset to onboarding scene
public class ChangeScene : MonoBehaviour
{
    ButtonControl resetButton;
    public string sceneName;

    //Loads a new scene
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //SceneManager.LoadScene(sceneName);
            StartCoroutine(LoadYourAsyncScene(sceneName));
        }
    }
    private void Update()
    {
        resetButton = Gamepad.current.xButton;
        
        //Resets it back to intro scene for new players
        if(SceneManager.GetActiveScene().name != "Introduction")
        {
            if (resetButton.isPressed)
            {
                StartCoroutine(LoadYourAsyncScene("Introduction"));
            }
        }
    }

    //From unity documentation
    IEnumerator LoadYourAsyncScene(string scene)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
