using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerState))]
[RequireComponent(typeof(PlayerHealth))]
public class Player : MonoBehaviour
{
    [System.Serializable]
    public class MouseInput {
        // to change these 2 options from UI;
        public Vector2 Damping;
        public Vector2 Sensitivity;
        public bool LockMouse;
    }

    [SerializeField] SwatSoldier settings;
    [SerializeField] MouseInput MouseControl;
    [SerializeField] AudioController footSteps;
    [SerializeField] float minimumMoveThreshold;
    [SerializeField] GameObject CanvasMenu;

    public PlayerAim playerAim;

    Vector3 previousPosition;

    private CharacterController m_MoveController;
    public CharacterController MoveController {
        get {
            if (m_MoveController == null) {
                m_MoveController = GetComponent<CharacterController>();
            }
            return m_MoveController;
        }
    }

    private PlayerState m_PlayerState;
    public PlayerState PlayerState
    {
        get
        {
            if (m_PlayerState == null)
            {
                m_PlayerState = GetComponent<PlayerState>();
            }
            return m_PlayerState;
        }
    }

    private PlayerHealth m_PlayerHealth;
    public PlayerHealth PlayerHealth
    {
        get
        {
            if (m_PlayerHealth == null)
            {
                m_PlayerHealth = GetComponent<PlayerHealth>();
            }
            return m_PlayerHealth;
        }
    }

    InputController playerInput;
    Vector2 mouseInput;
    void Awake() {
        playerInput = GameManager.Instance.InputController;
        GameManager.Instance.LocalPlayer = this;
        if (MouseControl.LockMouse) {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void Update() {
        if (!PlayerHealth.IsAlive)
            return;

        if (Input.GetKeyDown(KeyCode.Escape)) {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            CanvasMenu.SetActive(true);
        }

        Move();
        LookAround();

    }

    void Move() {
        float moveSpeed = settings.RunSpeed;

        if (playerInput.IsWalking) {
            moveSpeed = settings.WalkSpeed;
        }

        if (playerInput.IsCrouched)
        {
            moveSpeed = settings.CrouchSpeed;
        }

        if (playerInput.IsSprinting)
        {
            moveSpeed = settings.SprintSpeed;
        }

        Vector2 direction = new Vector2(playerInput.Vertical * moveSpeed, playerInput.Horizontal * moveSpeed);
        
        MoveController.SimpleMove(transform.forward * direction.x + transform.right * direction.y);

        if (Vector3.Distance(transform.position, previousPosition) > minimumMoveThreshold)
        {
            footSteps.Play();
        }


        previousPosition = transform.position;
    }

    void LookAround() {
        mouseInput.x = Mathf.Lerp(mouseInput.x, playerInput.MouseInput.x, 1f / MouseControl.Damping.x);
        mouseInput.y = Mathf.Lerp(mouseInput.y, playerInput.MouseInput.y, 1f / MouseControl.Damping.y);

        transform.Rotate(Vector3.up* mouseInput.x* MouseControl.Sensitivity.x);

        playerAim.SetRotation(mouseInput.y * MouseControl.Sensitivity.y);
    }

}
