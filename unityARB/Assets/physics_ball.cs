using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class physics_ball : MonoBehaviour
{
    Vector3 initPos;
    Vector3 startPos;
    Vector3 endPos;
    Rigidbody ballRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        initPos = GameObject.Find("ball").transform.position;
        ballRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            endPos = Input.mousePosition;
            ballRigidBody.AddForce(endPos - startPos * 0.01f * Time.deltaTime, ForceMode.Impulse);
            ballRigidBody.AddForce(new Vector3(0, 0, 20), ForceMode.Impulse);
            GameObject.Find("ball").transform.position = Vector3.MoveTowards(GameObject.Find("ball").transform.position, GameObject.Find("board").transform.position, 0.1f);
        }
        if (Mathf.Abs(GameObject.Find("ball").transform.position.x) >= 2000 || Mathf.Abs(GameObject.Find("ball").transform.position.y) >= 2000 || Mathf.Abs(GameObject.Find("ball").transform.position.z) >= 2000)
        {
            ballRigidBody.velocity = Vector3.zero;
            GameObject.Find("ball").transform.position = initPos;
        }

    }
}
