using TMPro;
using UnityEngine;

public class NumberofJumps : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = "Jumps: " + PlayerManager.Instance.GetPlayerRef().GetNumJumpsthisTurn();
    }
}
