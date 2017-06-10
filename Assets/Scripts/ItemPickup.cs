using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Item {
    Gun,
    Health,
    Exp
}

public class ItemPickup : MonoBehaviour {

    public Item itemType;
    private InventoryDisplay inventoryDisplay;

    private void Start() {
        inventoryDisplay = FindObjectOfType<InventoryDisplay>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Player player = collision.GetComponent<Player>();
        if (player != null) {
            player.PickupItem(itemType);
            inventoryDisplay.AddWeapon(itemType);
            Destroy(gameObject);
        }
    }
}
