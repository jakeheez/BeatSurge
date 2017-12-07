using Heaserbeats.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace Heaserbeats.DataAccess
{
	public class BeatPageDAL
	{

		public ProducerViewModel GetProducerById(int producerId)
		{
			ProducerViewModel model = new ProducerViewModel();

			string connectionString = Heaserbeats.Properties.Settings.Default.HeaserBeatsConn;
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				conn.Open();

				using (SqlCommand command = new SqlCommand(String.Format("select * from producer where producerId = {0}", producerId), conn))
				{
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							model.producerId = reader.GetInt32(0);
							model.name = reader.GetString(1);
							model.subtitle = reader.GetString(2);
							model.primaryColor = reader.GetString(3);
							model.secondaryColor = reader.GetString(4);
							model.textColor = reader.GetString(5);
						}
					}
				}
			}
			return model;
		}

		public List<ProducerViewModel> GetAllProducers() 
		{
			List<ProducerViewModel> producers = new List<ProducerViewModel>();
			string connectionString = Heaserbeats.Properties.Settings.Default.HeaserBeatsConn;
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				conn.Open();

				using (SqlCommand command = new SqlCommand("select * from producer", conn))
				{
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							ProducerViewModel model = new ProducerViewModel();
							model.producerId = reader.GetInt32(0);
							model.name = reader.GetString(1);
							model.subtitle = reader.GetString(2);
							model.primaryColor = reader.GetString(3);
							model.secondaryColor = reader.GetString(4);
							model.textColor = reader.GetString(5);
							producers.Add(model);
						}
					}
				}

			}
			return producers;
		}

		public BeatViewModel GetBeatByBeatId(int beatId)
		{
			BeatViewModel beat = new BeatViewModel();
			string connectionString = Heaserbeats.Properties.Settings.Default.HeaserBeatsConn;
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				conn.Open();

				using (SqlCommand command = new SqlCommand(String.Format("select * from beat where beatId = {0}", beatId), conn))
				{
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							BeatViewModel model = new BeatViewModel();
							model.beatId = reader.GetInt32(0);
							model.title = reader.GetString(1);
							model.artist = reader.GetString(2);
							model.price = (double)reader.GetDecimal(3);
							model.producerId = reader.GetInt32(4);
							model.picName = "beat.png";
						}
					}
				}

			}
			return beat;
		}

		public List<BeatViewModel> GetAllBeatsByProducerId(int producerId)
		{
			List<BeatViewModel> beats = new List<BeatViewModel>();
			string connectionString = Heaserbeats.Properties.Settings.Default.HeaserBeatsConn;
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				conn.Open();

				using (SqlCommand command = new SqlCommand(String.Format("select * from beat where producerId = {0}", producerId), conn))
				{
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							BeatViewModel model = new BeatViewModel();
							model.beatId = reader.GetInt32(0);
							model.title = reader.GetString(1);
							model.artist = reader.GetString(2);
							model.price = (double)reader.GetDecimal(3);
							model.producerId = reader.GetInt32(4);
							model.picName = string.Format("{0}.png", model.beatId);

							beats.Add(model);
						}
					}
				}

			}
			return beats;
		}


	}
}