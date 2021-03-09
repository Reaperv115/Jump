using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleAccolades : MonoBehaviour
{
    GameObject[] accolades;
    bool displayAccolades;

    // Start is called before the first frame update
    void Start()
    {
        accolades = GameObject.FindGameObjectsWithTag("accolade");
        displayAccolades = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (displayAccolades)
        {
            for (int i = 0; i < accolades.Length; ++i)
            {
                accolades[i].gameObject.SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < accolades.Length; ++i)
            {
                accolades[i].gameObject.SetActive(false);
            }
        }

    }

    public void toggleAccolades()
    {
        displayAccolades = !displayAccolades;
    }
}
