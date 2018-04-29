using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    // Private and invisible in inspector
    private bool facingRight;
    private bool jumping;
    private float speed;
    private bool isCollected = false;
    private InGameUIScript inGameUIScript;

    // Private and visible in inspector
    [SerializeField]
    private float speedX = 0,
                  speedY = 0;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private GameObject ground;
    [SerializeField]
    private GameObject pickup;
    [SerializeField]
    private GameObject endPortal;
    [SerializeField]
    private GameObject cam;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private ParticleSystem deathAnim;
    [SerializeField]
    private SpriteRenderer rend;

    // Use this for initialization
    void Start () {
        facingRight = true;
        inGameUIScript = gameObject.GetComponent<InGameUIScript>();
        deathAnim.Pause();
    }
	
	// Update is called once per frame
	void Update () {

        // Calls method that checks if the player should be still alive
        CheckIfDying();

        // Player movement
        MovePlayer(speed);
        Flip();

       // Left player movement
        LeftPlayerMovement();

        // Right player movement
        RightPlayerMovement();

        // Jumping
        JumpMovement();

    }
    // Sends the player back to the main menu when clicked on the "Back to main menu" button or when won/lost
    public void BackToStartMenu() {
        SceneManager.LoadScene("StartScene");
    }

    // Checks if player should die
    private void CheckIfDying() {
        // If the ammount of health is eaquel or less than 0 the player is invisible, the deathanimation is played and the game is over
        if(inGameUIScript.health <= 0)
        { 
           StartCoroutine(TimeBetween());            
        }
    }

    private IEnumerator TimeBetween () {
      // Play death animation, make character invisible, wait until animation is done, go back to startmenu 
           deathAnim.Play();
           rend.enabled = !enabled;
           yield return new WaitForSeconds(3);
           BackToStartMenu();
    }

    
    // Flip if switching to the other side
    private void Flip() {
        // Code to flip the character to the right disrection
        if (speed > 0 && !facingRight || speed < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 tempScale = transform.localScale;
            tempScale.x *= -1;
            transform.localScale = tempScale;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject == ground)
        {
            jumping = false;
            anim.SetInteger("state", 0);
            anim.SetBool("shouldJump", false);
            anim.SetBool("shouldWalk", false);
        }

        if (other.gameObject == pickup)
        {
            other.gameObject.transform.SetParent(transform);
            isCollected = true;
        }

        // If touched RotatingObstacle health decreases by 50
        if (other.gameObject.tag == "RotatingObstacle")
        {
            // Health - 40
            inGameUIScript.health = inGameUIScript.health - 40f;
        }

        // If touched PassingByObstacle health decreases by 25
        if (other.gameObject.tag == "PassingByObstacle")
        {
            // Health - 10
            inGameUIScript.health = inGameUIScript.health - 10f;
        }
        if (other.gameObject == endPortal && isCollected)
        {
            inGameUIScript.Won(); 
        }

    }

    // Player movement with keys
    private void MovePlayer(float playerSpeed) {
        // Code for player movement
        rb.velocity = new Vector3(speed, rb.velocity.y, 0);

        if (playerSpeed < 0 && !jumping || playerSpeed > 0 && !jumping)
        {
            anim.SetInteger("state", 1);
            anim.SetBool("shouldJump", false);
            anim.SetBool("shouldWalk", true);
        }

        if (playerSpeed == 0 && !jumping)
        {
            anim.SetInteger("state", 0);
            anim.SetBool("shouldJump", false);
            anim.SetBool("shouldWalk", false);
        }
    }
    private void LeftPlayerMovement() {
        // Check if keys for player movement left are pressed and what to do if so
        if (Input.GetKeyDown(KeyCode.A))
        {
            speed = -speedX;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            speed = 0;
        }
    }

    private void RightPlayerMovement() {
        // Check if keys for player movement right are pressed and what to do if so
        if (Input.GetKeyDown(KeyCode.D))
        {
            speed = speedX;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            speed = 0;
        }
    }
    private void JumpMovement() {
        // Check if keys for jumping are pressed and what to do if so
        if (Input.GetKeyDown(KeyCode.W) && !jumping)
        {
            jumping = true;
            rb.AddForce(new Vector2(rb.velocity.x, speedY));
            anim.SetInteger("state", 2);
            anim.SetBool("shouldJump", true);
            anim.SetBool("shouldWalk", false);
        }
    }

    //Methods for moving the player character by UI buttons
    public void WalkLeft() {
        speed = -speedX;
    }

    public void WalkRight() {
        speed = speedX;
    }

    public void Jump() {
        if (!jumping)
        {
            jumping = true;
            rb.AddForce(new Vector2(rb.velocity.x, speedY));
            anim.SetInteger("state", 2);
            anim.SetBool("shouldJump", true);
            anim.SetBool("shouldWalk", false);
        }
    }

    public void StopMoving() {
        speed = 0;
    }
}
