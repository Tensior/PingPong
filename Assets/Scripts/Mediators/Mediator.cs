using strange.extensions.mediation.impl;

namespace Mediators
{
    public abstract class Mediator<TView> : Mediator where TView : View
    {
        [Inject] public TView View{ get; set; }
    }
}