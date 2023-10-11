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
        RopeManager.instance.SetRopeSpeed(2f);
        transform.parent.gameObject.SetActive(false);
        GameManager.instance.SetGameHasStarted(true);
        UIManager.Instance.GetCountdownTimer().SetActive(true);
        UIManager.Instance.GameHasStarted();
    }
}
