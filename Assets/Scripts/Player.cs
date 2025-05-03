using UnityEngine;

namespace lotta
{
    public class Player : MonoBehaviour
    {
        #region 基本變數
        [Header("基本數值")]
        [field: SerializeField, Range(0, 10)]
        public float moveSpeed { get; private set; }  = 5.0f;

        [field : SerializeField, Range(0, 15)]
        public float jumpForce { get; private set; } = 10;

        [SerializeField, Range(0, 20)]
        private float dashSpeed = 12;

        [Header("跳躍")]
        [SerializeField]
        private Vector3 CheckGroundSize = Vector3.one;
        [SerializeField]
        private Vector3 CheckGroundOffset;
        [SerializeField]
        private LayerMask layerCanJump;


        public Animator ani {  get; private set; }          //動畫控制元件
        public Rigidbody2D rig {  get; private set; }       //2D 剛體元件
        #endregion

        //{  get; private set; } 唯獨屬性，只能取得不能設定
        public StateMachine stateMachine { get; private set; }
        public PlayerIdle playerIdle {  get; private set; }
        public PlayerWalk PlayerWalk {  get; private set; }
        public PlayerJump PlayerJump { get; private set; }

        // ODG繪製圖示事件
        private void OnDrawGizmos()
        {
            // 決定圖示顏色
            // color (紅 , 綠 , 藍 , 透明度) 值 0 ~ 1
            Gizmos.color = new Color(1, 0.2f, 0.2f, 0.7f);
            // 繪製圖示
            // 繪製立方體(座標, 尺寸)   (座標 :transform.position + CheckGroundOffset 此物件加上位移  , 尺寸)
            Gizmos.DrawCube(transform.position + CheckGroundOffset,CheckGroundSize);
        }

        private void Awake()
        {
            ani = GetComponent<Animator>(); // 取得角色動畫元件
            rig = GetComponent<Rigidbody2D>();// 取得角色鋼體(重力)元件
                

            stateMachine = new StateMachine();
            playerIdle = new PlayerIdle(this, stateMachine, "玩家待機");
            PlayerWalk = new PlayerWalk(this, stateMachine, "玩家走路");
            PlayerJump = new PlayerJump(this, stateMachine, "玩家跳躍");

            stateMachine.Initialize(playerIdle);

        }

        private void Update()
        {
            stateMachine.Update();

            //IsGround();
        }


        /// <summary>
        /// 翻面功能
        /// </summary>
        /// <param name="h">水平值</param>
        public void Flip(float h)
        {
            if (Mathf.Abs(h) < 0.1) return;
            // 三源運算子:  如果h 大於0 角度指定為 0 否則為 180
            float angle = h > 0 ? 0 : 180;

            // 更新玩家的歐拉角度 = 新的三圍向量(x,y,z)
            transform.eulerAngles = new Vector3(0, angle, 0);
        }


        public bool IsGround()
        {
            // 檢查地板區域是否碰到指定圖層的物件
            // 碰撞器 = 物理2D.方形覆蓋(座標 , 尺寸 , 角度 , 圖層)
            Collider2D hit = Physics2D.OverlapBox(transform.position + CheckGroundOffset, CheckGroundSize, 0, layerCanJump);

            //Log.Text(hit, "yellow");

            // 如果有碰到物件就傳回 true
            return hit != null;
        }

    }
}

