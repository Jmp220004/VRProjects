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
    [SerializeField] Transform shootPoint;


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
            }
            else
            {

            }
        }
    }

    private void shootBullet()
    {

    }
}
