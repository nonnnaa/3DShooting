using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public Transform firePos;    

    public float bulletSpeed = 20f;
    public Text bulletCountText;

    Transform aimTarget;

    public AudioSource shoot;
    public GameObject effectShoot;
    int Gunammo;
    public int bulletCount;
    public int gunMagazine;
    private void Start()
    {
        aimTarget = GameObject.FindGameObjectWithTag("AimPos").GetComponent<Transform>();
        Gunammo = 0;
    }
    private void Update()
    {
        if(Input.GetMouseButton(1))
        {
            if (Input.GetMouseButtonDown(0) && bulletCount > 0)
            {
                bulletCount--;
                ShootBullet();
                shoot.Play();
                effectShoot.gameObject.SetActive(false);
                effectShoot.gameObject.SetActive(true);
            }
        }
       
    }


    private void ShootBullet()
    {
        var newBullet = Instantiate(bulletPrefab, firePos.position, firePos.rotation);

        var bulletRb = newBullet.GetComponent<Rigidbody>();
        
        var direction = (aimTarget.position - firePos.position).normalized;
    
        bulletRb.velocity = direction * bulletSpeed;
        
    }
}
