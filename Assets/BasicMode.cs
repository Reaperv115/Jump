using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicMode : MonoBehaviour
{
    [SerializeField]
    Button yourchoiceModeBtn;
    [SerializeField]
    GameObject basicmodeOptionsBtn;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(BsicMode);
    }
    void BsicMode()
    {
        gameObject.SetActive(false);
        yourchoiceModeBtn.gameObject.SetActive(false);
        basicmodeOptionsBtn.gameObject.SetActive(true);
    }
}
