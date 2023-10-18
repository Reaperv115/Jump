using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowRope : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(BeginSlowRope);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BeginSlowRope()
    {
        GameManager.instance.pregamecountDown = 3f;
        var canv = GameObject.Find("Canvas");
        for (int i = 0; i < canv.transform.GetChild(1).childCount; i++)
        {
            canv.transform.GetChild(1).GetChild(i).gameObject.SetActive(false);
        }
        RopeManager.instance.SetRopeSpeed(5f);
        GameManager.instance.gamehasStarted = true;
    }
}
