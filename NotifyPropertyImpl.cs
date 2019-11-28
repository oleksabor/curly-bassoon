using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace wpfHeartbit
{
	public class NotifyPropertyImpl 
	{
		public event PropertyChangedEventHandler PropertyChanged;

		static ConcurrentDictionary<string, PropertyChangedEventArgs> _args = new ConcurrentDictionary<string, PropertyChangedEventArgs>();

		protected void Set<T>(ref T oldValue, T newValue, [CallerMemberName] string name = null)
		{
			if (!EqualityComparer<T>.Default.Equals(oldValue, newValue))
			{
				oldValue = newValue;
				Notify(name);
			}
		}

		protected void Notify([CallerMemberName] string name = null)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, GetArgs(name));
		}

		protected static PropertyChangedEventArgs GetArgs(string name)
		{
			_args.TryGetValue(name, out PropertyChangedEventArgs res);
			if (res == null)
			{
				res = new PropertyChangedEventArgs(name);
				_args.TryAdd(name, res);
			}
			return res;
		}
	}
}
