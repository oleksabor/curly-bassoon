using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace wpfHeartbit
{
	public class MainWindowViewModel : NotifyPropertyImpl, INotifyPropertyChanged, IDisposable
	{
		CancellationTokenSource cncl;

		public MainWindowViewModel()
		{
			cncl = new CancellationTokenSource();

			var hrt = new Heartbit(() => new RawData());
			Rows = hrt.Get(0, 10);
			Freq500 = true;

			var dep = new DependencyObject();
			if (!DesignerProperties.GetIsInDesignMode(dep))
			{
				var action = false
					? new Action(() => RunRows(cncl.Token, hrt))
					: new Action(() => RunRowUpdate(cncl.Token, hrt));
				RunTask = Task.Run(action);
			}
		}

		Task RunTask;

		void RunRows(CancellationToken token, Heartbit hrt)
		{
			while (!token.IsCancellationRequested)
			{
				Rows = hrt.Get(Current, 100);
				Current++;
				if (Current == uint.MaxValue)
					Current = 0;

				Thread.Sleep(1000);
			}
		}

		void RunRowUpdate(CancellationToken token, Heartbit hrt)
		{
			Rows = hrt.Get(Current, 100);
			while (!token.IsCancellationRequested)
			{
				Current++;
				if (Current == uint.MaxValue)
					Current = 0;
				uint q = 0;
				foreach (var rd in Rows)
				{
					hrt.SetItem(rd, q++ + Current);
				}

				if (!token.IsCancellationRequested)
					Thread.Sleep(Freq);
			}
		}

		int _freq;
		public int Freq { get { return _freq; } set { Set(ref _freq, value); } }


		public bool Freq250 { get { return Freq == 250; } set { if (value) Freq = 250; } }
		public bool Freq500 { get { return Freq == 500; } set { if (value) Freq = 500;  } }
		public bool Freq750 { get { return Freq == 750; } set { if (value) Freq = 750; } }
		public bool Freq1000 { get { return Freq == 1000; } set { if (value) Freq = 1000; } }
		
		ObservableCollection<IRawData> _rows;
		public ObservableCollection<IRawData> Rows { get { return _rows; } set { Set(ref _rows, value); } }

		uint _current;
		public uint Current { get { return _current; } set { Set(ref _current, value); } }

		public void Dispose()
		{
			cncl.Cancel();
			cncl.Dispose();
		}
	}
}
