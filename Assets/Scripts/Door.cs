using System;
using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject LeftDoor;
    public GameObject RightDoor;
    public float OpenDistance;
    public float OpenSpeed;
    public AudioSource OpenSound;


    private void Start()
    {
        Open();
    }

    public void Open()
    {
        OpenSound.Play();
        StartCoroutine(OpenAsync());
    }

    public IEnumerator OpenAsync()
    {
        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / OpenSpeed;
            var d = t * OpenDistance;
            LeftDoor.transform.localPosition = new Vector3(-d, 0, 0);
            RightDoor.transform.localPosition = new Vector3(d, 0, 0);
            yield return new WaitForEndOfFrame();
        }
    }
}
