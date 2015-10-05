using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA2.Model
{
	class ReadRequest
	{
		public ReadRequest(Device device)
		{
			if (device == null)
				throw new ArgumentNullException("device", "Cannot be null");

			// NOTE: actually this will never be null since this collection is initialized with constructor...
			if (device.RegisterCollection == null)
				throw new ArgumentNullException("device.RegisterCollection", "Cannot be null");

			if (device.RegisterCollection.Count == 0)
				throw new ArgumentException("device.RegisterCollection.Count", "Cannot be zero");

			int _address = device.Address;
			if (device.RegisterCollection != null && device.RegisterCollection.Count > 0)
			{
				Register[] _coils =
					device.RegisterCollection
					.Where(x => x.CommandFunction == function.Coil)
					.OrderBy(x => x.Address).ToArray();

				Register[] _discreteInputs =
					device.RegisterCollection
					.Where(x => x.CommandFunction == function.DiscreteInput)
					.OrderBy(x => x.Address).ToArray();

				Register[] _holdings =
					device.RegisterCollection
					.Where(x => x.CommandFunction == function.Holding)
					.OrderBy(x => x.Address).ToArray();

				Register[] _inputs =
					device.RegisterCollection
					.Where(x => x.CommandFunction == function.Input)
					.OrderBy(x => x.Address).ToArray();


				string coilsRequest = string.Empty;
				StringBuilder sb = new StringBuilder();
				for (int i = 1; i < _coils.Length; i++)
				{

				}
            }
		}

		// TODO: call only if registers.Length > {some numer}
		int FindSolidBlock(Register[] registers, int overhead, ref int start, ref int length)
		{
			length = 1;
			start = registers[0].Address;
			int finish;
			for (int i = 1; i < registers.Length; i++)
			{
				if (registers[i].Address >= registers[i-1].Address + overhead)
				{
					length++;
				}
				else
				{
					// save current start and len
					finish = i;
					return finish;
				}
			}
			finish = registers.Length;
			return finish;

		}


		public string[] Build()
		{
			string[] _packet = new string[10];





			return _packet;
		}
	}
}
