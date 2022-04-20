using UnityEngine;
using System.Collections;


public enum GunStates
{ 
    SHOOT,
    RELOAD
}


public class GunBehaviour : MonoBehaviour
{

    public int _damage = 2;
    public float _range = 200f;
    public int maxAmmo;
    public int bulletAmout = 20;
    public float shootSpeed = 5f;
    //Animator _anim;

    AudioSource _sound;

    public GameObject blast;

    Machine _fsm;
    ShootingState _shootState;
    ReloadState _reloadStatel;

    private void Start()
    {
        //_anim = GetComponent<Animator>();
        _fsm = new Machine();
        bulletAmout = maxAmmo;
        _sound = GetComponent<AudioSource>();
        _shootState = new ShootingState(this, _fsm, Shoot, shootSpeed, _sound);
        _reloadStatel = new ReloadState(this, _fsm, null);
        _fsm.AddState(GunStates.SHOOT, _shootState);
        _fsm.AddState(GunStates.RELOAD, _reloadStatel);
        _fsm.ChangeState(GunStates.SHOOT);
    }

    void Update()
    {
            PlayerState();
    }

    void PlayerState()
    {
        _fsm.Update();
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
