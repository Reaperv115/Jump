using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    GameObject exitButton, exitbuttonInst;
    GameObject startButton, startbuttonInst;
    GameObject characterSelection, characterselectionInst;

    private void Awake()
    {
        exitButton = Resources.Load<GameObject>("UI/Main Menu UI/Exit");
        exitbuttonInst = Instantiate(exitButton, GameObject.Find("Exit Button Position").transform.position, exitButton.transform.rotation);
        exitbuttonInst.transform.SetParent(GameObject.Find("Canvas").transform);

        startButton = Resources.Load<GameObject>("UI/Main Menu UI/Start");
        startbuttonInst = Instantiate(startButton, GameObject.Find("Start Button Position").transform.position, startButton.transform.rotation);
        startbuttonInst.transform.SetParent(GameObject.Find("Canvas").transform);

        characterSelection = Resources.Load<GameObject>("UI/Main Menu UI/character selection");
        characterselectionInst = Instantiate(characterSelection, GameObject.Find("Character Selection Position").transform.position, characterSelection.transform.rotation);
        characterselectionInst.transform.SetParent(GameObject.Find("Canvas").transform);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
