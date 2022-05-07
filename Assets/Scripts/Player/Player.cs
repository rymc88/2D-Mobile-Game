using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour, IDamageable
{
    private Rigidbody2D _rb;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _groundLayer;
    private bool _resetJump = false;
    [SerializeField] float _speed;
    private Animator _anim;
    private SpriteRenderer _playerSprite;
    private SpriteRenderer _swordArcSprite;
    private PlayerAnimation _playerAnim;
    public int gems;

    public int Health { get; set; }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponentInChildren<Animator>();
        _playerSprite = GetComponentInChildren<SpriteRenderer>();
        _swordArcSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
        _playerAnim = GetComponent<PlayerAnimation>();
        Health = 4;

        if(_playerAnim == null)
        {
            Debug.Log("Player Animation script is null");
        }

        if(_playerSprite == null)
        {
            Debug.Log("Sprite Renderer is null");
        }
       
        if(_anim == null)
        {
            Debug.Log("Animator is null");
        }

        if(_rb == null)
        {
            Debug.Log("Rigidbody2D is null");
        }

        if(_swordArcSprite == null)
        {
            Debug.Log("Sword Arc Sprite is null");
        }
       
    }

    void Update()
    {
        Movement();

        if(CrossPlatformInputManager.GetButtonDown("A_Button") && IsGrounded() == true)
        {
            _playerAnim.Attack();
        }

    }

    void Movement()
    {
        float horizontalInput = CrossPlatformInputManager.GetAxisRaw("Horizontal"); //Input.GetAxisRaw("Horizontal");
        IsGrounded();

        Flip(horizontalInput);

        if (Input.GetKeyDown(KeyCode.Space) || CrossPlatformInputManager.GetButtonDown("B_Button") && IsGrounded() == true)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            _playerAnim.Jump(true);
            _resetJump = true; // jumped!
            StartCoroutine(ResetJumpRoutine());
        }

        _rb.velocity = new Vector2(horizontalInput * _speed, _rb.velocity.y);

        _playerAnim.Move(horizontalInput);
    }

    bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1f, _groundLayer.value);
        Debug.DrawRay(transform.position, Vector2.down, Color.green);

        if (hitInfo.collider != null) //hit the ground
        {
            if(_resetJump == false) // did not jump
            {
                _playerAnim.Jump(false);
                return true;
            }
        }

        return false;
    }

    void Flip(float horizontalInput)
    {
        if(horizontalInput < 0)
        {
            _playerSprite.flipX = true;
            _swordArcSprite.flipX = true;
            _swordArcSprite.flipY = true;

            Vector3 newPos = _swordArcSprite.transform.localPosition;
            newPos.x = -1.01f;
            _swordArcSprite.transform.localPosition = newPos;
           
        }
        else if(horizontalInput > 0)
        {
            _playerSprite.flipX = false;
            _swordArcSprite.flipX = false;
            _swordArcSprite.flipY = false;

            Vector3 newPos = _swordArcSprite.transform.localPosition;
            newPos.x = 1.01f;
            _swordArcSprite.transform.localPosition = newPos;

        }
    }

    public void Damage()
    {
        if(Health < 1)
        {
            return;
        }

        Debug.Log("Player Damage");
        Health--;
        UIManager.Instance.UpdateLives(Health);

        if(Health < 1)
        {
            _playerAnim.Death();
        }
    }

    public void AddGems(int amount)
    {
        gems += amount;
        UIManager.Instance.UpdateGemCount(gems);
    }

    public void SubtractGems(int amount)
    {
        gems -= amount;
        UIManager.Instance.UpdateGemCount(gems);
    }

    IEnumerator ResetJumpRoutine()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }
}
