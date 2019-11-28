using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace wpfHeartbit
{
	public interface IRawData
	{
		decimal Amount { get; set; }
		decimal Average { get; set; }
		DateTime Created { get; set; }
		decimal Exp { get; set; }
		uint Id { get; set; }
		string Info { get; set; }
		decimal Max { get; set; }
		decimal Min { get; set; }
		string Note { get; set; }
		string Title { get; set; }
	}

	public class RawData : NotifyPropertyImpl, INotifyPropertyChanged, IRawData
	{
		uint _id;
		public uint Id { get { return _id; } set { Set(ref _id, value); } }

		string _title;
		public string Title { get { return _title; } set { Set(ref _title, value); } }

		decimal _amount;
		public decimal Amount { get { return _amount; } set { Set(ref _amount, value); } }

		decimal _avg;
		public decimal Average { get { return _avg; } set { Set(ref _avg, value); } }

		decimal _min;
		public decimal Min { get { return _min; } set { Set(ref _min, value); } }

		decimal _max;
		public decimal Max { get { return _max; } set { Set(ref _max, value); } }

		decimal _exp;
		public decimal Exp { get { return _exp; } set { Set(ref _exp, value); } }

		string _note;
		public string Note { get { return _note; } set { Set(ref _note, value); } }

		DateTime _created;
		public DateTime Created { get { return _created; } set { Set(ref _created, value); } }

		string _info;
		public string Info { get { return _info; } set { Set(ref _info, value); } }
	}

}
