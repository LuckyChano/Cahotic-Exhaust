using UnityEngine;
using System.Collections;

public class GunBehaviour : MonoBehaviour
{

    public int _damage = 2;
    public float _range = 200f;

    //Animator _anim;

    AudioSource _sound;

    public GameObject blast;


    private void Start()
    {
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
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, _range))
        {
            var tar = hit.transform.GetComponent<IsShootable>();
            if(tar !=null)
            {
                tar.Damage(_damage);
                Debug.Log(hit.transform.GetComponent<Barrel>().ReturnHP());
            }
            var gunBlast = Instantiate(blast, hit.point, Quaternion.LookRotation(hit.normal).normalized);
            Destroy(gunBlast, .5f);
        }
    }
}
