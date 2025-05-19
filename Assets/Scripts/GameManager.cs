using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance { get; private set;}

	public GameObject playerObjectPrefab;
	public GameObject projectileObjectPrefab;
	public GameObject PowerUpObjectPrefab;

	public PlayerShip playerShip;
	public List<IPowerUp> powerUps = new List<IPowerUp>();
	public List<IProjectile> projectiles = new List<IProjectile>();

	private void Awake()
	{
		if (instance == null)
			instance = this;
		else 
		{
			Debug.LogError($"A GameManager already exists, deleting self: {name}");
			Destroy(gameObject);
		}
	}

    private void Start()
    {
		// Setup Projectiles
		IProjectile bullet = new Projectile(Instantiate(projectileObjectPrefab), Vector3.zero, Vector3.zero, 1.0f, new ConstantMovement(), null, false);
		IProjectile rocket = new Projectile(Instantiate(projectileObjectPrefab), Vector3.zero, Vector3.zero, 1.0f, new AcceleratedMovement(), new ClosestTarget(), false);
    
		// Setup Weapons and Attacker
		List<IWeapon> weapons = new List<IWeapon>
        {
            new Weapon(new WeaponStats(1.0f, 2.0f, 1), new StraightShooter(), bullet),
            new Weapon(new WeaponStats(2.0f, 0.5f, 1), new CircleShooter(), rocket)
        };
        
        Attacker attacker = new Attacker(1, weapons);
        
        // Setup Player InputHandler
        InputHandler inputHandler = new InputHandler();
        inputHandler.BindKey(KeyCode.Space, new AttackCommand(attacker));
    
		playerShip = new PlayerShip(Instantiate(playerObjectPrefab), attacker, inputHandler);
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        playerShip.FixedUpdate();
        
        for (int i = 0; i < projectiles.Count; i++)
        {
			IProjectile projectile = projectiles[i];
			
            if (projectile.AttachedGameObject == null) 
            {
                projectiles.Remove(projectile);
                i--;
                continue;
            }
            
            projectile.Move(Time.deltaTime);
        }
    }
}
