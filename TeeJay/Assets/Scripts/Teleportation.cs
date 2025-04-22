//Helps in travelling from one portal to another
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    [SerializeField] Transform otherPortal;
    [SerializeField] Transform player;

    private void OnCollisionEnter(Collision other)
    {
        

        if (other.gameObject.CompareTag("Player"))
        {
            player.position = otherPortal.position;
        }
    }
}
