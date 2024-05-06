using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float playerSpeed = 1f;
    private float rotationSpeed = 720;
    private float jumpForce = 9;
    private bool isGrounded = false;
    private int coinValue = 1;
    private bool levelComplete = false;

    private Vector3 moveDir;
    private Rigidbody playerRb;
    private Animator playerAnim;

    private GameManager gameManagerScript;

    private AudioSource playerAudio;
    public AudioClip collectCoin;
    public AudioClip deadSound;
    public AudioClip catSound;

    public TextMeshProUGUI levelCompleText;
    public Button restartToMainMenuButton;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();

        InvokeRepeating("PlayCatSound", 2, 10);

    }

    // Update is called once per frame
    void Update()
    {
        if (!levelComplete)
        {
            HandleMovement();
            HandleAnimation();
            HandleAudio();
        }
    }

    void PlayCatSound()
    {
        playerAudio.PlayOneShot(catSound, 0.05f);
    }

    void HandleAudio()
    {
        //Play dead Audio
        if (transform.position.y < 0.060)
        {
            playerAudio.PlayOneShot(catSound, 0.05f);
        }
    }
    void HandleMovement()
    {
        float horzInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");

        moveDir = new Vector3(horzInput, 0, vertInput);
        moveDir.Normalize();

        bool jumpInput = Input.GetKeyDown(KeyCode.Space);

        transform.Translate(moveDir * playerSpeed * Time.deltaTime, Space.World);

        if (moveDir != Vector3.zero)
        {
            Quaternion _rotation = Quaternion.LookRotation(moveDir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, _rotation, rotationSpeed * Time.deltaTime);
        }
        if (jumpInput && isGrounded)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void HandleAnimation()
    {
        if(moveDir != Vector3.zero && isGrounded)
        {
            playerAnim.SetBool("isWalking", true);
        }
        else
        {
            playerAnim.SetBool("isWalking", false);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        //Check level complete
        if (col.gameObject.CompareTag("CheckPoint") && FlowersManager.flowerAmount == 5)
        {
            levelCompleText.gameObject.SetActive(true);
            restartToMainMenuButton.gameObject.SetActive(true);
            levelComplete = true;
        }

    }

    //Collect coins
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            playerAudio.PlayOneShot(collectCoin, 0.2f);
            CoinsManager.coin += 1;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("DeadZone"))
        {
            playerAudio.PlayOneShot(catSound, 0.5f);
        }

        if (other.gameObject.CompareTag("DamageZone"))
        {
            Debug.Log(other.gameObject);
            LifeManager.livesAmount -= 1;
            Destroy(other.gameObject);

        }

        if (other.gameObject.CompareTag("PurpleFlower"))
        {
            playerAudio.PlayOneShot(collectCoin, 0.2f);
            FlowersManager.flowerAmount += 1;
            Destroy(other.gameObject);
        }
    }
}
