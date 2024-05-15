using Data;

namespace Interfaces
{
    public interface IDamageable
    {
        public void TakeDamage(WeaponDamage weaponDamage);
        public void Die();
    }
}