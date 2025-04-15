using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Grabber : MonoBehaviour
{
    [SerializeField] private float grabRange = 3f;
    [SerializeField] private LayerMask grabbableLayer;
    [SerializeField] private Transform grabHoldPoint;

    private GameObject heldObject;
    private Rigidbody heldRb;

    [SerializeField] private PlayerInput playerInput;
    private InputAction grabAction;

    private void Awake()
    {
        // playerInput = GetComponent<PlayerInput>();
        grabAction = playerInput.actions["Grab"];
        grabAction.performed += ctx => HandleGrab();
    }

    private void Update(){

        Debug.DrawRay(transform.position, transform.forward, Color.red);
        if(heldRb != null){
            heldRb.transform.position = grabHoldPoint.transform.position;
        }
    }

    private void HandleGrab()
    {
        if (heldObject == null)
        {
            TryGrabObject();
        }
        else
        {
            ReleaseObject();
        }
    }

    private void TryGrabObject()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, grabRange, grabbableLayer))
        {
            GameObject obj = hit.collider.gameObject;
            heldRb = obj.GetComponent<Rigidbody>();
            if (heldRb != null)
            {
                heldObject = obj;
                heldRb.useGravity = false;
                heldRb.transform.position = grabHoldPoint.position;
                heldRb.linearVelocity = Vector3.zero;
                heldRb.angularVelocity = Vector3.zero;
                heldRb.GetComponent<BoxCollider>().enabled = false;
                // heldRb.transform.SetParent(grabHoldPoint);
            }
        }
    }

    private void ReleaseObject()
    {
        if (heldRb != null)
        {
            heldRb.useGravity = true;
            heldRb.GetComponent<BoxCollider>().enabled = true;
            // heldRb.transform.SetParent(null);
            heldObject = null;
            heldRb = null;
        }
    }

    private void OnDisable()
    {
        grabAction.performed -= ctx => HandleGrab();
    }
}
