using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class RopeManager : MonoBehaviour
{
    public static RopeManager instance;

    GameObject rope, ropeInst;
    [SerializeField]
    Transform ropestartingPosition;

    GameObject ropeSlider;

    Vector2 direction;

    Transform minHeight, maxHeight;

    string s_mode;

    // bool for checking
    // if the player should
    // be able to get caught
    // by rope
    bool ropeislowEnough;

    // should a point be added
    // to player's score
    bool scorePoint;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        else
            Debug.LogError("trying to create multiple instances of rope manager");

        // loading and instantiating rope gameobject
        rope = Resources.Load<GameObject>("rope");
        ropeInst = Instantiate(rope, ropestartingPosition.position, rope.transform.rotation);

        // finding the min and max height for the rope
        minHeight = GameObject.Find("min height").GetComponent<Transform>();
        maxHeight = GameObject.Find("max height").GetComponent<Transform>();

        ropeislowEnough = false;
        scorePoint = false;

        ropeSlider = GameObject.Find("RopeSpeedSlider");
    }


    

    public bool GetIsRopeLowEnough() { return ropeislowEnough; }
    public void ResetRope()
    {
        ropeInst.transform.position = ropestartingPosition.position;
    }

    public Vector2 GetMaxJumpRopeHeight()
    {
        return maxHeight.position;
    }
    public Vector2 GetMinJumpRopeHeight()
    {
        return minHeight.position;
    }

    public void SetMode(string mode)
    {
        s_mode = mode;
    }
    public string GetMode()
    {
        return s_mode;
    }
}
