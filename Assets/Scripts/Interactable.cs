using UnityEngine;

public class Interactable : MonoBehaviour
{
    private bool focused = false;

    public Triggerable Target;

    public virtual void Interact()
    {
        if (Target != null) Target.Trigger();
    }

    // Update is called once per frame
    void Update()
    {
        if (focused && Input.GetMouseButtonDown(0)) Interact();
    }

    private void OnTriggerEnter(Collider other)
    {
        focused = true;
    }

    private void OnTriggerExit(Collider other)
    {
        focused = false;
    }
}
