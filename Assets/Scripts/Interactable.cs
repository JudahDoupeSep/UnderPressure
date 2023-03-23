using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private bool focused = false;

    public List<Triggerable> Targets;

    public virtual void Interact()
    {
        if (Targets != null && Targets.Count > 0) Targets.ForEach(t => { if (t != null) t.Trigger();  });
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
