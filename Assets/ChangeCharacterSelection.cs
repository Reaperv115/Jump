using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ChangeCharacterSelection : MonoBehaviour
{
    Sprite[] selectableCharacters;
    TMP_Dropdown characterselection;

    Sprite ryanSprite, wolfSprite;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        selectableCharacters = Resources.LoadAll<Sprite>("Players");
        Debug.Log(selectableCharacters[0]);
        Debug.Log(selectableCharacters[1]);

        characterselection = GetComponent<TMP_Dropdown>();
        spriteRenderer = GameObject.Find("player").GetComponent<SpriteRenderer>();

        ryanSprite = Resources.Load<Sprite>("Players/ryan");
        wolfSprite = Resources.Load<Sprite>("Players/wolf");
    }

    // Update is called once per frame
    void Update()
    {   
        Debug.Log(characterselection);
        Debug.Log(ryanSprite);
        Debug.Log(wolfSprite);
        if (characterselection.value.Equals(0))
        {
            spriteRenderer.sprite = ryanSprite;
        }
        else
        {
            spriteRenderer.sprite = wolfSprite;
        }
    }
}
