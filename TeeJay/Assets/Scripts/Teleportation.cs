//Helps in travelling from one portal to another transform or scene itself
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleportation : MonoBehaviour
{
    [SerializeField] Transform otherPortal;
    [SerializeField] Transform player;

    //Either loads another scene or transport
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.position = otherPortal.position;
            
        }
    }
}
