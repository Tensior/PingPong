using Commands;
using Input;
using Mediators.PlayField;
using Mediators.UI;
using Models;
using Services;
using Signals;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using UnityEngine;
using Views.PlayField;
using Views.UI;

public class GameContext : MVCSContext
{

	public GameContext (MonoBehaviour view) : base(view)
	{
	}

	// Override Start so that we can fire the StartSignal 
	public override IContext Start()
	{
		base.Start();
		var startSignal= injectionBinder.GetInstance<StartSignal>();
		startSignal.Dispatch();
		return this;
	}
		
	protected override void mapBindings()
	{
		//Сигналы и команды-----------------------------------------------------------
		commandBinder.Bind<StartSignal>().To<StartCommand>().Once();
		commandBinder.Bind<LoseGameSignal>().To<LoseGameCommand>();
		commandBinder.Bind<RestartGameSignal>().To<RestartGameCommand>();
		commandBinder.Bind<BallHitPlayerSignal>().To<IncreaseScoreCommand>();

		injectionBinder.Bind<StartGameSignal>().ToSingleton();
		injectionBinder.Bind<CurrentScoreChangedSignal>().ToSingleton();
		
		//Модели----------------------------------------------------------------------
		injectionBinder.Bind<IScoreModel>().To<ScoreModel>().ToSingleton();


		//Вьюшки----------------------------------------------------------------------
		
		//Gameplay
		mediationBinder.Bind<PlayFieldView>().To<PlayFieldMediator>();
		mediationBinder.Bind<BallView>().To<BallMediator>();
		mediationBinder.Bind<PlayerPlatformView>().To<PlayerPlatformMediator>();
		mediationBinder.Bind<ScreenLimitView>().To<ScreenLimitMediator>();
		
		//UI
		mediationBinder.Bind<ScoreView>().To<ScoreMediator>();
		
		//Сервисы----------------------------------------------------------------------
		injectionBinder.Bind<IPlayerDataService>().To<PlayerPrefsService>().ToSingleton();


#if UNITY_ANDROID && !UNITY_EDITOR
		injectionBinder.Bind<IInput>().To<TouchInput>().ToSingleton();
#else
		injectionBinder.Bind<IInput>().To<KeyboardInput>().ToSingleton();
#endif
		
		/*injectionBinder.Bind<IExampleModel>().To<ExampleModel>().ToSingleton();
		injectionBinder.Bind<IExampleService>().To<ExampleService>().ToSingleton();
			

		mediationBinder.Bind<ExampleView>().To<ExampleMediator>();
			

		commandBinder.Bind<CallWebServiceSignal>().To<CallWebServiceCommand>();
			
		//StartSignal is now fired instead of the START event.
		//Note how we've bound it "Once". This means that the mapping goes away as soon as the command fires.
		
			
		//In MyFirstProject, there's are SCORE_CHANGE and FULFILL_SERVICE_REQUEST Events.
		//Here we change that to a Signal. The Signal isn't bound to any Command,
		//so we map it as an injection so a Command can fire it, and a Mediator can receive it
		injectionBinder.Bind<ScoreChangedSignal>().ToSingleton();
		injectionBinder.Bind<FulfillWebServiceRequestSignal>().ToSingleton();*/
	}
}