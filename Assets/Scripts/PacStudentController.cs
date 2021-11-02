using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    public float speed = 3.0f;
    public Vector2 initialDirection;
    private enum MovementDirections { Up, Down, Left, Right };
    private MovementDirections lastInput;
    private MovementDirections currentInput = MovementDirections.Right;
    private Vector2 movement;
    public Animator animatorController;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GetMovementInput();

    }

    void FixedUpdate()
    {
        Movement();
        WalkingAnimation();
    }

    void GetMovementInput()
    {
        if (Input.GetKeyDown("d"))
        {

            currentInput = MovementDirections.Right;
            Debug.Log("1111");
        }
        else if (Input.GetKeyDown("a"))
        {
            currentInput = MovementDirections.Left;
        }
        else if (Input.GetKeyDown("w"))
        {
            currentInput = MovementDirections.Up;
        }
        else if (Input.GetKeyDown("s"))
        {
            currentInput = MovementDirections.Down;
        }

    }
    void WalkingAnimation()
    {
        if(currentInput == MovementDirections.Right)
        {
            animatorController.SetBool("walkRight",true);
            animatorController.SetBool("walkLeft", false);
            animatorController.SetBool("walkUp", false);
            animatorController.SetBool("walkDown", false);
        }
        if (currentInput == MovementDirections.Left)
        {
            animatorController.SetBool("walkRight", false);
            animatorController.SetBool("walkLeft", true);
            animatorController.SetBool("walkUp", false);
            animatorController.SetBool("walkDown", false);
        }
        if (currentInput == MovementDirections.Up)
        {
            animatorController.SetBool("walkRight", false);
            animatorController.SetBool("walkLeft", false);
            animatorController.SetBool("walkUp", true);
            animatorController.SetBool("walkDown", false);
        }
        if (currentInput == MovementDirections.Down)
        {
            animatorController.SetBool("walkRight", false);
            animatorController.SetBool("walkLeft", false);
            animatorController.SetBool("walkUp", false);
            animatorController.SetBool("walkDown", true);
        }
    }
    void Movement()
    {
        float UD = 0f, LR = 0f, t = 0;
        t += Time.fixedDeltaTime;
        if (currentInput == MovementDirections.Up)
        {
            UD = 70.0f; LR = 0f;
            transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x + LR, transform.position.y + UD), t);
        }
        else if (currentInput == MovementDirections.Down)
        {
            UD = -70.0f; LR = 0f;
            transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x + LR, transform.position.y + UD), t);
        }
        else if (currentInput == MovementDirections.Left)
        {
            LR = -70.0f; UD = 0f;
            transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x + LR, transform.position.y + UD), t);
        }
        else if (currentInput == MovementDirections.Right)
        {
            LR =  70.0f; UD = 0f;
            transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x + LR, transform.position.y + UD), t);
        }

        t = 0;
    }
}
