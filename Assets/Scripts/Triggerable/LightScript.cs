using UnityEngine;

public class LightScript : Triggerable
{
    private Light myLight;
    public override void Trigger()
    {
        myLight.enabled = !myLight.enabled;
    }
    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<Light>();
        myLight.enabled = false;
    }
}
