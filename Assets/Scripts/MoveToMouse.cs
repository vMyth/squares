using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMouse : MonoBehaviour
{
    private Vector3 targetPosition;
    private Vector3 lookAtTarget;
    private Quaternion playerRot;
    private float rotSpeed = 5;
    private float speed = 50;
    private bool isMoving = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetPosition();
        }
        if(isMoving)
            Move();
    }

    private void SetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 1000))
        {
            targetPosition = hit.point;
            lookAtTarget = new Vector3(targetPosition.x - this.transform.position.x,
                this.transform.position.y,
                targetPosition.z - this.transform.position.z);
            playerRot = Quaternion.LookRotation(lookAtTarget);
            isMoving = true;
        }
    }

    private void Move()
    {
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, 
            playerRot, 
            rotSpeed * Time.deltaTime);
        this.transform.position = Vector3.MoveTowards(this.transform.position,
            targetPosition,
            speed * Time.deltaTime);
        if (Vector3.Distance(this.transform.position, targetPosition) <= 2)
            isMoving = false;
    }
}
