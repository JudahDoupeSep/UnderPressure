using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Interactable
{
    public GameObject LeverBone;
    public float PullTime = 1f;
    public float TargetRotation = 150;
    
    private bool _isPulled = false;
    
    public override void Interact()
    {
        if (!_isPulled)
        {
            _isPulled = true;
            StartCoroutine(Pull());
        }
    }

    public IEnumerator Pull()
    {
        GetComponent<AudioSource>().Play();
        
        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / PullTime;
            var x = t * TargetRotation;
            LeverBone.transform.localRotation = Quaternion.Euler(new Vector3(x, 0, 0));
            yield return new WaitForEndOfFrame();
        }

        base.Interact();
    }
}
