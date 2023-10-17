using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5;

    [SerializeField] float xRange;
    [SerializeField] float maxBounceAngle = 75f;

    Vector2 newPos;

    float moveInput;

    void Update()
    {
        GetInput();
    }

    void GetInput()
    {
        moveInput = Input.GetAxis("Horizontal");
        newPos = transform.position;
        newPos.x += moveSpeed * moveInput * Time.deltaTime;
        newPos.x = Mathf.Clamp(newPos.x, -xRange, xRange);
        newPos.y = -8;

        transform.position = newPos;
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Ball ball = other.gameObject.GetComponent<Ball>();

        if(ball != null)
        {
            Vector3 paddlePos = this.transform.position;
            Vector2 contactPoint = other.GetContact(0).point;

            float offset = paddlePos.x - contactPoint.x;
            float width = other.otherCollider.bounds.size.x / 2;

            float currentAngle = Vector2.SignedAngle(Vector2.up, ball.myRigid.velocity);
            float bounceAngle = (offset / width) * this.maxBounceAngle;
            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -this.maxBounceAngle, this.maxBounceAngle);
        
            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball.myRigid.velocity = rotation * Vector2.up * ball.myRigid.velocity.magnitude;
        } 
    }

}
