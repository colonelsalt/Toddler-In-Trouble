using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int health = 8;
    public AudioClip[] hitSounds;
    public AudioClip deathSound;

	private SpriteRenderer spriteRenderer;
    private bool isInvincible;
    private bool isPlayer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null) {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

		isPlayer = (GetComponent<Player>() != null);
    }

    public void TakeDamage(int amount) {
        // TODO: Activate damage animation here
		if (!isInvincible) {
			health -= amount;
            if (hitSounds.Length > 0) {
                PlayHitSound();
            }

			if (isPlayer) {
				isInvincible = true;
			}

            if (health <= 0) {
                Die();
			}

			StartCoroutine(FlashAfterDamage());
        }
    }

	public void broadcastHealth() {
		Root.broadcastAll ("livesRemaining", health);
	}

    private void PlayHitSound() {
        AudioClip soundToPlay = hitSounds[Random.Range(0, hitSounds.Length)];
        AudioSource.PlayClipAtPoint(soundToPlay, transform.position);
    }

    IEnumerator FlashAfterDamage() {
        if (spriteRenderer != null) {
			float blinkInterval = 0.1f;
            Color standardColour = spriteRenderer.color;
			bool active = false;

			for (int i = 0; i < 20; i++) {
				spriteRenderer.color = active ? Color.red : standardColour;
				yield return new WaitForSeconds(blinkInterval);
				active = !active;
			}

			spriteRenderer.color = standardColour;
            isInvincible = false;
            yield return null;
        }
    }

    public void Die() {
        // TODO: activate death animation here
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
		if (isPlayer) {
            GameObject transitionPanel = GameObject.Find("Level transition panel");
            if (transitionPanel != null) {
                transitionPanel.GetComponent<Animator>().SetTrigger("deathTrigger");
            }
			health = 3;
        } else {
            Destroy(gameObject, deathSound.length);
        }
    }
}
