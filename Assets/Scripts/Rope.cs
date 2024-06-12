using UnityEngine;

public class Rope : BaseRope
{
    bool b_scorePoint = false;
    void Start()
    {
        v2_direction = Vector2.down;
        b_modeCheck = true;
    }
    void FixedUpdate()
    {
        if (b_scorePoint)
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
            b_scorePoint = false;
        }
        print(!PlayerManager.Instance.GetPlayerRef().GetGotCaught());
            if (!PlayerManager.Instance.GetPlayerRef().GetGotCaught())
            {
                switch (RopeManager.instance.GetMode())
                {
                    case "Easy":
                        {
                            f_ropeSpeed = f_easy;
                            break;
                        }
                        case "Medium":
                        {
                            float f_minSpeed = f_easy;
                            float f_maxSpeed = Random.Range(f_minSpeed, f_medium);
                            f_ropeSpeed = f_maxSpeed * Time.deltaTime;
                            break;
                        }
                    default:
                        break;
                } 
            }
            else
                f_ropeSpeed = 0f;

            if (GameManager.instance.pregamecountDown <= 0f)
            {
                if (v2_direction == Vector2.up)
                {
                    if (Vector2.Distance(this.gameObject.transform.position, RopeManager.instance.GetMaxJumpRopeHeight()) <= 0f)
                    {
                        v2_direction *= -1;
                    }
                    else
                    {
                        b_ropeislowEnough = false;
                        this.gameObject.transform.position = Vector2.MoveTowards(this.gameObject.transform.position, RopeManager.instance.GetMaxJumpRopeHeight(), f_ropeSpeed);
                    }
                }
                else
                {
                    if (Vector2.Distance(this.gameObject.transform.position, RopeManager.instance.GetMinJumpRopeHeight()) <= 0f)
                    {
                        b_ropeislowEnough = true;
                        v2_direction = Vector2.up;
                        b_scorePoint = true;
                    }
                    else
                    {
                        float step = f_ropeSpeed * Time.deltaTime;
                        this.gameObject.transform.position = Vector2.MoveTowards(this.gameObject.transform.position, RopeManager.instance.GetMinJumpRopeHeight(), step);
                    }
                }
                    
            }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // checking to see if the player got caught by the rope
        if (RopeManager.instance.GetIsRopeLowEnough())
        {
            PlayerManager.Instance.GetPlayerRef().SetGotCaught(true);
        }
    }

}
