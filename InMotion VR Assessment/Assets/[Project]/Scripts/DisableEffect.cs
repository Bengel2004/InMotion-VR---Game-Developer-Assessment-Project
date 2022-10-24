using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableEffect : MonoBehaviour
{
    private float delay = 1f;
    private void OnEnable()
    {
        StartCoroutine(DisableCurrentEffect());
    }

    /// <summary>
    /// Just turns off the game object after it's been used, so it can be pooled again.
    /// </summary>
    /// <returns></returns>
    private IEnumerator DisableCurrentEffect()
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}
