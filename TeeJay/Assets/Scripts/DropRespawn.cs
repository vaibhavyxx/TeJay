//Made for intro scene only, to jump back to the last spawn after it falls onto the ground

using UnityEngine;

public class DropRespawn : MonoBehaviour
{
    public Transform respawnTransform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Drop"))
        {
            this.transform.position = respawnTransform.position;
        }
    }
}
