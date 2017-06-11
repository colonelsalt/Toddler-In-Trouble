using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int health = 3;
    public AudioClip[] hitSounds;
    public AudioClip deathSound;

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
            if (hitSounds.Length > 0) {
                PlayHitSound();
            }
            isInvincible = true;
            StartCoroutine(FlashAfterDamage());
            health -= amount;
            if (health <= 0) {
                Die();
            }
        }
    }

    private void PlayHitSound() {
        AudioClip soundToPlay = hitSounds[Random.Range(0, hitSounds.Length)];
        AudioSource.PlayClipAtPoint(soundToPlay, transform.position);
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
