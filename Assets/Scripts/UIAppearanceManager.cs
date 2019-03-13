using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAppearanceManager : MonoBehaviour
{
    private bool isOn = false;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Transform>().localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            if (isOn)
            {
                isOn = false;
                GetComponent<Transform>().localScale = new Vector3(0, 0, 0);
            }
            else
            {
                isOn = true;
                GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
            }
        }
    }
}
