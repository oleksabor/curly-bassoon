using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace wpfHeartbit
{
	public class Heartbit
	{
		private readonly Func<IRawData> factory;

		public Heartbit(Func<IRawData> factory)
		{
			this.factory = factory;
		}

		public ObservableCollection<IRawData> Get(uint current, int count)
		{
			var res = new ObservableCollection<IRawData>();
			for (uint q = 0; q < count; q++)
				res.Add(GetItem(q + current));
			return res;
		}

		public IRawData GetItem(uint id)
		{
			return SetItem(factory(), id); 
		}
		
		public RawData SetItem(IRawData value, uint id)
		{
   
			value.Id = id;
			value.Title = $"title {id}";
			value.Created = DateTime.Now;
			value.Note = $"{value.Created:G}";

			value.Amount = (id % 2) * 14;
			value.Max = 360;
			value.Min = (id % 4) * 5;
			value.Average = (id % 3) * 2;
			value.Exp = (id % 6) * 11;

			var code = 41;
			code = code * 59 + value.Title.GetHashCode();
			code = code * 59 + value.Note.GetHashCode();
			value.Info = code.ToString();
			return value;
		}
	}
}
