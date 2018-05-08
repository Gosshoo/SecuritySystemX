using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;
using Security_System_X_WebService.Model;

//http://localhost:58087/Service1.svc/messages

namespace Security_System_X_WebService
{
	public class Service1 : IService1
	{
		public string connectionString =
				"Server=tcp:securityx.database.windows.net,1433;Initial Catalog=finalsecurity;Persist Security Info=False;User ID=obr;Password=Admin@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
		public string GetData()
		{
			return "test123";
		}

		public static int NextId = 0;

		WebOperationContext webContext = WebOperationContext.Current;


        //MOTION
	    private static List<Motion> motionList = new List<Motion>();

        //public IList<Motion> GetMotions()
        //{
        //    return motionList;
        //}

        private static Motion ReadMotion(IDataRecord reader)
		{
			int id = reader.GetInt32(0);
			//string picture = reader.GetString(1);
		    string motion1 = reader.GetString(3);
			string dataTime = reader.GetString(2);
			Motion motion = new Motion()
			{
				ID = id,
				//Picture = picture,
				DateTime = dataTime,
                MotionLevel = motion1
                
			};
			return motion;
		}

		//public Motion GetMotion(string id)
		//{
		//	webContext.OutgoingResponse.StatusCode = HttpStatusCode.OK;
		//	int idNumber = int.Parse(id);
		//	Motion c = cList.FirstOrDefault(motion => motion.ID == idNumber);
		//	if (c == null) webContext.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;
		//	return c;
		//}

	    public IList<Motion> GetMotions()
	    {
	        const string getMotions = "SELECT * FROM SecuritySystemX Where Motion = 'Motion High' order by Date_and_Time DESC";
	        using (SqlConnection sqlConnection = new SqlConnection(connectionString))
	        {
	            sqlConnection.Open();
	            using (SqlCommand selectCommand = new SqlCommand(getMotions, sqlConnection))
	            {

	                using (SqlDataReader reader = selectCommand.ExecuteReader())
	                {
	                    motionList.Clear();
                        if (!reader.HasRows)
	                    {
	                        throw new ArgumentNullException("id", "Doesn`t exist in the database");
	                        //return null;
	                    }
	                    while (reader.Read())
	                    {
	                        //reader.Read();
                            
	                        var customer1 = ReadMotion(reader);
	                        motionList.Add(customer1);
	                        //return cList;
	                    }
                       
	                    return motionList;
	                }
	            }
	        }
        }

	    public Motion GetMotion()
		{
			const string getMotionbyId = "SELECT TOP 4 * FROM SecuritySystemX Where Motion = 'Motion High' ORDER BY Id DESC;";
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				sqlConnection.Open();
				using (SqlCommand selectCommand = new SqlCommand(getMotionbyId, sqlConnection))
				{
					
					using (SqlDataReader reader = selectCommand.ExecuteReader())
					{
						if (!reader.HasRows)
						{
							throw new ArgumentNullException("id", "Doesn`t exist in the database");
							//return null;
						}
						reader.Read();
						var motion1 = ReadMotion(reader);
						return motion1;
					}
				}
			}
		}

		//public Motion InsertMotion(Motion motion)
		//{
		//	motion.ID = Service1.NextId++;
		//	cList.Add(motion);
		//	return motion;
		//}

		public int InsertMotion(Motion c)
		{
		    try
		    {
		        const string insertQuery = "insert into SecuritySystemX (Motion, Date_and_Time) values (@Motion, @Date_and_Time)";
		        using (SqlConnection sqlConnection = new SqlConnection(connectionString))
		        {
		            sqlConnection.Open();
		            using (SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection))
		            {
		                insertCommand.Parameters.AddWithValue("@Motion", c.MotionLevel);

		                insertCommand.Parameters.AddWithValue("@Date_and_Time", c.DateTime);

		                var rowsAffected = insertCommand.ExecuteNonQuery();
		                if (rowsAffected == 0)
		                {
		                    throw new InvalidOperationException();
		                }
		                return rowsAffected;
		            }
		        }
            }
		    catch (Exception e)
		    {
		        
		        throw new InvalidOperationException();
		    }
			
