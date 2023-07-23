using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PergerakanPemain : MonoBehaviour
{
    private GameData GD;
    private ManajemenData MD;

    public Animator animator;
    public BoxCollider2D ColliderPlayer;
    public LayerMask objekBisaDiinjak;
    public GameObject kamera;

    //Pause
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;


    public AudioSource JumpSound;
    public AudioSource CoinSound;
    public AudioSource MakanSound;
    public AudioSource MasukAir;
    private int skornum;
    public Text skorText;
    public float healthAmount = 100f;
    public Image hpBar;
    // Start is called before the first frame update
    void Start()
    {
        skornum = 0;
        skorText.text = "Coins : " + skornum;
        GD = new GameData(skornum, healthAmount);
        MD = new ManajemenData();
    }

    private void OnTriggerEnter2D(Collider2D gamecute)
    {
        if (gamecute.tag == "Coin")
        {
            skornum += 10;
            Destroy(gamecute.gameObject);
            skorText.text = "Coins : " + skornum;
            CoinSound.Play();
            MD.save(GD);
        }
        if (gamecute.tag == "heal")
        {
            Heal(20);
            Destroy(gamecute.gameObject);
            MakanSound.Play();
            MD.save(GD);
        }
        if (gamecute.tag == "air")
        {
            MasukAir.Play();
        }
        if (gamecute.tag == "batas")
        {
            GameData tempGD = MD.load();
            if (tempGD != null)
            {
                GD = tempGD;
                healthAmount = GD.health;
                Vector3 loadPosisi = new Vector3();
                loadPosisi.x = GD.x;
                loadPosisi.y = GD.y;
                loadPosisi.z = GD.z;
                transform.position = loadPosisi;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        hpBar.fillAmount = healthAmount / 100f;
    }

    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        hpBar.fillAmount = healthAmount / 100f;
    }

    // Update is called once per frame
    void Update()
    {
        float kecepatan = 0;
        bool ditanah = MenginjakTanah();
        float eax = 0, eay = 0, eaz = 0;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position += new Vector3(0, 2, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            kecepatan = 0.05f;
            transform.position += new Vector3(kecepatan, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            kecepatan = 0.05f;
            eay = 180;
            transform.position -= new Vector3(kecepatan, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpSound.Play();
            TakeDamage(10);
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (healthAmount <= 0f)
        {
            animator.gameObject.SetActive(false);
            SceneManager.LoadScene("GameOver");
        }

        Vector3 posisiKamera = new Vector3();
        posisiKamera.z = kamera.transform.position.z;
        posisiKamera.y = kamera.transform.position.y;
        posisiKamera.x = transform.position.x;
        kamera.transform.position = posisiKamera;

        animator.SetFloat("Kecepatan", kecepatan);
        animator.SetBool("Ditanah", ditanah);
        transform.eulerAngles = new Vector3(eax, eay, eaz);

        //======== simpan xyz
        GD.x = transform.position.x;
        GD.y = transform.position.y;
        GD.z = transform.position.z;
        if (Input.GetKey(KeyCode.S))
        {
            MD.save(GD);
        }
        if (Input.GetKey(KeyCode.L))
        {
            GameData tempGD = MD.load();
            if (tempGD != null)
            {
                GD = tempGD;
                healthAmount = GD.health;
                Vector3 loadPosisi = new Vector3();
                loadPosisi.x = GD.x;
                loadPosisi.y = GD.y;
                loadPosisi.z = GD.z;
                transform.position = loadPosisi;
            }
        }
    }


    private bool MenginjakTanah()
    {
        return Physics2D.BoxCast(
            ColliderPlayer.bounds.center,
            ColliderPlayer.bounds.size,
            0f,
            Vector2.down,
            0.1f,
            objekBisaDiinjak
        );
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
