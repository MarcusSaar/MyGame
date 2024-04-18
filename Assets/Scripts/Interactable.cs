using UnityEngine;

public class interactable : MonoBehaviour
{
   public float radius = 3f;
   
   public Transform interactionTransform;

   bool isFocus = false;
   Transform player;

   bool hasInteracted = false;

   public virtual void Interact()
   {
       Debug.Log("Interacting with" + transform.name);

   }

   void Update()
   {
        if(isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position,interactionTransform.position);
            //Debug.Log(distance + "; " + radius);
            if(distance <= radius)
            Debug.Log("Hello");
            {
               
                Interact();
                hasInteracted = true;
            }
        }
   }
   public void OnFocused(Transform playerTransform)
   {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
   }

   public void OnDefocused()
   {
        isFocus = false;
        player = null;
        hasInteracted = false;
   }
   void OnDrawGizmosSelected()
   {
        if(interactionTransform == null)
            interactionTransform = transform;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position,radius);
   }
}
