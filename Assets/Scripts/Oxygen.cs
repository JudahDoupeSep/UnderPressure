using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.SceneManagement;

public class Oxygen : MonoBehaviour
{
    public VolumeProfile Profile;
    public float MaxOxygen = 60;
    public AnimationCurve VignetteCurve;

    private float _oxygen = 0;
    private float death => 1 - (_oxygen / MaxOxygen);
    
    void Start()
    {
        StartCoroutine(Respawn());
    }

    void Update()
    {
        _oxygen -= Time.deltaTime;
        if(_oxygen <= 0)
        {
            StartCoroutine(Die());
        }

        UpdateEffects();
    }

    public void UpdateEffects()
    {
        if (Profile.TryGet<Vignette>(out var vignette))
        {
            vignette.intensity.value = VignetteCurve.Evaluate(death);
        }
    }

    public IEnumerator Respawn()
    {
        _oxygen = MaxOxygen;
        yield return new WaitForSeconds(1);
    }
    
    public IEnumerator Die()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        yield return Respawn();
    }
}
