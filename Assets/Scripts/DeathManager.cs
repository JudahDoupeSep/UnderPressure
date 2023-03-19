using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    public Canvas canvas;
    public PlayerMovement player;
    public PlayerCam playerCam;
    public float TransitionTIme;

    private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        canvas.gameObject.SetActive(false);
        text = canvas.GetComponentInChildren<TextMeshProUGUI>();
        text.alpha = 0;
    }

    public IEnumerator Die()
    {
        canvas.gameObject.SetActive(true);
        player.enabled = false;
        playerCam.canTurn = false;
        while (text.alpha < 1)
        {
            text.alpha += Time.deltaTime / TransitionTIme;
            yield return null;
        }
        yield return new WaitForSecondsRealtime(2);
        while (text.alpha > 0)
        {
            text.alpha -= Time.deltaTime / TransitionTIme;
            yield return null;
        }
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}