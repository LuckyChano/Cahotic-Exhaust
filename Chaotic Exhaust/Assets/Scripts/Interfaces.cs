using UnityEngine;
using System.Collections; 

public interface IWalkable
{
    void Move();

    void Jump();
}

//Lista
public interface IShootable
{
    void ShootDamage(float damage);
}
//Lista
public interface IDamageable
{
    void Damage(float damage);
}

public interface IPickable
{
    GameObject ReturnObject();
}
public interface IItem
{
    void FirstInteracted(GameObject gadget);
    void Do(params object[] args);
    GameObject ReturnItem();
}

public interface IAffectGas
{
    void EnterGas(float dmg);
}

public interface IIluminatte
{
    IEnumerator SetOnLight(float time);
}


