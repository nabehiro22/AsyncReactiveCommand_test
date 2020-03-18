using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System.Reactive.Disposables;
using System.Threading.Tasks;

namespace Arc.ViewModels
{
	public class MainWindowViewModel : BindableBase
	{
		/// <summary>
		/// タイトル
		/// </summary>
		public ReactivePropertySlim<string> Title { get; } = new ReactivePropertySlim<string>("AsyncReactiveCommand実験");

		/// <summary>
		/// Disposeが必要な処理をまとめてやる
		/// </summary>
		private CompositeDisposable Disposable { get; } = new CompositeDisposable();

		/// <summary>
		/// ウィンドウを閉じる時
		/// </summary>
		public ReactiveCommand ClosedCommand { get; } = new ReactiveCommand();

		/// <summary>
		/// ViewのButton1用
		/// </summary>
		public AsyncReactiveCommand Button1Command { get; }

		/// <summary>
		/// ViewのButton2用
		/// </summary>
		public AsyncReactiveCommand Button2Command { get; }

		/// <summary>
		/// ViewのButton3用
		/// </summary>
		public AsyncReactiveCommand Button3Command { get; }

		/// <summary>
		/// 複数のボタンの状態を制御
		/// </summary>
		public ReactivePropertySlim<bool> IsButtonEnable = new ReactivePropertySlim<bool>(true);

		public MainWindowViewModel()
		{
			Button1Command = new AsyncReactiveCommand().WithSubscribe(Button1Processing).AddTo(Disposable);
			Button2Command = IsButtonEnable.ToAsyncReactiveCommand().WithSubscribe(Button2Processing).AddTo(Disposable);
			Button3Command = IsButtonEnable.ToAsyncReactiveCommand().WithSubscribe(Button3Processing).AddTo(Disposable);
			ClosedCommand.Subscribe(Close).AddTo(Disposable);
		}

		/// <summary>
		/// アプリが閉じられる時
		/// </summary>
		private void Close()
		{
			Disposable.Dispose();
		}

		/// <summary>
		/// Button1が押された時の処理
		/// </summary>
		/// <returns></returns>
		private async Task Button1Processing()
		{
			await Task.Delay(1000);
		}

		/// <summary>
		/// Button2が押された時の処理
		/// </summary>
		/// <returns></returns>
		private async Task Button2Processing()
		{
			await Task.Delay(1000);
		}

		/// <summary>
		/// Button3が押された時の処理
		/// </summary>
		/// <returns></returns>
		private async Task Button3Processing()
		{
			await Task.Delay(1000);
		}
	}
}
