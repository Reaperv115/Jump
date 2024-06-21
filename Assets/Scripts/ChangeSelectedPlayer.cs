using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeSelectedPlayer : MonoBehaviour
{
    TMP_Dropdown playerSelection;
    // Start is called before the first frame update
    void Start()
    {
        playerSelection = GetComponent<TMP_Dropdown>();
        playerSelection.onValueChanged.AddListener(delegate
        {
            OnPlayerChanged(playerSelection);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayerChanged(TMP_Dropdown dropDown)
    {
        PlayerManager.Instance.selectedPlayer = dropDown.value;
    }
}
