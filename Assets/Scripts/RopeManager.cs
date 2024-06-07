using UnityEngine;

public class RopeManager : BaseRope
{
    public static RopeManager instance;

    GameObject rope, ropeInst;
    [SerializeField]
    Transform ropestartingPosition;

    Vector2 direction;

    Transform minHeight, maxHeight;

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

        // initial direction for the rope
        direction = Vector2.down;

        ropeislowEnough = false;
        scorePoint = false;
    }

    // Update is called once per frame
    void Update()
    {
        // stopping the rope when the player gets caught
        if (PlayerManager.Instance.GetPlayerRef().GetGotCaught()) ropeSpeed = 0f;

        if (scorePoint)
        {
            PlayerManager.Instance.SetNumofJumps(PlayerManager.Instance.GetNumofJumps() + 1);
            switch (PlayerManager.Instance.GetNumofJumps())
            {
                case 5: ++SaveData.current.profile.numBronze; break;
                case 15: ++SaveData.current.profile.numSilver; break;
                case 50: ++SaveData.current.profile.numGold; break;
                case 75: ++SaveData.current.profile.numPlat; break;
                case 1000: ++SaveData.current.profile.numWhy; break;
                case 42069: ++SaveData.current.profile.numGetLit; break;
                default: break;
            }
            scorePoint = false;
        }
        
        // the rope is no longer "low enough" for the player to get
        // tripped up on it
        //if (ropeInst.transform.position.y > minHeight.position.y)
        //    ropeislowEnough = false;

        // checking to see if the rope needs to go up or down
        //if (ropeInst.transform.position.y >= maxHeight.position.y)
        //{
        //    // changing ropes direction
        //    direction = Vector3.down;
        //}

        //if (ropeInst.transform.position.y <= minHeight.position.y)
        //{
        //    direction = Vector3.up;
        //    scorePoint = true;
        //    ropeislowEnough = true;
        //}
        //
    }
    private void FixedUpdate()
    {
        //moving the rope
        //if (GameManager.instance.pregamecountDown <= 0f)
        //    ropeInst.transform.Translate(direction * ropeSpeed * Time.deltaTime);

        if (GameManager.instance.pregamecountDown <= 0f)
        {
            
            if (direction == Vector2.up)
            {
                if (Vector2.Distance(ropeInst.transform.position, maxHeight.position) <= 0f)
                {
                    direction *= -1;
                }
                else
                {
                    ropeislowEnough = false;
                    float step = ropeSpeed * Time.deltaTime;
                    ropeInst.transform.position = Vector2.MoveTowards(ropeInst.transform.position, maxHeight.position, step);
                }
            }
            else
            {
                if (Vector2.Distance(ropeInst.transform.position, minHeight.position) <= 0f)
                {
                    ropeislowEnough = true;
                    direction = Vector2.up;
                    scorePoint = true;
                }
                else
                {
                    float step = ropeSpeed * Time.deltaTime;
                    ropeInst.transform.position = Vector2.MoveTowards(ropeInst.transform.position, minHeight.position, step);
                }
            }
            
        }
    }

    public void SetRopeSpeed(float speed) { ropeSpeed = speed; }

    public bool GetIsRopeLowEnough() { return ropeislowEnough; }
    public void ResetRope()
    {
        ropeInst.transform.position = ropestartingPosition.position;
        direction = Vector3.down;
    }
}
