using Unity.Mathematics;
using UnityEngine;
namespace lotta
{
    /// <summary>
    /// 玩家走路
    /// </summary>
    public class PlayerWalk : PlayerGround
    {
        public PlayerWalk(Player _player, StateMachine _machine, string _name) : base(_player, _machine, _name)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();

            float h = Input.GetAxis("Horizontal");
            // 控制玩家剛體 線性加速度 = 新的二維向量( h * 玩家移動速度 , 0)
            player.rig.linearVelocity = new Vector2 (h * player.moveSpeed, 0);

            // 更新玩家動畫的浮點數數值 (參數名稱 ,數值)
            player.ani.SetFloat("移動",Mathf.Abs(player.rig.linearVelocityX) / player.moveSpeed);

            // 玩家翻面
            player.Flip(h);

            // 如果 h 等於0 就切換到待機狀態
            if (Mathf.Abs(h) == 0 )
            {
                stateMachine.SwitchState(player.playerIdle);
            }

        }
    }

}
