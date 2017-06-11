using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed = 3f;
    public float bounceBackForce = 3f;
	public GameObject healthBar;

	private static GameObject healthBarInstance;
    private static Player instance;

    private ArrayList inventory;
    private Animator anim;
    private Rigidbody2D mBody;

	private void createHealthBar() {
		if (healthBarInstance == null) {
			healthBarInstance = Instantiate(healthBar);
			DontDestroyOnLoad(healthBarInstance);
			healthBarInstance.transform.position = new Vector2 (0.5f, 13.5f);
		}
	}

	private void Awake() {
		createHealthBar ();
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        inventory = new ArrayList();
        anim = GetComponent<Animator>();
        mBody = GetComponent<Rigidbody2D>();
    }

    private void Update () {

        float newX = Input.GetAxis("Horizontal");
        float newY = Input.GetAxis("Vertical");

        if (newX > 0) {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            anim.SetTrigger("horizontalWalkTrigger");
        } else if (newX < 0) {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            anim.SetTrigger("horizontalWalkTrigger");
        } else if (newY < 0) {
            anim.SetTrigger("frontWalkTrigger");
        } else if (newY > 0) {
            anim.SetTrigger("backWalkTrigger");
        } else {
            anim.SetTrigger("standTrigger");
        }

		Health healthComponent = GetComponent<Health> ();
		healthComponent.broadcastHealth ();

        Vector2 desiredVelocity = new Vector2 (newX, newY);

		desiredVelocity *= speed;
		mBody.velocity = desiredVelocity;
	}

    public void PickupItem(Item item) {
        if (item == Item.Gun && !inventory.Contains(item)) {
            GetComponentInChildren<Weapon>().Activate();
            inventory.Add(item);
        }
    }

    public void SetSpriteVisibility(bool visibility) {
        transform.localScale = (visibility) ? Vector3.one : Vector3.zero;
    }
}