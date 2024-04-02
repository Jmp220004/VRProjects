using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }
    public void MoveUp()
    {
        transform.Translate(0f, 0f, 1f);
    }
    public void MoveDown()
    {
        transform.Translate(0f, 0f, -1f);
    }
    public void MoveForward()
    {
        transform.Translate(0f, 1f, 0f);
    }
    public void MoveBackward()
    {
        transform.Translate(0f, -1f, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "wall")
        {
            transform.Translate(0f, 0f, 0f);
        }
    }

    public void setTarget()
    {
        transform.position = startPos;
    }
}