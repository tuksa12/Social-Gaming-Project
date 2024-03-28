using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;


public class Player : MonoBehaviour
{
    
    [SerializeField] private int xp = 0;
    [SerializeField] private int wood = 0;
    [SerializeField] private int requiredXp = 100;
    [SerializeField] private int levelBase = 100;
    [SerializeField] private int health = 100;
    [SerializeField] private List<GameObject> cars = new List<GameObject>();
    [SerializeField] private int speed = 1;

    private int level = 1;

    public int Xp() {
        return xp;
    }

    public int RequiredXp {
        get {return requiredXp;}
    }

    public int Health{
            get {return health;}
    }

    public int LevelBase{
        get {return levelBase;}
    }

    public List<GameObject> Cars{
        get{return cars;}
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    public void addXp(int xp){
        this.xp += Mathf.Max(0,xp);
    }

    public void addWood(int wood)
    {
        this.wood += wood;
        //StartCoroutine(Main.Instance.Web.GetItem(UserInfo.UserID, 6))
    }
    
}
