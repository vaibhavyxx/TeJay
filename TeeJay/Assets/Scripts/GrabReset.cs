//Only for intro scene - attach it to objects tagged with grab
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;

public class GrabReset : MonoBehaviour
{
    ButtonControl resetButton;
    Vector3 originalTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalTransform = this.transform.position;
    }

    private void Update()
    {
        resetButton = Gamepad.current.xButton;

        //if the scene is intro then if reset is pressed all the objects respawn to original point
        if (SceneManager.GetActiveScene().name == "Introduction")
        {
            if (resetButton.isPressed)
            {
                this.transform.position = originalTransform;
            }
        }
    }
}
