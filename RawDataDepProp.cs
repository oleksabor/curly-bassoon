using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace wpfHeartbit
{
	public class RawDataDepProp : DependencyObject, IRawData
	{
		public static readonly DependencyProperty IdProperty = Register<uint>("Id");
		public uint Id
		{
			get { return (uint)GetValue(IdProperty); }
			set { SetValue(IdProperty, value); }
		}

		public static readonly DependencyProperty AmountProperty = Register<decimal>("Amount");
		public decimal Amount
		{
			get { return (decimal)GetValue(AmountProperty); }
			set { SetValue(AmountProperty, value); }
		}
		public static readonly DependencyProperty AverageProperty = Register<decimal>("Average");
		public decimal Average
		{
			get { return (decimal)GetValue(AverageProperty); }
			set { SetValue(AverageProperty, value); }
		}
		public static readonly DependencyProperty CreatedProperty = Register<DateTime>("Created");
		public DateTime Created
		{
			get { return (DateTime)GetValue(CreatedProperty); }
			set { SetValue(CreatedProperty, value); }
		}
		public static readonly DependencyProperty ExpProperty = Register<decimal>("Exp");
		public decimal Exp
		{
			get { return (decimal)GetValue(ExpProperty); }
			set { SetValue(ExpProperty, value); }
		}
		public static readonly DependencyProperty InfoProperty = Register<string>("Info");
		public string Info
		{
			get { return (string)GetValue(InfoProperty); }
			set { SetValue(InfoProperty, value); }
		}
		public static readonly DependencyProperty MaxProperty = Register<decimal>("Max");
		public decimal Max
		{
			get { return (decimal)GetValue(MaxProperty); }
			set { SetValue(MaxProperty, value); }
		}
		public static readonly DependencyProperty MinProperty = Register<decimal>("Min");
		public decimal Min
		{
			get { return (decimal)GetValue(MinProperty); }
			set { SetValue(MinProperty, value); }
		}
		public static readonly DependencyProperty NoteProperty = Register<string>("Note");
		public string Note
		{
			get { return (string)GetValue(NoteProperty); }
			set { SetValue(NoteProperty, value); }
		}
		public static readonly DependencyProperty TitleProperty = Register<string>("Title");
		public string Title
		{
			get { return (string)GetValue(TitleProperty); }
			set { SetValue(TitleProperty, value); }
		}

		static DependencyProperty Register<T>(string name)
		{
			return DependencyProperty.Register(name, typeof(T), typeof(RawDataDepProp));
		}
	}
}
