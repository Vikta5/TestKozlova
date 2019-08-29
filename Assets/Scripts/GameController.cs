using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] List<Material> playerColor = new List<Material>();
    [SerializeField] Slider loadSlider;
    float timer = 3f;

    public static GameController Instance
    {
        get
        {
            return Instance;
        }
    }

    public static GameController instance = null;

    private void Awake()
    {
        if (instance)
        {
            DestroyImmediate(gameObject);
            return;
        }

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Restart();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer > 0)
        {
            loadSlider.value = timer;
        }
    }

    public void Restart()
    {
        timer = 3;
        loadSlider.gameObject.SetActive(true);
        StartCoroutine(Load(timer));
    }

    IEnumerator Load(float timer)
    {
        yield return new WaitForSecondsRealtime(timer);
        loadSlider.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        GameObject player = Instantiate(playerPrefab, new Vector3(0, 0, -1f), Quaternion.Euler(0, 0, Random.Range(0, 360))) as GameObject;
        player.GetComponent<MeshRenderer>().material = playerColor[Random.Range(0, playerColor.Count)];
    }
}