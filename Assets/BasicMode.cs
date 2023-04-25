using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicMode : MonoBehaviour
{
    [SerializeField]
    Button yourchoiceModeBtn;
    [SerializeField]
    GameObject basicmodeOptions;
    Button basicModeBtn;
    // Start is called before the first frame update
    void Awake()
    {
        //GetComponent<Button>().onClick.AddListener(NormalMode);
    }
    public void NormalMode()
    {
        print("normal mode");
        gameObject.SetActive(false);
        UIManager.Instance.GetBasicModeOptions().SetActive(true);
        UIManager.Instance.GetYourChoiceBtn().SetActive(false);
    }
}
