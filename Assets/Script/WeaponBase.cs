
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{//базовый класс для оружия
    public int damage = 0;
    public IDoDamage damageType;

    public void TryAttack()
    {
        damageType?.DoDomage(damage);
    }
    public void SetDamageType(IDoDamage damageType)
    {
        this.damageType = damageType;
    }
}

