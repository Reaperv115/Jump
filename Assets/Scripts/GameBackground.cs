using UnityEngine;
using UnityEngine.UI;

public class GameBackground : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Sprite[] background;
    //RegularRope rope;

    



    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        background = Resources.LoadAll<Sprite>("backgrounds");

        

        spriteRenderer.sprite = background[0];
    }

    // Update is called once per frame
    void Update()
    {

        //if (rope.getcurrJumps() == 15)
        //    spriteRenderer.sprite = background[1];
        //if (rope.getcurrJumps() == 30)
        //    spriteRenderer.sprite = background[2];
    }

    //public void Replay()
    //{
    //    SerializationManager.Save("Data", SaveData.current);
    //    resetGame();
    //    if (buttons.getrequestedDifficulty().Equals("edd"))
    //        ddmileStone = Random.Range(1, 5);
    //    Debug.Log(ddmileStone);

    //}

    public void resetBackground() => spriteRenderer.sprite = background[0];
}