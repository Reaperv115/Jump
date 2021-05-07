using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayDistractions : MonoBehaviour
{

    [SerializeField]
    List<GameObject> distractionSpots;
    float distractionTimer = 6.0f;

    int distractionSpot;

    int[] distractionSizes = { 25, 35, 25 };
    Color[] distractionColors = { Color.red, Color.green, Color.black, Color.blue, Color.yellow, Color.cyan, Color.magenta };

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (distractionTimer <= 0.0f)
        {
            Invoke("Activate", 5.0f);
            Invoke("Deactivate", 10.0f);
            distractionTimer = 6.0f;
        }
        else
            distractionTimer -= Time.deltaTime;
    }

    void Activate()
    {
        distractionSpot = Random.Range(0, distractionSpots.Count);
        

        int bigandMean = Random.Range(1, 4);
        if ((bigandMean % 2).Equals(0))
        {
            distractionSpots[distractionSpot].GetComponent<TextMeshProUGUI>().text = "IS THIS DISTRACTING?!?!";

            int distractionColor = Random.Range(0, distractionColors.Length);
            distractionSpots[distractionSpot].GetComponent<TextMeshProUGUI>().color = distractionColors[distractionColor];

            int distractionSize = Random.Range(0, distractionSizes.Length);
            distractionSpots[distractionSpot].GetComponent<TextMeshProUGUI>().fontSize = distractionSizes[distractionSize];
        }
        else
        {
            distractionSpots[distractionSpot].GetComponent<TextMeshProUGUI>().text = "THIS IS A DISTRACTION!!!";

            int distractionColor = Random.Range(0, distractionColors.Length);
            distractionSpots[distractionSpot].GetComponent<TextMeshProUGUI>().color = distractionColors[distractionColor];

            int distractionSize = Random.Range(0, distractionSizes.Length);
            distractionSpots[distractionSpot].GetComponent<TextMeshProUGUI>().fontSize = distractionSizes[distractionSize];
        }
    }
    void Deactivate()
    {
        distractionSpots[distractionSpot].GetComponent<TextMeshProUGUI>().text = "";
    }
}
