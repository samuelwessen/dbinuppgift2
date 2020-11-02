using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerErrand.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerErrand.Service
{
    public static class ErrandService
    {
        public static async Task AddNewErrandAsync(string description, DateTime creationTime, string customerFullName, string customerEmail, int? customerPhoneNr, string status, string category)
        {
            using DataContext context = new DataContext();

            context.Errand.Add(new Errand(description, creationTime, customerFullName, customerEmail, customerPhoneNr, status, category));
            await context.SaveChangesAsync();
        }

        public static ObservableCollection<Errand> GetActiveErrands(string connectionString)
        {
            const string GetErrandsQuery = "SELECT * FROM ERRAND WHERE Status !='Completed'";

            var errands = new ObservableCollection<Errand>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = GetErrandsQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var errand = new Errand();
                                    errand.Id = reader.GetInt32(0);
                                    errand.Description = reader.GetString(1);
                                    errand.CreationTime = reader.GetDateTime(2);
                                    errand.CustomerFullName = reader.GetString(3);                                    
                                    errand.CustomerEmail = reader.GetString(4);
                                    errand.CustomerPhoneNr = reader.GetInt32(5);
                                    errand.Status = reader.GetString(6);
                                    errand.Category = reader.GetString(7);                                    
                                    errands.Add(errand);

                                }
                            }
                        }
                    }
                }
                return errands;
            }
            catch 
            {

            }
            return null;

        }

        public static ObservableCollection<Errand> GetCompletedErrands(string connectionString)
        {
            const string GetErrandsQuery = "SELECT * FROM ERRAND WHERE Status ='Completed'";

            var errands = new ObservableCollection<Errand>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = GetErrandsQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var errand = new Errand();
                                    errand.Id = reader.GetInt32(0);
                                    errand.Description = reader.GetString(1);
                                    errand.CreationTime = reader.GetDateTime(2);
                                    errand.CustomerFullName = reader.GetString(3);
                                    errand.CustomerEmail = reader.GetString(4);
                                    errand.CustomerPhoneNr = reader.GetInt32(5);
                                    errand.Status = reader.GetString(6);
                                    errand.Category = reader.GetString(7);
                                    errands.Add(errand);

                                }
                            }
                        }
                    }
                }
                return errands;
            }
            catch
            {

            }
            return null;

        }

        public static async Task UpdateErrandAsync(int id, string status)
        {            
            using DataContext context = new DataContext();

            var Errand = await context.Errand.FindAsync(id);

            if(Errand != null)
            {
                Errand.Status = status;
                context.Entry(Errand).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }



        }


    }
}
