using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public CharacterController controller;
    public float speed;
    [HideInInspector] Vector3 direction;
    [HideInInspector] float h, v;
    int fastMove;

    public float gravity = -9.81f;
    public Vector3 velocity;
    

    public float groundOffset;
    public LayerMask groundMask;
    public Vector3 spherePos;

    public Animator anim;


    [HideInInspector] float halfScreenWidth, halfScreenHeight;
    [SerializeField] Transform aimPos;
    [SerializeField] float aimSpeed = 20;
    [SerializeField] LayerMask aimMask;

    public new AudioSource audio;

    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    public Image healthBarPlayer;
    public float width;


    public Text gunMagazineText;
    public int gunMagazine;
    public Shoot shoot;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        currentHealth = maxHealth;
        width = healthBarPlayer.rectTransform.rect.width;
        fastMove = 0;

        shoot = GetComponent<Shoot>();
    }
    
    void Update()
    {
        Move();
        Gravity();
        Aim();
        AimingPoint();
        UiUpdate();
        loadGunAmmo();
    }

    void UiUpdate()
    {
        float percent = currentHealth / maxHealth;
        float currentWidth = width * percent;
        healthBarPlayer.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, currentWidth);

        gunMagazineText.text = gunMagazine.ToString();
    }
    void AimingPoint()
    {
        halfScreenWidth = Screen.width / 2;
        halfScreenHeight = Screen.height / 2;
        Vector2 screenCenter = new Vector3(halfScreenWidth, halfScreenHeight);
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, aimMask))
        {
            aimPos.position = Vector3.Lerp(aimPos.position, hit.point, aimSpeed * Time.deltaTime);
        }
    }
    void Aim()
    {
        if(Input.GetMouseButton(1))
        {
            anim.SetBool("aim", true);
        }
        else
        {
            anim.SetBool("aim", false);
        }
    }
    void loadGunAmmo()
    {
        if(Input.GetKey(KeyCode.R) && gunMagazine > 0)
        {
            //anim.SetBool("LoadGun", true);
            gunMagazine--;
            shoot.bulletCount += 5;
        }
        else
        {
            //anim.SetBool("LoadGun", false);
        }
    }
    void Move()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        anim.SetFloat("h", h);
        anim.SetFloat("v", v);
        if(Input.GetKeyDown(KeyCode.LeftShift) && fastMove < 2)
        {
            speed = 5;
            anim.speed = 1.3f;
            fastMove++;
        }
        if(fastMove > 1)
        {
            fastMove = 0;
            speed = 4;
            anim.speed = 1f;
        }
        
        if(h != 0 || v != 0)
        {
            audio.enabled = true;
        }else audio.enabled = false;
        direction = (transform.forward * v + transform.right * h).normalized;
        controller.Move(direction * speed * Time.deltaTime);
    }

    bool isGrounded()
    {
        spherePos = new Vector3(transform.position.x, transform.position.y - groundOffset, transform.position.z);
        if(Physics.CheckSphere(spherePos, controller.radius - 0.05f, groundMask))
        {
            return true;
        }
        return false;
    }
    void Gravity()
    {
        if (!isGrounded()) velocity.y += gravity * Time.deltaTime;
        else if (velocity.y < 0) velocity.y = -2;
        controller.Move(velocity * Time.deltaTime);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(spherePos, controller.radius - 0.05f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("AttackEnemy"))
        {
            TakeDamage();
        }

        if (other.CompareTag("GunMagazine"))
        {
            Destroy(other.gameObject);
            gunMagazine++;
        }
    }
    void TakeDamage()
    {
        currentHealth -= 1;
        if(currentHealth <= 0.00f)
        {
            Die();
        }
    }
    void Die()
    {
        SceneManager.LoadScene(1);
    }
}
