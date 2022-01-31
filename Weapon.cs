public class Weapon
{
    private int _damage;
    private int _bullets;
    private int _bulletsPerShoot;

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
        _bullets = bullets;
        _bulletsPerShoot = bulletsPerShoot;
    }

    public void TryFire(Player player)
    {
        if (player == null)
        {
            throw new ArgumentNullException(nameof(player));
        }

        if (_bullets >= _bulletsPerShoot)
        {
            Fire(Player player);
        }
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
    private Weapon _weapon;

    public Bot(Weapon weapon)
    {
        _weapon = weapon;
    }

    public void OnSeePlayer(Player player)
    {
        if (_weapon == null)
        {
            throw new ArgumentNullException(nameof(_weapon));
        }

        _weapon.TryFire(player);
    }
}
