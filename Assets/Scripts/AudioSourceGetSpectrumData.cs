using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;

[RequireComponent(typeof(AudioSource))]
public class AudioSourceGetSpectrumData : MonoBehaviour
{
    VisualEffectAsset visualEffectAsset;
    private VisualEffect dataViz;
    private Material mat;
    public GameObject obj;
    // Start is called before the first frame update
    void Awake()
    {
        dataViz = obj.GetComponent<VisualEffect>();
        dataViz.SetFloat("SpawnNum", 5000f);// motorVal+5000f);
        dataViz.SetFloat("Particle Scale", 0.9f);// motorVal/5000f);
    }

    // Update is called once per frame
    void Update()
    {
        
        float[] spectrum = new float[256];

        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

        for (int i = 1; i < spectrum.Length - 1; i++)
        {
            Debug.DrawLine(new Vector3(i - 1, spectrum[i] + 10, 0), new Vector3(i, spectrum[i + 1] + 10, 0), Color.red);
            Debug.DrawLine(new Vector3(i - 1, Mathf.Log(spectrum[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(spectrum[i]) + 10, 2), Color.cyan);
            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), spectrum[i - 1] - 10, 1), new Vector3(Mathf.Log(i), spectrum[i] - 10, 1), Color.green);
            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(spectrum[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(spectrum[i]), 3), Color.blue);
        }
        float motorVal = 0.0f;
        for (int i = 0; i < 10; i++)
        {
            motorVal += spectrum[i];
        }
        motorVal *= 20000.0f;
        
        //mat.SetFloat("_Motor", motorVal);
        dataViz.SetFloat("SpawnNum", motorVal+5000f);
        dataViz.SetFloat("Particle Scale", motorVal/5000f);
        //Debug.Log(motorVal);
        
    }
}
