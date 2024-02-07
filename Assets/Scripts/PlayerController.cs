using TMPro;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Transform cameraTransform;

    public float speed = 6.0f;
    public float rotationSpeed = 700.0f;
    public float jumpForce = 8.0f;
    public float gravity = 20.0f;
    private float verticalVelocity = 0.0f;

    private Vector3 moveDirection = Vector3.zero;

    public bool onInventory = false;

    public GameObject textToOpenInventory;
    public GameObject myInventory;
    public SceneController sceneController;
    public AudioClip sonido;
    public TMP_Text[] coords;

    Animator anim;
    bool isMoving, isJumping;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;
        anim = GetComponent<Animator>();
        GetComponent<AudioSource>().playOnAwake = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Espada" || other.tag == "Martillo" || other.tag == "Superior" || other.tag == "Botas")
        {
            GetComponent<AudioSource>().clip = sonido;
            GetComponent<AudioSource>().Play();
        }
    }

    private void Update()
    {
        if (!sceneController.isPaused)
        {
            if (!onInventory)
            {
                HandleMovement();
                if (Input.GetKeyDown(KeyCode.Tab))
                {
                    OpenInventory();
                }
            }
            else
            {
                if (Input.GetKeyUp(KeyCode.Tab))
                {
                    CloseInventory();
                }
            }
        }

        coords[0].text = transform.position.x.ToString();
        coords[1].text = transform.position.y.ToString();
        coords[2].text = transform.position.z.ToString();

        if (isMoving)
        {
            anim.SetBool("caminando", true);
        }
        else
        {
            anim.SetBool("caminando", false);
        }

        if (isJumping)
        {
            anim.SetBool("saltando", true);
        }
        else
        {
            anim.SetBool("saltando", false);
        }
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 inputDir = cameraTransform.forward * vertical + cameraTransform.right * horizontal;
        inputDir.y = 0; 
        if (inputDir.magnitude >= 0.1f)
        {
            inputDir.Normalize();
            isMoving = true;
        }

    
        if (inputDir.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(inputDir.x, inputDir.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationSpeed, 0.1f);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            isMoving = true;
        }
        else
        {
            moveDirection = Vector3.zero;
            isMoving = false;
        }

 
        if (controller.isGrounded)
        {
            moveDirection.y = 0;
            isJumping = false;
        
            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = jumpForce;
                isJumping = true;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        moveDirection.y = verticalVelocity;

        controller.Move(moveDirection * speed * Time.deltaTime);

    }

    void OpenInventory()
    {
        onInventory = true;
        textToOpenInventory.SetActive(false);
        myInventory.SetActive(true);
        Cursor.visible = true;

    }

    public void CloseInventory()
    {
        onInventory = false;
        myInventory.SetActive(false);
        textToOpenInventory.SetActive(true);
        Cursor.visible = false;
    }
}
