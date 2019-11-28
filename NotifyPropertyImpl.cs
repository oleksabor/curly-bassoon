using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace wpfHeartbit
{
	public class NotifyPropertyImpl 
	{
		public event PropertyChangedEventHandler PropertyChanged;

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
				PropertyChanged(this, new PropertyChangedEventArgs(name));
		}
	}
}
