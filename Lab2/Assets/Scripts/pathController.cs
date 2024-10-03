using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathController : MonoBehaviour
{
    [SerializeField]
    pathManager PathManager;

    List<wayPoint> thePath;
    wayPoint target;

    public float moveSpeed;
    public float rotateSpeed;

    public Animator Animator;
    bool isRunning;

    private void Start()
    {
        isRunning = false;Animator.SetBool("isRunning", isRunning);
        thePath = PathManager.GetPath();
        if (thePath != null && thePath.Count > 0)
        {
            //set the starting target to the first waypoint
            target = thePath[0];
        }
    }

    void RotateTowardsTarget()
    {
        float stepSize = rotateSpeed * Time.deltaTime;

        Vector3 targetDir = target.pos - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, stepSize, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
    }
    void MoveForward()
    {
        float stepSize = Time.deltaTime * moveSpeed;
        float distanceToTarget = Vector3.Distance(transform.position, target.pos);
        if (distanceToTarget < stepSize)
        {
            //wewill overshoot the target so we should do something smarter here
            return;
        }
        //take a step forwards
        Vector3 moveDir = Vector3.forward;
        transform.Translate(moveDir * stepSize);
    }
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            //toggle if any key is pressed
            isRunning = !isRunning;
            Animator.SetBool("isRunning", isRunning);
        }
        if (isRunning)
        {
            RotateTowardsTarget();
            MoveForward();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //switch to next target
        target = PathManager.GetNextTarget();
    }

    
}
