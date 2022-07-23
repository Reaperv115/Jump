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
    Color[] distractionColors = { Color.red, Color.green, Color.black, Color.blue, 
                                Color.yellow, Color.cyan, Color.magenta };

    GameObject spiderDistraction, instantiatedspiderDistraction;

    private void Start()
    {
        spiderDistraction = Resources.Load<GameObject>("spider");
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
        Debug.Log("activated");
        float spawnY = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        float spawnX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
        instantiatedspiderDistraction = Instantiate(spiderDistraction, new Vector2(spawnX, spawnY), spiderDistraction.transform.rotation);
        //distractionSpot = Random.Range(0, distractionSpots.Count);


        //int bigandMean = Random.Range(1, 4);
        //if ((bigandMean % 2).Equals(0))
        //{
        //    distractionSpots[distractionSpot].GetComponent<TextMeshProUGUI>().text = "IS THIS DISTRACTING?!?!";

        //    int distractionColor = Random.Range(0, distractionColors.Length);
        //    distractionSpots[distractionSpot].GetComponent<TextMeshProUGUI>().color = distractionColors[distractionColor];

        //    int distractionSize = Random.Range(0, distractionSizes.Length);
        //    distractionSpots[distractionSpot].GetComponent<TextMeshProUGUI>().fontSize = distractionSizes[distractionSize];
        //}
        //else
        //{
        //    distractionSpots[distractionSpot].GetComponent<TextMeshProUGUI>().text = "THIS IS A DISTRACTION!!!";

        //    int distractionColor = Random.Range(0, distractionColors.Length);
        //    distractionSpots[distractionSpot].GetComponent<TextMeshProUGUI>().color = distractionColors[distractionColor];

        //    int distractionSize = Random.Range(0, distractionSizes.Length);
        //    distractionSpots[distractionSpot].GetComponent<TextMeshProUGUI>().fontSize = distractionSizes[distractionSize];
        //}
    }
    void Deactivate()
    {
        Destroy(instantiatedspiderDistraction);
        //distractionSpots[distractionSpot].GetComponent<TextMeshProUGUI>().text = "";
    }
}
