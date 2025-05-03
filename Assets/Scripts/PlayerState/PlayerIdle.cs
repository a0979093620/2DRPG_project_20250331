using UnityEngine;
namespace lotta
{
    /// <summary>
    /// 玩家待機
    /// </summary>
    public class PlayerIdle : PlayerGround
    {
        public PlayerIdle(Player _player, StateMachine _machine, string _name) : base(_player, _machine, _name)
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

            // 如果玩家按下左右或AD 就切換到走路狀態
            // 獲得玩家水平軸向 左右、AD
            // 左或 A :-1
            // 右或 D :+1
            // 沒按 : 0
            float h = Input.GetAxis("Horizontal");
            //Log.Text($"玩家的水平軸 : {h}", "#f93");

            // 如果絕對值 h > 0.1 就切換狀態
            if(Mathf.Abs(h) > 0.1f)
            {
                stateMachine.SwitchState(player.PlayerWalk);
            }

        }
    }
}

