using UnityEngine;

public class BaseRope : MonoBehaviour
{
    protected Vector2 v2_direction;

    protected int i_numOfJumps = 0;
    protected bool b_goUp, b_goDown, b_ropeislowEnough, b_modeCheck;
    protected float f_ropeSpeed, f_easy = 3f, f_medium = 10f, f_hard = 15f, f_impossible = 35f;
    

    public float GetEasySpeed()
    {
        return f_easy;
    }
    public float GetMediumSpeed()
    {
        return f_medium;
    }
    public float GetHardSpeed()
    {
        return f_hard;
    }
    public float GetImpossibleSpeed()
    {
        return f_impossible;
    }
    public void SetSpeed(float pf_speed)
    {
        f_ropeSpeed = pf_speed;
    }
}
