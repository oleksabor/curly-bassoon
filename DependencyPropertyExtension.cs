using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace wpfHeartbit
{
	public class DependencyPropertyExtension
	{

		public static readonly DependencyProperty IsSpinningProperty =
	DependencyProperty.Register(
	"IsSpinning", typeof(Boolean),
	typeof(MyCode)
	);
		public bool IsSpinning
		{
			get { return (bool)GetValue(IsSpinningProperty); }
			set { SetValue(IsSpinningProperty, value); }
		}
	}
}
