using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayDistractions : MonoBehaviour
{

    [SerializeField]
    List<GameObject> distractionSpots;

    float distractionDelay = 5.0f;
    float showTimer = 0.0f;

    int distractionSpot;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (distractionDelay <= 0.0f && showTimer <= 0.0f)
        {
            showTimer = 7.0f;
            distractionSpot = Random.Range(0, distractionSpots.Count);
            Debug.Log(distractionSpots.Count);
        }
        else
        {
            
            distractionDelay -= Time.deltaTime;
        }

        if (showTimer <= 0.0f && distractionDelay <= 0.0f)
        {
            distractionSpots[distractionSpot].GetComponent<TextMeshProUGUI>().text = "";
            distractionDelay = 5.0f;
        }
        else
        {
            distractionSpots[distractionSpot].GetComponent<TextMeshProUGUI>().text = "distraction!";
            showTimer -= Time.deltaTime;
        }
    }
}
