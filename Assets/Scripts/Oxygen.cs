using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Oxygen : MonoBehaviour
{
    // Start is called before the first frame update

    public int oxygen = 10000;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        oxygen -= 1;
        Debug.Log(oxygen/50);

        if(oxygen <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
