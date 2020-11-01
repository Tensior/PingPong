using Commands;
using Input;
using Mediators.PlayField;
using Mediators.UI;
using Models;
using Services;
using Signals;
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
	
	public override IContext Start()
	{
		base.Start();
		var launchSignal= injectionBinder.GetInstance<LaunchSignal>();
		launchSignal.Dispatch();
		return this;
	}
		
	protected override void mapBindings()
	{
		//Сигналы и команды-----------------------------------------------------------
		commandBinder.Bind<LaunchSignal>().To<LaunchCommand>().Once();
		
		commandBinder.Bind<BallOutOfScreenSignal>().To<RestartGameCommand>();
		commandBinder.Bind<SaveGameSignal>().To<SaveGameCommand>();
		commandBinder.Bind<BallHitPlayerSignal>().To<IncreaseScoreCommand>();
		commandBinder.Bind<ChoseBallColorButtonSignal>().To<PauseGameCommand>();
		commandBinder.Bind<BallColorChosenSignal>().To<SetBallColor>().To<UnpauseGameCommand>().InSequence();

		injectionBinder.Bind<StartGameSignal>().ToSingleton();
		injectionBinder.Bind<StopGameSignal>().ToSingleton();
		injectionBinder.Bind<CurrentScoreChangedSignal>().ToSingleton();
		injectionBinder.Bind<BallColorChangedSignal>().ToSingleton();
		
		//Модели----------------------------------------------------------------------
		injectionBinder.Bind<IScoreModel>().To<ScoreModel>().ToSingleton();
		injectionBinder.Bind<IBallModel>().To<BallModel>().ToSingleton();


		//Вьюшки----------------------------------------------------------------------
		
		//Gameplay
		mediationBinder.Bind<PlayFieldView>().To<PlayFieldMediator>();
		mediationBinder.Bind<BallView>().To<BallMediator>();
		mediationBinder.Bind<PlayerPlatformView>().To<PlayerPlatformMediator>();
		mediationBinder.Bind<ScreenLimitView>().To<ScreenLimitMediator>();
		
		//UI
		mediationBinder.Bind<UIView>().To<UIMediator>();
		mediationBinder.Bind<ScoreView>().To<ScoreMediator>();
		mediationBinder.Bind<ColorChoiceView>().To<ColorChoiceMediator>();
		
		//Сервисы----------------------------------------------------------------------
		injectionBinder.Bind<IPlayerDataService>().To<PlayerPrefsService>().ToSingleton();


#if UNITY_ANDROID && !UNITY_EDITOR
		injectionBinder.Bind<IInput>().To<TouchInput>().ToSingleton();
#else
		injectionBinder.Bind<IInput>().To<KeyboardInput>().ToSingleton();
#endif
	}
}