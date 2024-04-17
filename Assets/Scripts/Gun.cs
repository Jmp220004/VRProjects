using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class Gun : MonoBehaviour
{
    [Header("Gun Settings")]
    [SerializeField] private int _ammoCurrent;
    [SerializeField] public Clip _insertClip;
    [Space]
    [SerializeField] private UnityEvent _onFire;
    [SerializeField] private UnityEvent _onFireNoAmmo;
    [Space]
    [Header("Fill References")]
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private GameObject _bulletHolePrefab;
    [SerializeField] private XRSocketInteractor _clipSocket;

    public void attemptFire()
    {
        //Only fire if the clip is loaded
        if (_insertClip != null)
        {
            //If the gun has ammo, shoot a bullet. If the gun has no ammo, play the "fail shoot sound"
            if (_ammoCurrent > 0)
            {
                _ammoCurrent--;
                shootBullet();
                _onFire.Invoke();
            }
            else
            {
                _onFireNoAmmo.Invoke();
            }
        }
        else
        {
            _onFireNoAmmo.Invoke();
        }
    }

    private void shootBullet()
    {
        Ray ray = new Ray(_shootPoint.transform.position, _shootPoint.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject newBullet = Instantiate(_bulletHolePrefab, hit.point, _shootPoint.rotation);
            newBullet.transform.parent = hit.collider.transform;
        }
    }

    public void loadClip()
    {
        GameObject loadedClipObject = _clipSocket.GetOldestInteractableSelected().transform.gameObject;
        _insertClip = loadedClipObject.GetComponent<Clip>();
        if (_insertClip != null)
        {
            _ammoCurrent = _insertClip.bullets;
            _insertClip.disableArt();
        }
    }

    public void unloadClip()
    {
        _insertClip?.enableArt();
        _insertClip.bullets = _ammoCurrent;
        _insertClip = null;
    }

    public void onGrab()
    {
        _insertClip?.enableClipHitbox();
    }

    public void onRelease()
    {
        _insertClip?.disableClipHitbox();
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
