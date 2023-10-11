using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FastRope : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(BeginFastRope);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BeginFastRope()
    {
        //RopeManager.instance.SetRopeSpeed(10f);
        //transform.parent.gameObject.SetActive(false);
        //UIManager.Instance.GetBackToMainMenuBtn().SetActive(false);
        //UIManager.Instance.GetToggleAccoladesBtn().SetActive(false);
        //GameManager.instance.SetGameHasStarted(true);
        //UIManager.Instance.GetCountdownTimer().SetActive(true);
        //UIManager.Instance.GetYourChoiceBtn().SetActive(false);
    }
}
