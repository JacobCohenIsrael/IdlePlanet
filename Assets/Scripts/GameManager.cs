using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private GameObject menu;
    
    [SerializeField]
    private GameObject organismMenu;

    [SerializeField]
    private GameObject organismPanel;

    [SerializeField]
    private ParticleSystem particles;

    public static long Dna = 1;

    public static long OrganismsAmount = 0;
    
    // Start is called before the first frame update
    protected void Start()
    {
        Debug.Log("Starting Game");
        Init();
    }

    private void Init()
    {
        Debug.Log("Initializing");
        Instantiate(menu, canvas.transform);
        Instantiate(organismMenu, canvas.transform);
    }

    protected void Update()
    {
        var emission = particles.emission;
        emission.rateOverTime = OrganismsAmount;
    }
}