			//motionList.Add(c);
		}

		//NOISE

	    private static List<Noise> noiseList = new List<Noise>();

		public IList<Noise> GetNoises()
		{
		    const string getNoises = "SELECT * FROM SecuritySystemX Where Noise_Level = 'Sound Detected' order by Date_and_Time DESC";
		    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
		    {
		        sqlConnection.Open();
		        using (SqlCommand selectCommand = new SqlCommand(getNoises, sqlConnection))
		        {

		            using (SqlDataReader reader = selectCommand.ExecuteReader())
		            {
		                noiseList.Clear();
                        if (!reader.HasRows)
		                {
		                    throw new ArgumentNullException("id", "Doesn`t exist in the database");
		                    //return null;
		                }
		                while (reader.Read())
		                {
		                    //reader.Read();
                            
		                    var customer1 = ReadNoise(reader);
		                    noiseList.Add(customer1);
		                    //return cList;
		                }

		                return noiseList;
		            }
		        }
		    }
        }

		private static Noise ReadNoise(IDataRecord reader)
		{
			int id = reader.GetInt32(0);
			//string picture = reader.GetString(1);
			string dataTime = reader.GetString(2);
			string noiseLevel = reader.GetString(1);
			Noise noise = new Noise()
			{
				ID = id,
				//Picture = picture,
				NoiseLevel = noiseLevel,
				DateTime = dataTime
			};
			return noise;
		}

		//public Noise GetNoise(string id)
		//{
		//	webContext.OutgoingResponse.StatusCode = HttpStatusCode.OK;
		//	int idNumber = int.Parse(id);
		//	Noise c = noiseList.FirstOrDefault(noise => noise.ID == idNumber);
		//	if (c == null) webContext.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;
		//	return c;
		//}

		public Noise GetNoise()
		{
			const string getNoisebyId = "SELECT TOP 1 * FROM SecuritySystemX Where Noise_Level = 'Sound Detected' ORDER BY Id DESC;";
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				sqlConnection.Open();
				using (SqlCommand selectCommand = new SqlCommand(getNoisebyId, sqlConnection))
				{
					
					using (SqlDataReader reader = selectCommand.ExecuteReader())
					{
						if (!reader.HasRows)
						{
							throw new ArgumentNullException("id", "Doesn`t exist in the database");
							//return null;
						}
						reader.Read();
						var noise1 = ReadNoise(reader);
						return noise1;
					}
				}
			}
		}

		//public Noise InsertNoise(Noise noise)
		//{
		//	noise.ID = Service1.NextId++;
		//	noiseList.Add(noise);
		//	return noise;
		//}

		public int InsertNoise(Noise c)
		{
		    try
		    {
		        const string insertQuery = "insert into SecuritySystemX (Noise_Level, Date_and_Time) values (@Noise_Level, @Date_and_Time)";
		        using (SqlConnection sqlConnection = new SqlConnection(connectionString))
		        {
		            sqlConnection.Open();
		            using (SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection))
		            {
		                insertCommand.Parameters.AddWithValue("@Noise_Level", c.NoiseLevel);
		                insertCommand.Parameters.AddWithValue("@Date_and_Time", c.DateTime);
		                var rowsAffected = insertCommand.ExecuteNonQuery();
		                if (rowsAffected == 0)
		                {
		                    throw new InvalidOperationException();
		                }
		                return rowsAffected;
		            }
		        }
            }
		    catch (Exception e)
		    {
		        
		        throw new InvalidOperationException();
		    }
			
			//noiseList.Add(c);
		}

	    public int DeleteNoise(string id)
	    {
	        const string deleteQuery = "delete from SecuritySystemX where Id=@Id";
	        using (SqlConnection sqlConnection = new SqlConnection(connectionString))
	        {
	            sqlConnection.Open();
	            using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, sqlConnection))
	            {
	                deleteCommand.Parameters.AddWithValue("@Id", id);
	                int rowsAffected = deleteCommand.ExecuteNonQuery();
	                if (rowsAffected == 0)
	                {
	                    throw new ArgumentNullException();
	                }
	                return rowsAffected;
	            }
	        }
        }
	}
}

