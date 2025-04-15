using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("基本數值")]
    [SerializeField,Range(0,10)]
    private float moveSpeed = 3.5f;
    [SerializeField,Range(0,15)]
    private float jompForce = 10;
    [SerializeField,Range(0,20)]
    private float dashSpeed = 12;


    private Animator ani;
    private Rigidbody2D rig;

    private void Awake()
    {
        ani = GetComponent<Animator>(); // 取得角色動畫元件
        rig = GetComponent<Rigidbody2D>();// 取得角色鋼體(重力)元件
    }
}
