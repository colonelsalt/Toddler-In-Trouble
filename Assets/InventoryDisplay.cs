using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour {

    public Sprite[] weaponSprites;
    private SpriteRenderer currentWeaponRend;

    private void Start() {
        currentWeaponRend = GetComponent<SpriteRenderer>();
    }

    public void AddWeapon(Item itemType) {
        currentWeaponRend.sprite = weaponSprites[(int)itemType];
    }
}
