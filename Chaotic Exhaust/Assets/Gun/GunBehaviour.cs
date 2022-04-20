using UnityEngine;
using System.Collections;

public class GunBehaviour : MonoBehaviour
{

    public int _damage = 2;
    public float _range = 200f;
    public int maxAmmo;
    public int bulletAmout;
    public float shootSpeed = 5f;
    float shootTimer = 0;
    //Animator _anim;

    AudioSource _sound;

    public GameObject blast;


    private void Start()
    {
        //_anim = GetComponent<Animator>();
        bulletAmout = maxAmmo;
        _sound = GetComponent<AudioSource>();
    }

    void Update()
    {
            PlayerState();
    }

    void PlayerState()
    {
        
        if(Input.GetButton("Fire1"))
        {
            if(Time.time - shootTimer > 1/shootSpeed && bulletAmout > 0)
            {
                shootTimer = Time.time;
                Shoot();
                _sound.Play();
            }
            if(bulletAmout <= 0)
            {
                //Animacion sin balas;
            }
            //_anim.SetTrigger("shoot");
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            bulletAmout = maxAmmo;
        }
    }

    public void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, _range))
        {
            var tar = hit.transform.GetComponent<IsShootable>();
            if(tar !=null)
            {
                tar.Damage(_damage);
            }
            var gunBlast = Instantiate(blast, hit.point, Quaternion.LookRotation(hit.normal).normalized);
            Destroy(gunBlast, .5f);
        }
            bulletAmout--;
    }
}
