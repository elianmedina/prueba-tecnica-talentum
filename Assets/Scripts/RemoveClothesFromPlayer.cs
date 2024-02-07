using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveClothesFromPlayer : MonoBehaviour
{
    private PlayerItemSelect playerItemSelect;

    private void Start()
    {
        playerItemSelect = GetComponent<PlayerItemSelect>();
    }
    void Update()
    {
        if(transform.childCount == 0)
        {
            playerItemSelect.BotasCubierto.SetActive(false);

            for(int i = 0; i < playerItemSelect.SuperiorCubierto.Length; i++)
            {
                playerItemSelect.SuperiorCubierto[i].SetActive(false);
            }
        }
    }
}
