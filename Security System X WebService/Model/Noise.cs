using System;
using System.Runtime.Serialization;

namespace Security_System_X_WebService.Model
{
	[DataContract]
	public class Noise
	{
		[DataMember]
		public int ID { get; set; }

		//[DataMember]
		//public string Picture { get; set; }

		[DataMember]
		public string DateTime { get; set; }

		[DataMember]
		public string NoiseLevel { get; set; }


		public Noise()
		{
		}

		//public Noise(string picture)
		//{
		//	this.ID = Service1.NextId++;
		//	this.Picture = picture;
		//}

		//public Noise(string picture, string noiseLevel, string dateTime)
		//{
		//	this.ID = Service1.NextId++;
		//	this.Picture = picture;
		//	this.NoiseLevel = noiseLevel;
		//	this.DateTime = dateTime;

		//}

	}
}
