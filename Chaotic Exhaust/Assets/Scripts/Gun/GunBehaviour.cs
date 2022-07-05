using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;


public enum GunStates
{ 
    SHOOT,
    RELOAD
}
public class GunBehaviour : MonoBehaviour
{

    public float damage = 1;
    public float range = 200f;
    public int maxAmmo;
    public int bulletAmout = 20;
    public float shootSpeed = 5f;
    //Animator _anim;

    AudioSource _sound;

    public GameObject EnemyBlast;
    public GameObject WallBlast;
    public ParticleSystem MuzzleParticle;
    public TextMeshProUGUI ammoCounter;

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
            ammoCounter.text = bulletAmout.ToString();
    }

    void PlayerState()
    {
        _fsm.Update();
    }

    public void Shoot()
    {
        RaycastHit hit;
        MuzzleParticle.Play();
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range))
        {
            var tar = hit.transform.GetComponent<IShootable>();
            if(tar !=null)
            {
                tar.ShootDamage(damage);
                var gunBlast = Instantiate(EnemyBlast, hit.point, Quaternion.LookRotation(hit.normal).normalized);
                Destroy(gunBlast, .5f);
            }
            else
            {
                var gunBlast = Instantiate(WallBlast, hit.point, Quaternion.LookRotation(hit.normal).normalized);
                Destroy(gunBlast, .5f);
            }
        }
        bulletAmout--;
    }
}
