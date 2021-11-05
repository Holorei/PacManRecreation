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
        if (CheckCanTurn())
        {
            currentInput = lastInput;
            Movement();
            WalkingAnimation();
        }
        else if (!CheckCanTurn() && currentInput == lastInput)
        {
            //nothing
        }
        else
        {
            Movement();
            WalkingAnimation();
        }

    }

    void GetMovementInput()
    {
        if (Input.GetKeyDown("d"))
        {

            lastInput = MovementDirections.Right;
        }
        else if (Input.GetKeyDown("a"))
        {
            lastInput = MovementDirections.Left;
        }
        else if (Input.GetKeyDown("w"))
        {
            lastInput = MovementDirections.Up;
        }
        else if (Input.GetKeyDown("s"))
        {
            lastInput = MovementDirections.Down;
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

            UD = 3f; LR = 0f;
            transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x + LR, transform.position.y + UD), t);
        }
        else if (currentInput == MovementDirections.Down)
        {
            UD = -3f; LR = 0f;
            transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x + LR, transform.position.y + UD), t);
        }
        else if (currentInput == MovementDirections.Left)
        {
            LR = -3f; UD = 0f;
            transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x + LR, transform.position.y + UD), t);
        }
        else if (currentInput == MovementDirections.Right)
        {
                LR = 3f; UD = 0f;
                transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x + LR, transform.position.y + UD), t);

        }

        t = 0;
    }

    bool CheckCanTurn()
    {
        Vector2 rayDirection = Vector2.zero;
        switch (lastInput)
        {
            case MovementDirections.Right:
                rayDirection = Vector3.right;
                break;

            case MovementDirections.Left:
                rayDirection = Vector3.left;
                break;

            case MovementDirections.Up:
                rayDirection = Vector3.up;
                break;

            case MovementDirections.Down:
                rayDirection = Vector3.down;
                break;

        }
        RaycastHit2D isHit = Physics2D.Raycast(gameObject.transform.position, rayDirection, 0.7f);

        if (isHit)
        {
            Debug.Log("Raycast hit: " + isHit.collider.name);
            return false;
        }
        return true;
    }

}
