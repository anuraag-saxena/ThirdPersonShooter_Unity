using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCounter : MonoBehaviour
{
    [SerializeField] Text text;

    PlayerShoot playerShoot;
    WeaponReloader reloader;

    void Awake()
    {
        GameManager.Instance.OnLocalPlayerJoined += HandleOnLocalPlayerJoined;
    }

    void HandleOnLocalPlayerJoined(Player player) { 
        playerShoot = player.GetComponent<PlayerShoot>();
        playerShoot.OnWeaponSwitch += HandleOnWeaponSwitch;
    }

    void HandleOnWeaponSwitch(Shooter activeWeapon) {
        reloader = activeWeapon.Reloader;
        reloader.OnAmmoChanged += HandleOnAmmoChanged;
        HandleOnAmmoChanged();
    }

    void HandleOnAmmoChanged() {
        int ammountInInventory = reloader.RoundsRemainingInInventory;
        int ammountInClip = reloader.RoundsRemainingInClip;
        text.text = string.Format("{0}/{1}", ammountInClip, ammountInInventory);
    }

    void Update()
    {
        
    }
}
