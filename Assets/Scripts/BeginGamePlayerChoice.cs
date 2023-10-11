using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeginGamePlayerChoice : MonoBehaviour
{
    GameObject sliderParent;
    // Start is called before the first frame update
    void Start()
    {
        sliderParent = transform.parent.gameObject;
        GetComponent<Button>().onClick.AddListener(BeginGameWithCustomChoice);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BeginGameWithCustomChoice()
    {
        //RopeManager.instance.SetRopeSpeed(sliderParent.GetComponent<Slider>().value);
        //transform.parent.gameObject.SetActive(false);
        //UIManager.Instance.GetBackToMainMenuBtn().SetActive(false);
        //UIManager.Instance.GetToggleAccoladesBtn().SetActive(false);
        //GameManager.instance.SetGameHasStarted(true);
        //UIManager.Instance.GetCountdownTimer().SetActive(true);
        //UIManager.Instance.GetBasicModeBtn().SetActive(false);
    }
}
