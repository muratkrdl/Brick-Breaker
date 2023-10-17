using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D myRigid;
    [SerializeField] float speed = 500f;

    Vector2 startpos;

    void Start() 
    {
        startpos = transform.position;
        Invoke("SetRandomTrajectory", 1f);
    }

    void SetRandomTrajectory()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1,1);
        force.y = -1;

        myRigid.AddForce(force.normalized * speed);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Bottom"))
        {
            transform.position = startpos;
            myRigid.velocity = Vector2.zero;
            Invoke("SetRandomTrajectory", 1f);
            GameManager.Instance.DecreaseLive();
        }      
    }

}
