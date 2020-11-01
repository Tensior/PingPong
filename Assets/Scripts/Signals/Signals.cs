using strange.extensions.signal.impl;
using UnityEngine;

namespace Signals
{
    public class LaunchSignal : Signal {}

    public class StartGameSignal : Signal {}
    
    public class StopGameSignal : Signal {}
    
    public class SaveGameSignal : Signal {}
    
    public class BallOutOfScreenSignal: Signal {}
    
    public class BallHitPlayerSignal : Signal {}
    
    public class CurrentScoreChangedSignal : Signal<int> {}
    
    public class ChoseBallColorButtonSignal : Signal {}
    
    public class BallColorChosenSignal : Signal<Color> {}
    
    public class BallColorChangedSignal : Signal<Color> {}
}