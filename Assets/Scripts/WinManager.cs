using System.Collections;
using UnityEngine;

public class WinManager : MonoBehaviour
{
    public Canvas canvas;
    public PlayerMovement player;
    public PlayerCam playerCam;
    private void Start()
    {
        canvas.gameObject.SetActive(false);
    }
    public void Win()
    {
        player.enabled = false;
        playerCam.canTurn = false;
        canvas.gameObject.SetActive(true);
        StartCoroutine(Quit());
    }

    private IEnumerator Quit()
    {
        yield return new WaitForSeconds(3);
        Application.Quit();
    }
}
