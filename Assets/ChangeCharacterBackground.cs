using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacterBackground : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Sprite background;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        background = Resources.Load<Sprite>("backgrounds/day");
        spriteRenderer.sprite = background;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
