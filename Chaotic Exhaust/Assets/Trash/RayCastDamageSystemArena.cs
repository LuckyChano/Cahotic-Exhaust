using System.Collections;
using UnityEngine;

public class RayCastDamageSystemArena : MonoBehaviour, IShootable
{
    public int hp;
    //public int hp = 1;
    
    private RoomTrigger _roomTrigger;
    private AudioSource _hitShot;
    private LifeBehaviour _hpComponent;
    private Renderer _myRenderer;
    private EnemyManager _manager;
    private int count = 1;


    [SerializeField]
    private Color _hurtColor = Color.red;
    private Color _normalColor;

    
    private void Awake()
    {
        _hitShot = GetComponent<AudioSource>();
        _roomTrigger = FindObjectOfType<RoomTrigger>();
        _myRenderer = GetComponent<Renderer>();
        _manager = FindObjectOfType<EnemyManager>();
        _normalColor = _myRenderer.material.color;
    }
    void Start()
    {
        _hpComponent = new LifeBehaviour(DamageFeedback, _hitShot, hp);
    }

    public float ReturnHP()
    {
        return _hpComponent.hp;
    }

    public void ShootDamage(float dmg)
    {
        _hpComponent.takeDamage(dmg);
        DamageFeedback();
    }

    public void DamageFeedback()
    {
        StartCoroutine(DamagedFeedback());
    }

    public IEnumerator DamagedFeedback()
    {

        _myRenderer.material.color = _hurtColor;

        yield return new WaitForSeconds(.5f);

        _myRenderer.material.color = _normalColor;

        if (_hpComponent.hp <= 0)
        {
            Destroy(gameObject);
            _manager.IncreaseAmount(count);
        }

    }
}
