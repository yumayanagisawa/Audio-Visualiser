using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitBtn : MonoBehaviour
{
    public GameObject Vfx;
    public GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init()
    {
        GetComponent<Transform>().localScale = new Vector3(0, 0, 0);
        // play music
        Camera.GetComponent<AudioSource>().Play();
        // activate vfx
        Vfx.SetActive(true);
    }
}
