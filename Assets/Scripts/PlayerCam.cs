using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{

    public float sensX;
    public float sensY;

    public Transform player;

    float xRot;
    float yRot;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        xRot = player.rotation.eulerAngles.x;
        yRot = player.rotation.eulerAngles.y;
        enabled = false;
        StartCoroutine(DelayedWakeup());
    }

    IEnumerator DelayedWakeup()
    {
        yield return new WaitForSecondsRealtime(.5f);
        enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRot += mouseX;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -45f, 45f);

        player.rotation = Quaternion.Euler(0, yRot, 0);
        transform.rotation = Quaternion.Euler(xRot, yRot, 0);
    }
}
