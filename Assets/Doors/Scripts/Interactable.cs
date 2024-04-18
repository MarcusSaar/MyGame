using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float reachDistance = 1f;

    public Transform interactionTransform;

    public LayerMask objectMask;

    bool isPlayerNearby = false;

    public KeyCode interactKey = KeyCode.E;

    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    public virtual void Interact () 
    {

        // This is meant to be overwritten
    }
    private void Update()
    {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(ray.origin, ray.direction * reachDistance, Color.green);
        if (Input.GetKeyDown(interactKey))
        {
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, reachDistance, objectMask))
            {
                Debug.Log("Raycast Hit");
                Interact();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        float distance = Vector3.Distance(other.gameObject.transform.position, interactionTransform.position);

        if (other.gameObject.name == "FirstPersonController" && distance <= reachDistance)
        {
            isPlayerNearby = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        float distance = Vector3.Distance(other.gameObject.transform.position, interactionTransform.position);

        if (other.gameObject.name == "FirstPersonController" && distance <= reachDistance)
        {
            isPlayerNearby = false;
        }
    }
    void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
            interactionTransform = transform;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, reachDistance);
    }
}