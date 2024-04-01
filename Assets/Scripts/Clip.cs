using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Clip : MonoBehaviour
{
    public int bullets;
    [SerializeField] private GameObject artToDisableOnLoad;
    [SerializeField] private GameObject grabCollider;
    [SerializeField] private float _despawnTimeSeconds; //The time it takes for a clip to despawn after it's removed from a gun

    public void disableArt()
    {
        artToDisableOnLoad.SetActive(false);
    }

    //Fires when a clip is removed from the gun
    public void enableArt()
    {
        artToDisableOnLoad.SetActive(true);

        StartCoroutine(checkDespawnClip());
        
    }

    private IEnumerator checkDespawnClip()
    {
        yield return null;

        if (bullets <= 0)
        {
            grabCollider.SetActive(false);

            yield return new WaitForSeconds(_despawnTimeSeconds);

            Destroy(gameObject);
        }

        yield break;
    }
}
