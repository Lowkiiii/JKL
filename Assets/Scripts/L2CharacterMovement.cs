using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class L2CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float horizontalInput;
    public float jumpHeight = 5;
    public bool isJumping = false;
    AudioSource jumpsound;

    private Vector2 velocity;
    private float inputAxis;

    public float moveSpeed = 8f;

    public float blinkTime = 0.2f;
    private bool isBlinking = false;
    private SpriteRenderer spriteRenderer;
    public Text gameoverText;

    public AudioClip loseSound; // the sound effect to play when the player loses
    private AudioSource audioSource;
    Animator anim;

    private int collectedEnergies = 0;

    private void Awake()
    {
        jumpsound = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>(); // get the AudioSource component on the player object
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            jumpsound.Play();
        }
    }

    private void FixedUpdate()
    {
        if (!isBlinking)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");

            if (horizontalInput == 0)
            {
                anim.SetBool("isWalking", false);
            }
            else
            {
                anim.SetBool("isWalking", true);
                if (horizontalInput < 0)
                {
                    transform.localScale = new Vector2(-1, 1);
                }
                else
                {
                    transform.localScale = new Vector2(1, 1);
                }
            }

            transform.Translate(Vector2.right * horizontalInput * moveSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            StartCoroutine(GameOverSequence());
        }

        /*if (collision.gameObject.CompareTag("Enemy"))
        {
            audioSource.PlayOneShot(loseSound); // play the lose sound effect
            // code to handle the player losing goes here
        }*/

        if (collision.collider.tag == "Floor" || collision.collider.tag == "block")
        {
            isJumping = false;
        }

        if (collision.collider.CompareTag("Totem"))
        {
            if (collectedEnergies == 15)
            {
                SceneManager.LoadScene("Level Complete");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MyCoin"))
        {
            collectedEnergies++;
            Destroy(other.gameObject);
        }
    }

    IEnumerator GameOverSequence()
    {
        // Disable the character movement
        enabled = false;

        // Blink the character for 3 seconds
        for (int i = 0; i < 6; i++)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(blinkTime);
        }

        // Destroy the character object
        Destroy(this.gameObject);

        //audioSource.Stop();
        SceneManager.LoadScene("Play Again");



    }
}
