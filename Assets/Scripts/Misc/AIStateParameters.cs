using Abstracts;

namespace Misc
{
    public class AIStateParameters
    {
        private BasePlayer _player;

        public BasePlayer Player => _player;
        
        public AIStateParameters(BasePlayer player)
        {
            _player = player;
        }
    }
}