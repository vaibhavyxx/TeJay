//Made for intro scene only, to jump back to the last spawn after it falls onto the ground

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;

public class DropRespawn : MonoBehaviour
{
    public Transform respawnTransform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = respawnTransform.position;
        }
    }
}
