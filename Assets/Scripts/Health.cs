using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int health = 3;
    private SpriteRenderer mRend;
    private bool isInvincible;

    private void Start() {
        mRend = GetComponent<SpriteRenderer>();
        if (mRend == null) {
            mRend = GetComponentInChildren<SpriteRenderer>();
        }
    }

    public void TakeDamage(int amount) {
        // TODO: Activate damage animation here
        if (!isInvincible) {
            Debug.Log(name + " took damage: " + amount);
            isInvincible = true;
            StartCoroutine(FlashAfterDamage());
            health -= amount;
            if (health <= 0) {
                Die();
            }
        }
    }

    IEnumerator FlashAfterDamage() {
        if (mRend != null) {
            Color standardColour = mRend.color;
            mRend.color = Color.red;
            yield return new WaitForSeconds(0.15f);
            mRend.color = standardColour;
            yield return new WaitForSeconds(0.15f);
            mRend.color = Color.red;
            yield return new WaitForSeconds(0.15f);
            mRend.color = standardColour;
            yield return new WaitForSeconds(0.15f);
            mRend.color = Color.red;
            yield return new WaitForSeconds(0.15f);
            mRend.color = standardColour;
            isInvincible = false;
            yield return null;
        }
    }

    public void Die() {
        // TODO: activate death animation here
        if (GetComponent<Player>() != null) {
            FindObjectOfType<RoomManager>().ResetLevel();
        }
        Destroy(gameObject);
    }
}
