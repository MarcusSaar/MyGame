using UnityEngine;

public class DoorController : Interactable
{
    public Animator doorAnimator;

    private bool isOpen = false;

    public override void Interact()
    {
        base.Interact();

        Debug.Log("Interaction");
        if (isOpen)
        {
            CloseDoor();
        }
        else
        {
            OpenDoor();
        }

    }

    void OpenDoor()
    {
        if (doorAnimator != null)
        {
            doorAnimator.SetTrigger("Open"); // Assuming the animation trigger is named "Open"
            isOpen = true;
        }
    }

    void CloseDoor()
    {
        if (doorAnimator != null)
        {
            doorAnimator.SetTrigger("Close"); // Assuming the animation trigger is named "Close"
            isOpen = false;
        }
    }
}