using UnityEngine;

public class WinManager : MonoBehaviour
{
    public Canvas canvas;
    public PlayerMovement player;
    public PlayerCam playerCam;
    private void Start()
    {
        canvas.enabled = false;
    }
    public void Win()
    {
        player.enabled = false;
        playerCam.canTurn = false;
        canvas.enabled = true;
    }
}
