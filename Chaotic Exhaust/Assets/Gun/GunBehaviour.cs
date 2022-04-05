using UnityEngine;
using System.Collections;

public class GunBehaviour : MonoBehaviour
{

    int _damage = 2;
    public float _range = 200f;

    //Animator _anim;

    Transform _gunpoint;

    AudioSource _sound;

    public GameObject blast;


    private void Start()
    {
        _gunpoint = transform.Find("GunPoint");
        //_anim = GetComponent<Animator>();
        _sound = GetComponent<AudioSource>();
    }

    void Update()
    {
            PlayerState();
    }

    void PlayerState()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            //_anim.SetTrigger("shoot");
            _sound.Play();
        }
    }

    public void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(_gunpoint.transform.position, _gunpoint.transform.forward, out hit, _range))
        {
            var tar = hit.transform.GetComponent<IsShootable>() != null ? hit.transform.GetComponent<IsShootable>() : null;
            if(tar !=null)
                tar.Damage(_damage);
            var gunBlast = Instantiate(blast, hit.point, Quaternion.LookRotation(hit.normal).normalized);
            Destroy(gunBlast, .5f);
        }
    }
}
