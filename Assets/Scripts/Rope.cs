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
            PlayerManager.Instance.GetPlayerRef().SetNumJumpsThisTurn(PlayerManager.Instance.GetPlayerRef().GetNumJumpsthisTurn() + 1);
            switch (PlayerManager.Instance.GetPlayerRef().GetNumJumpsthisTurn())
            {
                case 5:     ++SaveData.current.profile.numBronze;    break;
                case 15:    ++SaveData.current.profile.numSilver;    break;
                case 50:    ++SaveData.current.profile.numGold;      break;
                case 75:    ++SaveData.current.profile.numPlat;      break;
                case 1000:  ++SaveData.current.profile.numWhy;       break;
                case 42069: ++SaveData.current.profile.numGetLit;    break;
                default:                                             break;
            }
            b_scorePoint = false;
        }
        switch (RopeManager.instance.GetMode())
        {
            case "Easy":
            {
                f_ropeSpeed = f_easy * Time.deltaTime;
                break;
            }
            case "Medium":
            {
                float f_minSpeed = f_easy;
                float f_maxSpeed = Random.Range(f_minSpeed, f_medium);
                f_ropeSpeed = f_maxSpeed * Time.deltaTime;
                break;
            }
            case "Hard":
            {
                float minspeed = Random.Range(f_easy, f_medium);
                float maxspeed = Random.Range(minspeed, f_hard);
                f_ropeSpeed = maxspeed * Time.deltaTime;
                break;
            }
            case "Impossible":
            {
                float minspeed = Random.Range(f_easy, f_hard);
                float maxspeed = Random.Range(minspeed, f_hard);
                f_ropeSpeed = maxspeed * Time.deltaTime;
                break;
            }
            case "Defeat":
            {
                f_ropeSpeed = 0f;
                break;
            }
            default:
                break;
        } 

        if (GameManager.instance.pregamecountDown <= 0f)
        {
            if (v2_direction == Vector2.up)
            {
                if (Vector2.Distance(this.gameObject.transform.position, RopeManager.instance.GetMaxJumpRopeHeight()) <= 0f)
                {
                    v2_direction = Vector2.down;
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
                    this.gameObject.transform.position = Vector2.MoveTowards(this.gameObject.transform.position, RopeManager.instance.GetMinJumpRopeHeight(), f_ropeSpeed);
                }
            }
                
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (b_ropeislowEnough)
        {
            PlayerManager.Instance.GetPlayerRef().SetGotCaught(true);
            GameManager.instance.EndRound();
        }
        
    }

}
