using System;
using System.Runtime.Serialization;

namespace Security_System_X_WebService.Model
{
	[DataContract]
	public class Motion
	{
		[DataMember]
		public int ID { get; set; }

		//[DataMember]
		//public string MotionBool { get; set; }

		[DataMember]
		public string MotionLevel { get; set; }

		//[DataMember]
		//public string Picture { get; set; }

		[DataMember]
		public string DateTime { get; set; }

		public Motion()
		{
		}

		//public Motion(string picture)
		//{
		//	//this.ID = Service1.NextId++;
		//	this.Picture = picture;
		//}

		//public Motion(string motionBool, string motionLevel, string picture, string dateTime)
		//{
		//	//this.ID = Service1.NextId++;
		//	//this.MotionBool = MotionBool;
		//	this.MotionLevel = motionLevel;
		//	this.Picture = picture;
		//	this.DateTime = dateTime;
		//}

	}
}
