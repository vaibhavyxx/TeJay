//Helps in travelling from one portal to another
using UnityEngine;
public class Teleportation : MonoBehaviour
{
    [SerializeField] GameObject otherPortal;
    [SerializeField] GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.transform.position = otherPortal.transform.position ;
            Debug.Log("Entered portal");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
