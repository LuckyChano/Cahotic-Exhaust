using System.Collections;
using UnityEngine;

public class RayCastDamageSystem : MonoBehaviour, IsShootable
{
    public int hp;
    //public int hp = 1;
    
    private LayerManager _layerManager;
    private RoomTrigger _roomTrigger;
    private AudioSource _hitShot;
    private LifeBehaviour _hpComponent;
    private Renderer _myRenderer;

    [SerializeField]
    private Color _hurtColor = Color.red;
    private Color _normalColor;

    
    private void Awake()
    {
        _hitShot = GetComponent<AudioSource>();
        _roomTrigger = FindObjectOfType<RoomTrigger>();
        _layerManager = FindObjectOfType<LayerManager>();
        _myRenderer = GetComponent<Renderer>();

        _normalColor = _myRenderer.material.color;
    }
    void Start()
    {
        _hpComponent = new LifeBehaviour(DamageFeedback, _hitShot, hp);
    }

    public int ReturnHP()
    {
        return _hpComponent.hp;
    }

    public void Damage(int dmg)
    {
        _hpComponent.takeDamage(dmg);
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
            Die();
        }

    }

    public void Die()
    {
        if (gameObject.layer.Equals(_layerManager.enemyLayer))
        {
            _roomTrigger.OnEnemyKilled();
        }
        Destroy(gameObject);
    }
}
