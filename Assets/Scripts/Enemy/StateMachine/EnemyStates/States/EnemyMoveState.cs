namespace Game.Enemy
{
    public class EnemyMoveState : EnemyState
    {
        private readonly EnemyStateMachine _fsm;

        private readonly EnemyLocomotionController _locomotion;

        public EnemyMoveState(EnemyStateMachine fsm, EnemyLocomotionController locomotion)
        {
            _fsm = fsm;
            _locomotion = locomotion;
        }

        public override void Enter() { }

        public override void Exit() { }

        public override void Update()
        {
            _locomotion.Move();
        }
    }

}
