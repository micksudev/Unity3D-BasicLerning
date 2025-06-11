using UnityEngine;

public class SuperSimpleCharacter : MonoBehaviour
{
    public float WalkingSpeed = 2f;
    public float RunningSpeed = 5f;
    public Animator Animator;

    private bool isRunning;
    private void Update()
    {
        bool isWalking = false;
        Vector3 moveDirection = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += new Vector3(0, 0, 1);
            isWalking = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveDirection += new Vector3(0, 0, -1);
            isWalking = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveDirection += new Vector3(-1, 0, 0);
            isWalking = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += new Vector3(1, 0, 0);
            isWalking = true;
        }
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
        
        if (isRunning && isWalking)
        { 
            Move(moveDirection, RunningSpeed);
            SetAnimatorState("Running");
        }
        else if (isWalking)
        {
            Move(moveDirection, WalkingSpeed);
            SetAnimatorState("Walking");
        }
        else
        {
            SetAnimatorState("Idle");
        }

    }

    private void Move(Vector3 moveDirection, float speed)
    {
        moveDirection.Normalize();
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
        transform.rotation = Quaternion.LookRotation(moveDirection);
    }
    
    private void SetAnimatorState(string stateName)
    {
        if (stateName == "Idle")
        {
            Animator.SetBool("Idle", true);
            Animator.SetBool("Walking", false);
            Animator.SetBool("Running", false);
        }
        else if (stateName == "Walking")
        {
            Animator.SetBool("Idle", false);
            Animator.SetBool("Walking", true);
            Animator.SetBool("Running", false);
        }
        else if (stateName == "Running")
        {
            Animator.SetBool("Idle", false);
            Animator.SetBool("Walking", false);
            Animator.SetBool("Running", true);
        }
    }

}


