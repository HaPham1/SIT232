using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_3
{
    class SimpleReactionController : IController
    {
        //Set up
        private int _tick;
        private IGui _gui;
        private IRandom _rng;

        //State
        private State _state;


        // Methods
        public void Connect(IGui gui, IRandom rng)
        {
            _gui = gui;
            _rng = rng;
            Init();
        }

        public void Init()
        {
            _state = new IdleState(this);
        }


        public void CoinInserted()
        {
            _state.CoinInserted();
        }

        public void GoStopPressed()
        {
            _state.GoStopPressed();
        }

        public void Tick()
        {
            _state.Tick();
        }


        //State
        public abstract class State
        {
            public SimpleReactionController _controller;

            public State(SimpleReactionController controller)
            {
                _controller = controller;
            }

            public abstract void CoinInserted();

            public abstract void GoStopPressed();

            public abstract void Tick();
        }


        // Standby state before inserting coin.
        public class IdleState : State
        {
            public IdleState(SimpleReactionController controller) : base(controller)
            {
                _controller._gui.SetDisplay("Insert coin");
            }

            public override void CoinInserted()
            {
                _controller._state = new StartState(_controller);
            }

            public override void GoStopPressed()
            {

            }

            public override void Tick()
            {

            }
        }


        // State of starting after insert coin
        public class StartState : State
        {
            public StartState(SimpleReactionController controller) : base(controller)
            {
                _controller._gui.SetDisplay("Press GO!");
            }

            public override void CoinInserted()
            {

            }

            public override void GoStopPressed()
            {
                _controller._state = new WaitState(_controller);
            }

            public override void Tick()
            {

            }
        }



        //State of random waiting before record.
        public class WaitState : State
        {
            private int _wait;
            public WaitState(SimpleReactionController controller) : base(controller)
            {
                _controller._gui.SetDisplay("Wait...");
                _controller._tick = 0;
                _wait = _controller._rng.GetRandom(100, 250);
            }

            public override void CoinInserted()
            {

            }

            public override void GoStopPressed()
            {
                _controller._state = new IdleState(_controller);
            }

            public override void Tick()
            {
                _controller._tick++;
                if (_controller._tick == _wait)
                {
                    _controller._state = new TimeRecordState(_controller);
                }
            }
        }


        //State for when game start recording time for response.
        public class TimeRecordState: State
        {
            public TimeRecordState(SimpleReactionController controller) : base(controller)
            {
                _controller._tick = 0;
                _controller._gui.SetDisplay("0.00");
            }

            public override void CoinInserted()
            {

            }

            public override void GoStopPressed()
            {
                _controller._state = new DisplayState(_controller);
            }

            public override void Tick()
            {
                _controller._tick++;
                _controller._gui.SetDisplay((_controller._tick / 100.0 ).ToString("0.00"));
                if (_controller._tick == 200)
                {
                    _controller._state = new DisplayState(_controller);
                }
            }
        }


        //State that do the display of result
        public class DisplayState: State
        {
            public DisplayState(SimpleReactionController controller) : base(controller)
            {
                _controller._tick = 0;
            }

            public override void CoinInserted()
            {

            }

            public override void GoStopPressed()
            {
                _controller._state = new IdleState(_controller);
            }

            public override void Tick()
            {
                _controller._tick++;
                if (_controller._tick == 300)
                {
                    _controller._state = new IdleState(_controller);
                }
            }
        }
    }
}
