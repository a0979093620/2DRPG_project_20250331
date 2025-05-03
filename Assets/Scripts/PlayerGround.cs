using UnityEngine;
namespace lotta
{
    /// <summary>
    /// 玩家在地板上的狀態
    /// </summary>
    public class PlayerGround : PlayerState
    {

        public PlayerGround(Player _player, StateMachine _machine, string _name) : base(_player, _machine, _name)
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

            // 如果玩家在地面上並按下控 白鍵就切換到跳躍狀態
            if(player.IsGround() && Input.GetKeyDown(KeyCode.Space))
            {
                stateMachine.SwitchState(player.PlayerJump);
            }
        }




    }
}

