using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	// Prefabs
	public GameObject playerObjectPrefab;
	public GameObject bulletObjectPrefab;
	public GameObject rocketObjectPrefab;
	public GameObject PowerUpObjectPrefab;

	// Game Objects
	public PlayerShip playerShip;
	public List<IPowerUp> powerUps = new List<IPowerUp>();
	public List<IProjectile> projectiles = new List<IProjectile>();

	// Singleton
	public static GameManager instance { get; private set;}
	
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

	// Setup game
    private void Start()
    {
		// Setup Projectiles Prototypes
		IProjectile bullet = new Projectile(Instantiate(bulletObjectPrefab), Vector3.zero, Vector3.zero, 1.0f,
			MovementOverTime.CONSTANT, TargetFinding.NONE, false);
		IProjectile rocket = new Projectile(Instantiate(rocketObjectPrefab), Vector3.zero, Vector3.zero, 1.0f,
			MovementOverTime.ACCELERATED, TargetFinding.CLOSEST, false);
    
		// Setup Attacker and Weapons
        Attacker attacker = new Attacker(1);
        
        attacker.AddWeapon(new Weapon(new WeaponStats(1.0f, 2.0f, 1), ShooterLaunch.STRAIGHT, bullet));
        attacker.AddWeapon(new Weapon(new WeaponStats(2.0f, 0.5f, 1), ShooterLaunch.CIRCLE, rocket));
        
        // Setup PowerUp Prototypes
        List<IPowerUp> PowerUpPrototypes = new List<IPowerUp>()
        {
			new PowerUp(Instantiate(PowerUpObjectPrefab), new AttackMultiplierDecorator(0.5f),
				ShooterLaunch.STRAIGHT, MovementOverTime.CONSTANT, TargetFinding.NONE),
			new PowerUp(Instantiate(PowerUpObjectPrefab), new AttackSpeedDecorator(1.0f),
				ShooterLaunch.STRAIGHT, MovementOverTime.CONSTANT, TargetFinding.NONE),
			new PowerUp(Instantiate(PowerUpObjectPrefab), new ProjectileAmountDecorator(1),
				ShooterLaunch.STRAIGHT, MovementOverTime.CONSTANT, TargetFinding.NONE),
				
			new PowerUp(Instantiate(PowerUpObjectPrefab), new AttackMultiplierDecorator(1.0f),
				ShooterLaunch.CIRCLE, MovementOverTime.ACCELERATED, TargetFinding.CLOSEST),
			new PowerUp(Instantiate(PowerUpObjectPrefab), new AttackSpeedDecorator(0.5f),
				ShooterLaunch.CIRCLE, MovementOverTime.ACCELERATED, TargetFinding.CLOSEST),
			new PowerUp(Instantiate(PowerUpObjectPrefab), new ProjectileAmountDecorator(1),
				ShooterLaunch.CIRCLE, MovementOverTime.ACCELERATED, TargetFinding.CLOSEST)
        };
		
        // Setup Player InputHandler
        InputHandler inputHandler = new InputHandler();
        inputHandler.BindKey(KeyCode.Space, new AttackCommand(KeyAction.HELD, attacker));
        inputHandler.BindKey(KeyCode.S, new SpawnRandomPowerUpCommand(KeyAction.PRESSED, PowerUpPrototypes));
        inputHandler.BindKey(KeyCode.A, new ActivateRandomPowerUpCommand(KeyAction.PRESSED));
    
		// Setup Player
		playerShip = new PlayerShip(Instantiate(playerObjectPrefab), attacker, inputHandler);
    }

	// Update Game Objects
    private void Update()
    {
        playerShip.Update(Time.deltaTime);
        
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
        
        for (int i = 0; i < powerUps.Count; i++)
        {
			IPowerUp powerUp = powerUps[i];
			
            if (powerUp.AttachedGameObject == null)
            {
                powerUps.Remove(powerUp);
                i--;
                continue;
            }
        }
    }

    private void FixedUpdate()
    {
    
	}
}
