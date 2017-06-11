using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int health = 8;
    public AudioClip[] hitSounds;
    public AudioClip deathSound;

    private SpriteRenderer mRend;
    private bool isInvincible;
    private bool isEnemy;

    private void Start() {
        mRend = GetComponent<SpriteRenderer>();
        isEnemy = (GetComponent<Enemy>() != null);

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
            if (!isEnemy) {
                isInvincible = true;
            }
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
			float blinkInterval = 0.1f;
            Color standardColour = mRend.color;
			bool active = false;

			for (int i = 0; i < 20; i++) {
				mRend.color = active ? Color.red : standardColour;
				yield return new WaitForSeconds(blinkInterval);
				active = !active;
			}

			mRend.color = standardColour;
            isInvincible = false;
            yield return null;
        }
    }

    public void Die() {
        // TODO: activate death animation here
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
        if (GetComponent<Player>() != null) {
            GameObject transitionPanel = GameObject.Find("Level transition panel");
            if (transitionPanel != null) {
                transitionPanel.GetComponent<Animator>().SetTrigger("deathTrigger");
            }
        } else {
            Destroy(gameObject, deathSound.length);
        }
    }
}
