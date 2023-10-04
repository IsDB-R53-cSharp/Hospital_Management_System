using HMS.DAL.Data;
using HMS.Models.NumberGeneratorHelper;

namespace Hospital_Management_System.Helpers
{
	public class NumberGeneratorHelper
	{
		private readonly HospitalDbContext _context;

		public NumberGeneratorHelper(HospitalDbContext context)
		{
			_context = context;
		}

		public string GenerateNumber()
		{
			string currentDate = DateTime.Now.ToString("ddMMyyyy");

			int counter = GetCounterForDate(DateTime.Now.Date);

			string code = counter.ToString("0000");

			UpdateCounterForDate(DateTime.Now.Date, counter + 1);

			string generatedNumber = currentDate + "-" + code;

			return generatedNumber;
		}

		private int GetCounterForDate(DateTime date)
		{
			var record = _context.NumberCounterRecords.FirstOrDefault(r => r.Date == date);

			if (record == null)
			{
				// Create a new record for the date if it doesn't exist
				record = new NumberCounterRecord { Date = date, Counter = 1 };
				_context.NumberCounterRecords.Add(record);
				_context.SaveChanges();
			}

			return record.Counter;
		}

		private void UpdateCounterForDate(DateTime date, int newCounter)
		{
			var record = _context.NumberCounterRecords.FirstOrDefault(r => r.Date == date);

			if (record != null)
			{
				record.Counter = newCounter;
				_context.SaveChanges();
			}
		}
	}
}
