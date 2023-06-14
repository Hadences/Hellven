
using Unity.VisualScripting;
using UnityEngine;
using TMPro;


public class GameLogic : MonoBehaviour
{
    private bool gameActive = false;
    private bool gameOver = false;
    
    public enum WorldType
    {
        Overworld,
        Nether
    }
    
    [Header("Player Data")]
    public float score = 0;
    public int highScore = 0;
    
    [Header("Game Data")]
    [SerializeField] private WorldType world = WorldType.Overworld; // default world type is overworld

    [SerializeField] private float spawn_interval = 2.0f;
    [SerializeField] private float spawn_monster_interval = 2.0f;
    [SerializeField] private float obstacle_speed = 1.0f; //how fast the obstacles should move
    private ObstacleSpawnManager obstacleSpawnManager;
    private float t = 0;
    private float t_spawn = 0;
    private float t_monster = 0;

    [Header("Game Objects")] 
    [SerializeField] private GameObject overworld_obstacle;
    [SerializeField] private GameObject nether_obstacle;
    [SerializeField] private GameObject destroy_point;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private TMP_Text score_ui;
    
    [SerializeField] private GameObject gameover_ui;
    [SerializeField] private GameObject healthbar_ui;
    [SerializeField] private GameObject start_ui;
    [SerializeField] private GameObject game_ui;


    [Header("Enemies")] [SerializeField] private GameObject enemy_ranged;

    public Vector3 getDestroyPoint()
    {
        return destroy_point.transform.position;
    }
    private void Start()
    {
        pauseGame();
        obstacleSpawnManager = gameObject.GetComponent<ObstacleSpawnManager>();
        t_spawn = spawn_interval;
        
    }

    public void startGame()
    {
        if (gameActive || gameOver) return;
        unpauseGame();
        gameover_ui.SetActive(false);
        healthbar_ui.SetActive(true);
        start_ui.SetActive(false);
        game_ui.SetActive(true);
    }

    public void pauseGame()
    {
        Time.timeScale = 0;
    }

    public void unpauseGame()
    {
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        //game over logic
        gameOver = true;
        pauseGame();
        uiManager.showGameOverScreen();
    }

    private void Update()
    {
        score += Time.deltaTime;
        score_ui.text = score.ToString("F2");

        t_monster += Time.deltaTime;
        t += Time.deltaTime;
        if (t >= t_spawn)
        {
            obstacleSpawnManager.spawnObstacles();
            t = 0;
            //t_spawn = spawn_interval;
        }

        if (t_monster >= spawn_monster_interval)
        {
            //t_monster = 0;
            obstacleSpawnManager.spawnMonsters();
            spawn_monster_interval += spawn_interval*2;
        }
    }

    public void spawnMonster(Vector3 position)
    {
        Enemy entity = Instantiate(enemy_ranged, position, Quaternion.identity).GetComponent<Enemy>();
        entity.destroy_point = getDestroyPoint();
    }

    public void spawnObstacle(Vector3 position)
    {
        if (world == WorldType.Overworld)
        {
            ObstacleScript obstacle = Instantiate(overworld_obstacle, position, Quaternion.identity)
                .GetComponent<ObstacleScript>();
            obstacle.speed = obstacle_speed;
            obstacle.destroy_point = getDestroyPoint();
        }else if (world == WorldType.Nether)
        {
            ObstacleScript obstacle = Instantiate(nether_obstacle, position, Quaternion.identity)
                .GetComponent<ObstacleScript>();
            obstacle.speed = obstacle_speed;   
            obstacle.destroy_point = getDestroyPoint();
        }
    }
}
