using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    #region Input

    private KeyCode runKey;
    private KeyCode btnA;
    private KeyCode btnB;
    private KeyCode btnY;
    private KeyCode btnX;
    private KeyCode btnL1;
    private KeyCode btnL2;
    private KeyCode btnR1;
    private KeyCode btnR2;
    private KeyCode btnPlus;
    private KeyCode btnMinus;
    private KeyCode btnLJoystick;
    private KeyCode btnRJoystick;

    public bool A;
    public bool B;
    public bool Y;
    public bool X;
    public bool L1;
    public bool R1;
    public bool L2;
    public bool R2;
    public bool Plus;
    public bool Minus;
    public bool LJoystick;
    public bool RJoystick;
    #endregion

    public void Start()
    {
    btnA = KeyCode.Joystick1Button2;
    btnB = KeyCode.Joystick1Button1;
    btnY = KeyCode.Joystick1Button0;
    btnX = KeyCode.Joystick3Button3;
    btnL1 = KeyCode.Joystick1Button4;
    btnL2 = KeyCode.Joystick1Button6;
    btnR1 = KeyCode.Joystick1Button5;
    btnR2 = KeyCode.Joystick1Button7;
    btnPlus = KeyCode.Joystick1Button9;
    btnMinus = KeyCode.Joystick1Button8;
    btnLJoystick = KeyCode.Joystick1Button10;
    btnRJoystick = KeyCode.Joystick1Button11;
    }



    public void checkInput()
    {
        A = Input.GetKey(btnA);
        B = Input.GetKey(btnB);
        Y = Input.GetKey(btnY);
        X = Input.GetKey(btnX);
        L1 = Input.GetKey(btnL1);
        R1 = Input.GetKey(btnR1);
        L2 = Input.GetKey(btnL2);
        R2 = Input.GetKey(btnR2);
        Plus = Input.GetKey(btnPlus);
        Minus = Input.GetKey(btnMinus);
        LJoystick = Input.GetKey(btnLJoystick);
        RJoystick = Input.GetKey(btnRJoystick);
    }

    #region Input

    public bool MoveKeyHeld()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetAxis("Horizontal") > .3 || Input.GetAxis("Horizontal") < -.3) return true;
        return false;
    }

    public bool RunKeyHeld()
    {
        if (Input.GetKey(KeyCode.X) || L2 /* L2 Button */) return true;
        return false;
    }

    public bool JumpKeyHeld()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Joystick1Button1) /* B button */) return true;
        return false;
    }

    public bool ClimbKeyHeld()
    {
        if (Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.Joystick1Button7) /*  R2 Button*/)
        {
            return true;
        }
        return false;
    }

    public bool LeftInput() {
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) || Input.GetAxis("Horizontal") < -.1)
        {
            return true;
        }
        return false;
    }

    public bool RightInput()
    {
        if (!Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) || Input.GetAxis("Horizontal") > .1)
        {
            return true;
        }
        return false;
    }

    public float KeyDirection(float currentDirection)
    {
        if (LeftInput())
        {
            return -1;
        }
        else if (RightInput())
        {
            return 1;
        }
        else return currentDirection;
    }

    /// <summary>
    /// Checks if either Movement key is being held and not the Run Key. if so Player is trying to apply the walk state.
    /// </summary>
    /// <returns>boolean</returns>
    public bool IsAttemptingWalk()
    {
        if (MoveKeyHeld() && !RunKeyHeld()) return true;
        return false;
    }

    /// <summary>
    /// Checks if Runkey and Move Key is being presses and Player is not in the Exhausted state
    /// </summary>
    /// <returns>boolean</returns>
    public bool IsAttemptingRun()
    {
        if (RunKeyHeld() && MoveKeyHeld()) return true;
        return false;
    }

    /// <summary>
    /// Checks if Jumpkey is held and that player is not is the Exhausted state. If true Player is trying to apply Jump State
    /// </summary>
    /// <returns>boolean</returns>
    public bool IsAttemptingJump()
    {
        if (JumpKeyHeld()) return true;
        return false;
    }

    /// <summary>
    /// Checks if the Climb key is being pressed, that we are OnWall() and not in the Exhausted State. If true player is trying to apply Climbing state.
    /// </summary>
    /// <returns>boolean</returns>
    public bool IsAttemptingClimb()
    {
        if (ClimbKeyHeld()) return true;
        return false;
    }

    #endregion
}
