using System.Collections;
using UnityEngine;

public class Barrel : MonoBehaviour, IsShootable
{
    private LayerManager _layerManager;
    private RoomTrigger _roomTrigger;
    AudioSource hitShot;
    //public int hp = 1;
    LifeBehaviour hpComponent;
    public int hp;
    public void Damage(int dmg)
    {
        hpComponent.takeDamage(dmg);
    }

    public void DamageFeedback()
    {
        StartCoroutine(DamagedFeedback());
    }

    public IEnumerator DamagedFeedback()
    {

        GetComponentInChildren<Renderer>().material.color = Color.red;

        yield return new WaitForSeconds(.5f);

        GetComponentInChildren<Renderer>().material.color = Color.white;
        if (hpComponent.hp <= 0)
        {
            if (gameObject.layer.Equals(_layerManager.enemyLayer))
            {
                _roomTrigger.OnEnemyKilled();
            }
            Destroy(gameObject);
        }

    }
    private void Awake()
    {
        hitShot = GetComponent<AudioSource>();
        _roomTrigger = FindObjectOfType<RoomTrigger>();
        _layerManager = FindObjectOfType<LayerManager>();
    }
    void Start()
    {
        hpComponent = new LifeBehaviour(DamageFeedback, hitShot, hp);
    }

    public int ReturnHP()
    {
        return hpComponent.hp;
    }
}
