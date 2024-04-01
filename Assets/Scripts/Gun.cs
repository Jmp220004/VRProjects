using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Gun Settings")]
    [SerializeField] private int _ammoCurrent;
    [SerializeField] private int _ammoMax;
    [SerializeField] public bool _clipLoaded;
    [Space]
    [Header("Fill References")]
    [SerializeField] private Transform _shootPoint;


    public void attemptFire()
    {
        //Only fire if the clip is loaded
        if(_clipLoaded)
        {
            //If the gun has ammo, shoot a bullet. If the gun has no ammo, play the "fail shoot sound"
            if(_ammoCurrent > 0)
            {
                _ammoCurrent--;
                shootBullet();
                //Play fire sound
            }
            else
            {
                //Play fail sound
            }
        }
    }

    private void shootBullet()
    {
        Ray ray = new Ray(_shootPoint.transform.position, _shootPoint.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;

        Ray ray = new Ray(_shootPoint.transform.position, _shootPoint.forward);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        Gizmos.DrawLine(_shootPoint.transform.position, hit.point);
    }
}
