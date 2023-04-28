using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReplayGame : MonoBehaviour
{
    

    [SerializeField]
    GameObject backGround;

    // Start is called before the first frame update
    void Start()
    {
        print(GetComponent<Button>());
        GetComponent<Button>().onClick.AddListener(ReloadGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReloadGame()
    {
        SerializationManager.Save("Data", SaveData.current);
        UIManager.Instance.GetBasicModeBtn().SetActive(true);
        UIManager.Instance.GetYourChoiceBtn().SetActive(true);
        PlayerManager.Instance.SetNumofJumps(0);
        gameObject.SetActive(false);
    }
}
