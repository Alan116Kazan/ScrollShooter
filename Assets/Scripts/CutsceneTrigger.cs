using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneTrigger : MonoBehaviour
{
    [SerializeField] private PlayableDirector _director;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsPlayerLayer(collision.gameObject.layer))
        {
            _director.Play();
        }
    }

    private bool IsPlayerLayer(int layer)
    {
        return layer == LayerMask.NameToLayer("Player");
    }

}
