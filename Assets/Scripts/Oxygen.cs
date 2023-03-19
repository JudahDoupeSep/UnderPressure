using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Oxygen : MonoBehaviour
{
    public DeathManager deathManager;
    public VolumeProfile Profile;
    public float MaxOxygen = 60;
    public AnimationCurve VignetteCurve;
    public AudioSource HeartBeat;
    public AnimationCurve HeartRate;
    public AnimationCurve HeartVolume;
    public AudioSource Breath;
    public AnimationCurve BreathVolume;
    public float DeathTime = 2;

    private float _oxygen;
    private float death => 1 - _oxygen / MaxOxygen;

    private void Start()
    {
        StartCoroutine(Respawn());
    }

    private void Update()
    {
        _oxygen -= Time.deltaTime;
        if (_oxygen <= 0)
        {
            StartCoroutine(Die());
            enabled = false;
        }

        UpdateEffects();
    }

    public void UpdateEffects()
    {
        if (Profile.TryGet<Vignette>(out var vignette)) 
            vignette.intensity.value = VignetteCurve.Evaluate(death);
        
        HeartBeat.pitch = HeartRate.Evaluate(death);
        HeartBeat.volume = HeartVolume.Evaluate(death);
        Breath.volume = BreathVolume.Evaluate(death);
    }

    public IEnumerator Respawn()
    {
        _oxygen = MaxOxygen;
        
        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime;

            if (Profile.TryGet<Exposure>(out var exposure))
                exposure.compensation.value = (1 - t) * -5f;

            yield return new WaitForEndOfFrame();
        }
        
        
        //TODO: start stuff
    }

    public IEnumerator Die()
    {
        var movement = FindObjectOfType<PlayerMovement>();
        var oldSpeed = movement.moveSpeed;
        
        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / DeathTime;
            movement.moveSpeed = (1 - t) * oldSpeed;

            if (Profile.TryGet<Exposure>(out var exposure))
                exposure.compensation.value = t * -5f;

            yield return new WaitForEndOfFrame();
        }


        //TODO: death stuff
        StartCoroutine(deathManager.Die());
    }
}