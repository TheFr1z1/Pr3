using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static System.Collections.Specialized.BitVector32;

namespace TransportRoutePlanner
{
    public class DatabaseHelper
    {
        private string connectionString = "Server=KAB706-ST2\\SQLEXPRESS;Database=MarshrutMetro;Trusted_Connection=True;";
        public List<Station> GetAllStations()
        {
            List<Station> stations = new List<Station>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT StationID, StationName, LineColor FROM Stations", conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Station station = new Station
                    {
                        StationID = reader.GetInt32(0),
                        StationName = reader.GetString(1),
                        LineColor = reader.GetString(2)
                    };
                    stations.Add(station);
                }
            }

            return stations;
        }
        public List<MetroRoutes> GetRoutesBetweenStations(int startStationID, int endStationID)
        {
            List<MetroRoutes> routes = new List<MetroRoutes>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT RouteID, RouteName, Duration FROM MetroRoutes WHERE StartStationID = @startStationID AND EndStationID = @endStationID", conn);
                cmd.Parameters.AddWithValue("@startStationID", startStationID);
                cmd.Parameters.AddWithValue("@endStationID", endStationID);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    MetroRoutes route = new MetroRoutes
                    {
                        RouteID = reader.GetInt32(0),
                        RouteName = reader.GetString(1),
                        Duration = reader.GetInt32(2) 
                    };
                    routes.Add(route);
                }
            }

            return routes;
        }



    }

    public class Station
    {
        public int StationID { get; set; }
        public string StationName { get; set; }
        public string LineColor { get; set; }
    }
    public class MetroRoutes
    {
        public int RouteID { get; set; }
        public string RouteName { get; set; }
        public int Duration{ get; set; }

        public override string ToString()
        {
            return $"{RouteName} - Время в пути: {Duration} мин.";
        }
    }

}
