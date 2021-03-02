using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeginPlay : MonoBehaviour
{
    Button play;

    // Start is called before the first frame update
    void Start()
    {
        play = GetComponent<Button>();
        play.onClick.AddListener(Play);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        GameObject.Find("rope").GetComponent<Rope>().goUp = true;
        gameObject.SetActive(false);
    }
}
