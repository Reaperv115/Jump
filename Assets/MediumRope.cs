using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MediumRope : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(BeginMediumRope);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BeginMediumRope()
    {
        RopeManager.instance.SetRopeSpeed(5f);
        transform.parent.gameObject.SetActive(false);
        UIManager.Instance.GetBackToMainMenuBtn().SetActive(false);
    }
}
