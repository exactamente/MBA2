using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using MBA2.Model;

namespace MBA2.Model
{
	public class StoredPortConfigurations
	{
		private List<ComPortConfiguration> _storedPortConfigurations;
		private readonly string _cfgFile;

		public StoredPortConfigurations()
		{
			_cfgFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StoredPortConfigurations.cfg");
			Deserialize();
		}

		public void Delete(ComPortConfiguration pc)
		{
			_storedPortConfigurations.Remove(pc);
			Serialize();
		}

		public List<ComPortConfiguration> FindAll()
		{
			return new List<ComPortConfiguration>(_storedPortConfigurations);
		}

		public void Serialize()
		{
			using (FileStream stream = File.Open(_cfgFile, FileMode.OpenOrCreate))
			{
				BinaryFormatter formatter = new BinaryFormatter();
				formatter.Serialize(stream, _storedPortConfigurations);
				stream.Flush();
			}
		}
		public void Deserialize()
		{
			if (File.Exists(_cfgFile))
			{
				using (FileStream stream = File.Open(_cfgFile, FileMode.Open))
				{
					BinaryFormatter formatter = new BinaryFormatter();
					_storedPortConfigurations = (List<ComPortConfiguration>)formatter.Deserialize(stream);
				}

				//using (var stream = new BinaryReader(File.Open(_cfgFile, FileMode.Open)))
				//{
				//	byte[] b = stream.ReadBytes((int)stream.BaseStream.Length);
				//	BinaryFormatter formatter = new BinaryFormatter();
				//	_storedPortConfigurations = (List<ComPortConfiguration>)formatter.Deserialize(new MemoryStream(b));
				//}
			}
			else _storedPortConfigurations = new List<ComPortConfiguration>();
		}

	}
}
