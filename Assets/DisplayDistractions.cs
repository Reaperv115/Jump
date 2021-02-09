using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayDistractions : MonoBehaviour
{

    [SerializeField]
    List<GameObject> distractionSpots;
    float distractionTimer = 6.0f;

    int distractionSpot;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < distractionSpots.Count; ++i)
            distractionSpots[i].gameObject.SetActive(false);
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
        distractionSpots[distractionSpot].gameObject.SetActive(true);
        distractionSpots[distractionSpot].GetComponent<TextMeshProUGUI>().color = Color.blue;
    }
    void Deactivate()
    {
        distractionSpots[distractionSpot].gameObject.SetActive(false);
    }
}
