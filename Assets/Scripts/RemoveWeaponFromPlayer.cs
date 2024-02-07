using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveWeaponFromPlayer : MonoBehaviour
{
    private PlayerItemSelect playerItemSelect;

    private void Start()
    {
        playerItemSelect = GetComponent<PlayerItemSelect>();
    }
    void Update()
    {
        if (transform.childCount == 0)
        {
            playerItemSelect.Espada.SetActive(false);
            playerItemSelect.Martillo.SetActive(false);

        }
    }
}

