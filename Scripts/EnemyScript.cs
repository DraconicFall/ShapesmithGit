using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class EnemyScript : MonoBehaviour
{
    public AudioClip damageTakenFX;
    public float health = 2f;
    public float maxHealth;
    public bool healthRampsUpFromZero = true;

    public GameObject deathEffect;

    public bool isInvincible = false;
    public float shieldFromAttacks; //DONT EDIT IN INSPECTOR
    public bool usesAnimator = true;

    public Slider healthBar;
    public Slider healthBarShrink;
    public float barShrinkDividedBy = 1;
    public float timeTillShrink = 1f;
    public float timer;
    bool isShrinking = false;
    //public bool isBoss = false;
    public bool tutorial = false;

    bool bossHBar = false;

    public string bossName;
    public TextMeshProUGUI bossHealthNameText;

    bool hasStartedDeath = false;

    [Header("Other")]
    public SpriteRenderer spriteRenderer;
    Material material;
    int numOfDFlashesActive = 0;

    GameObject gameManager;
    //GameManagerScript gameManagerScript;
    //public bool countForEnemyCounter = false;
    //public bool haveECounterDR = false;
    //float damageResistance = 1;

    private void Awake()
    {
        if (usesAnimator == true)
        {
            Animator animator = gameObject.GetComponent<Animator>();
            //animator.Play(stunnedAnimation);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //if (countForEnemyCounter == true)
        //{
        //    GameManagerScript.enemyCounter = GameManagerScript.enemyCounter + 1;
        //}
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        material = spriteRenderer.material;
        //maxHealth = health;
        //gameManager = GameObject.Find("GameManager");
        //gameManagerScript = gameManager.GetComponent<GameManagerScript>();
        //if (isBoss == true)
        //{
        //    BossHealthBar bHB = gameManager.GetComponent<BossHealthBar>();
        //    bHB.enableBossBar();
        //    StartCoroutine(HealthBarCrap());
        //}
        //healthBar.enabled = false;
        //healthBarShrink.enabled = false;
    }

    //IEnumerator HealthBarCrap()
    //{
    //    yield return new WaitForSeconds(0.1f);
    //    bossHBar = false;
    //    if (isBoss == true)
    //    {
    //        GameObject bosshealthh = GameObject.Find("BossBar");
    //        GameObject bosshealthhShirnkk = GameObject.Find("BossHealthBarShrink");
    //        healthBar = bosshealthh.GetComponent<Slider>();
    //        healthBarShrink = bosshealthhShirnkk.GetComponent<Slider>();

    //        GameObject bossHealthNameee = GameObject.Find("BossTitle");
    //        bossHealthNameText = bossHealthNameee.GetComponent<TextMeshProUGUI>();
    //        bossHealthNameText.text = bossName;

    //        timer = timeTillShrink;
    //        healthBar.maxValue = maxHealth;
    //        healthBarShrink.maxValue = maxHealth;

    //        if (healthRampsUpFromZero == true)
    //        {
    //            healthBarShrink.value = 0;
    //            healthBar.value = 0;

    //            for (int i = 0; i < 40; i++)
    //            {
    //                healthBarShrink.value = i * (maxHealth / 40);
    //                healthBar.value = i * (maxHealth / 40);
    //                yield return new WaitForSeconds(0.01f);
    //            }
    //        }

    //        //health = maxHealth;
    //        //healthBarShrink.value = maxHealth;
    //        //healthBar.value = maxHealth;
    //        bossHBar = true;
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        //if (GameManagerScript.enemyCounter >= 0 && GameManagerScript.enemyCounter < 10 && haveECounterDR == true)
        //{
        //    damageResistance = 1 - 0.1f * GameManagerScript.enemyCounter;
        //}
        //else if (GameManagerScript.enemyCounter >= 10 && haveECounterDR == true)
        //{
        //    damageResistance = 0;
        //}
        //if (stunnedList.Count > 0)
        //{
        //    isStunned = true;
        //}
        //else
        //{
        //    isStunned = false;
        //}
        //if (ehwazDaggerStacks >= 2)
        //{
        //    ehwazDaggerStacks = 0;
        //    startEffect(ehwazBleedFromDagger);
        //    Instantiate(effectEhwazDagger, new Vector2(transform.position.x, transform.position.y - .5f), Quaternion.identity); ;
        //    LoseHealth(6f * GameManagerScript.playerDamageMultiplier);
        //}
        //if (isBoss == true && BossHealthBar.ifBossHealthBarActive == true && bossHBar == true)
        //{

        //    healthBar.value = health;

        //    if (healthBarShrink.value > health)
        //    {
        //        timer = timer - Time.deltaTime;
        //        if (timer <= 0)
        //        {
        //            if (isShrinking == false)
        //            {
        //                StartCoroutine(Shrink());
        //            }
        //        }
        //    }
        //    else if (healthBarShrink.value <= health)
        //    {
        //        timer = timeTillShrink;
        //        healthBarShrink.value = healthBar.value;
        //    }
        //}

        if (health <= 0 && hasStartedDeath == false)
        {
            hasStartedDeath = true;
            GameObject DEAD = Instantiate(deathEffect, transform.position, Quaternion.identity);
            //if (isBoss == true)
            //{
            //    GameObject gameManager = GameObject.Find("GameManager");
            //    BossHealthBar bHB = gameManager.GetComponent<BossHealthBar>();
            //    bHB.disableBossBar();
            //}
            StartCoroutine(Death());
        }

    }
    public void LoseHealth (float amountOfDamage)
    {
        float damageTaken = amountOfDamage;
        if (isInvincible == false || damageTaken > 0)
        {
            //SoundFXManager.instance.PlaySoundFXClip(damageTakenFX, transform, 0.45f, 0.98f, 1.02f, true);
                
            //if (numOfDFlashesActive < 10 && amountOfDamage > 0)
            //{
            //    StartCoroutine(damageFlash());
            //    numOfDFlashesActive++;
            //}
            //if (isBoss == true && damageTaken > 0)
            //{
            //    GameObject healOrb = Instantiate(gameManagerScript.healOrb, transform.position, Quaternion.identity);
            //    healOrb.SetActive(false);
            //    PickUpItemScript pickUpItemScript = healOrb.GetComponent<PickUpItemScript>();
            //    pickUpItemScript.amount = damageTaken / 2.5f;
            //    if (tutorial == true)
            //    {
            //        pickUpItemScript.amount = damageTaken * 200f;
            //    }
            //    healOrb.SetActive(true);
            //}
            //else if (isBoss == false)
            //{
            //    pickUpItemScript.amount = amountOfDamage / 5f;
            //}
            
            if (shieldFromAttacks > 0)
            {
                shieldFromAttacks = shieldFromAttacks - (damageTaken);
            }
            else
            {
                timer = timeTillShrink;
                health = health - (damageTaken);
                StartCoroutine(damageFlash());
            }
        }
    }

    IEnumerator damageFlash()
    {
        spriteRenderer.color = Color.white;
        float newColorValue = (health / maxHealth) * 200;
        newColorValue = (newColorValue + 55) / 255;
        for (int i = 0; i < 8; i++)
        {
            yield return new WaitForSeconds(0.005f);
            spriteRenderer.color = Vector4.Lerp(spriteRenderer.color, new Color(newColorValue, newColorValue, newColorValue, 1), 0.2f);
        }
        spriteRenderer.color = new Color(newColorValue, newColorValue, newColorValue, 1);
    }

    //public void startEffect(EffectCreate effect)
    //{
    //    StartCoroutine(ApplyEffect(effect));
    //}

    //IEnumerator WaitSequenceDmg(float amountOfDamage, float waitTime, float sequenceAmount)
    //{
    //    for (int i = 0; i < sequenceAmount; i++)
    //    {
    //        yield return new WaitForSeconds(waitTime);
    //        LoseHealth(amountOfDamage * GameManagerScript.playerDamageMultiplier);
    //    }
    //}
    IEnumerator Shrink()
    {
        isShrinking = true;
        yield return new WaitForSeconds(0f);
        float AddOfHealthBars;
        float Shrinkamount;
        AddOfHealthBars = (healthBarShrink.value - healthBar.value);
        Shrinkamount = AddOfHealthBars / barShrinkDividedBy;
        for (int i = 0; i <= barShrinkDividedBy; i++)
        {
            yield return new WaitForSeconds(0.01f);
            healthBarShrink.value = healthBarShrink.value - Shrinkamount;
        }
        isShrinking = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    }

    IEnumerator Death()
    {
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }
        yield return new WaitForSeconds(0f);
        //if (hasADeathAttack == true)
        //{
        //    Collider2D collider = GetComponent<Collider2D>();
        //    collider.enabled = false;

        //    spriteRenderer.enabled = false;

        //    AtkWayDeath atkWayDeath = GetComponent<AtkWayDeath>();
        //    atkWayDeath.attackReaction();
        //    while (atkWayDeath.numOfAttacksFinished < atkWayDeath.eAttack.Length)
        //    {
        //        yield return new WaitForSeconds(0);
        //    }
        //}
        //if (countForEnemyCounter == true)
        //{
        //    GameManagerScript.enemyCounter = GameManagerScript.enemyCounter - 1;
        //}
        Destroy(gameObject);
    }
}
