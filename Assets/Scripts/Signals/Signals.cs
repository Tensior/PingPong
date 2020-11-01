using strange.extensions.signal.impl;

namespace Signals
{
    public class StartSignal : Signal {}

    public class StartGameSignal : Signal {}
    
    public class RestartGameSignal : Signal {}
    
    public class StopGameSignal : Signal {}
    
    public class BallHitPlayerSignal : Signal {}
    
    public class CurrentScoreChangedSignal : Signal<int> {}
}