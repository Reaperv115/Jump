using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayDistractions : MonoBehaviour
{

    [SerializeField]
    List<GameObject> distractionSpots;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < distractionSpots.Count; ++i)
            distractionSpots[i].GetComponent<TextMeshProUGUI>().text = "distraction!";
    }

    // Update is called once per frame
    void Update()
    {
    }
}
