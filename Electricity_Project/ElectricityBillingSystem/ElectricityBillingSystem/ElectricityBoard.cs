using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ElectricityBillingSystem
{
    public class ElectricityBoard
    {
        public void CalculateBill(ElectricityBill ebill)
        {
            int units = ebill.UnitsConsumed;
            double amount = 0;

            if (units > 100)
            {
                units -= 100;
                if (units > 200)
                {
                    amount += 200 * 1.5;
                    units -= 200;
                    if (units > 300)
                    {
                        amount += 300 * 3.5;
                        units -= 300;
                        if (units > 400)
                        {
                            amount += 400 * 5.5;
                            units -= 400;
                            amount += units * 7.5;
                        }
                        else
                        {
                            amount += units * 5.5;
                        }
                    }
                    else
                    {
                        amount += units * 3.5;
                    }
                }
                else
                {
                    amount += units * 1.5;
                }
            }

            ebill.BillAmount = amount;
        }

        public void AddBill(ElectricityBill ebill)
        {
            using (SqlConnection con = DBHandler.GetConnection())
            {
                string query = "INSERT INTO ElectricityBill (consumer_number, consumer_name, units_consumed, bill_amount) VALUES (@num, @name, @units, @amount)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@num", ebill.ConsumerNumber);
                cmd.Parameters.AddWithValue("@name", ebill.ConsumerName);
                cmd.Parameters.AddWithValue("@units", ebill.UnitsConsumed);
                cmd.Parameters.AddWithValue("@amount", ebill.BillAmount);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<ElectricityBill> Generate_N_BillDetails(int n)
        {
            List<ElectricityBill> bills = new List<ElectricityBill>();
            using (SqlConnection con = DBHandler.GetConnection())
            {
                string query = $"SELECT TOP {n} * FROM ElectricityBill ORDER BY consumer_number DESC";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ElectricityBill eb = new ElectricityBill
                    {
                        ConsumerNumber = dr["consumer_number"].ToString(),
                        ConsumerName = dr["consumer_name"].ToString(),
                        UnitsConsumed = Convert.ToInt32(dr["units_consumed"]),
                        BillAmount = Convert.ToDouble(dr["bill_amount"])
                    };
                    bills.Add(eb);
                }
            }
            return bills;
        }
    }

}