using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    private int randomNum;
    public int maxRandOn;
    public int minRandOn;
    public int maxRandOff;
    public int minRandOff;

    private Light myLight;

    private void Start()
    {
        myLight = GetComponent<Light>();
        randomNum = Random.Range(minRandOn, maxRandOn);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        randomNum--;
        if(randomNum < 0)
        {
            myLight.enabled = !myLight.enabled;
            randomNum = myLight.enabled ?  Random.Range(minRandOn, maxRandOn) : Random.Range(minRandOff, maxRandOff);
        }
    }
}
