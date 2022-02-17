public class Weapon
{
    private readonly int _damage;
    private readonly int _bulletsPerShoot;
    private int _bullets;

    public Weapon(int damage, int bullets, int bulletsPerShoot)
    {
        if (damage < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(damage));
        }

        if (bullets < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(bullets));
        }

        if (bulletsPerShoot < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(bulletsPerShoot));
        }

        _damage = damage;
        _bulletsPerShoot = bulletsPerShoot;
        _bullets = bullets;
    }

    public bool TryFire(Player player)
    {
        if (player == null)
        {
            throw new ArgumentNullException(nameof(player));
        }

        if (_bullets >= _bulletsPerShoot)
        {
            Fire(Player player);
            return true;
        }

        return false;
    }

    private void Fire(Player player)
    {
        player.TakeDamage(_damage);
        _bullets -= _bulletsPerShoot;
    }
}

public class Player
{
    private int _health;

    public Player(int health)
    {
        if (health <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(health));
        }

        _health = health;
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(damage));
        }

        if (_health - damage > 0)
        {
            _health -= damage;
        }
        else
        {
            _health = 0;
        }
    }
}

public class Bot
{
    private readonly Weapon _weapon;

    public Bot(Weapon weapon)
    {
        if (_weapon == null)
        {
            throw new ArgumentNullException(nameof(_weapon));
        }

        _weapon = weapon;
    }

    public void OnSeePlayer(Player player)
    {
        _weapon.TryFire(player);
    }
}
