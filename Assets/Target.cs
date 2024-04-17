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
        transform.Translate(0f, 0f, 0.5f);
        destroyBullets();
    }
    public void MoveDown()
    {
        transform.Translate(0f, 0f, -0.5f);
        destroyBullets();
    }
    public void MoveForward()
    {
        transform.Translate(0f, 0.5f, 0f);
        destroyBullets();
    }
    public void MoveBackward()
    {
        transform.Translate(0f, -0.5f, 0f);
        destroyBullets();
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
        destroyBullets();
    }

    private void destroyBullets()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}