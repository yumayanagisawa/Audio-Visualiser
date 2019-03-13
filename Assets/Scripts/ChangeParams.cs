using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeParams : MonoBehaviour
{
    public GameObject Light;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeLightIntensity()
    {
        Light.GetComponent<Light>().intensity = GetComponent<Slider>().value;
    }
}
