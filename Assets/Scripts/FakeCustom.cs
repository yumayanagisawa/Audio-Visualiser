using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FakeCustom : MonoBehaviour
{
    private bool isOn = false;
    private bool isCanvasOn = false;
    public Sprite on;
    public Sprite off;
    public GameObject light;
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
            if (isCanvasOn)
            {
                isCanvasOn = false;
                GetComponent<Transform>().localScale = new Vector3(0, 0, 0);
            }
            else
            {
                isCanvasOn = true;
                GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
            }
        }
    }

    public void ChangeAppearance()
    {
        if (isOn)
        {
            isOn = false;
            GetComponent<Image>().sprite = off;
            light.SetActive(false);
        }
        else
        {
            isOn = true;
            GetComponent<Image>().sprite = on;
            light.SetActive(true);
        }
    }
}
