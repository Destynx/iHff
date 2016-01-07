using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data.SqlClient;
using IHFF.Models;

namespace IHFF.Classes
{
    public class DatabaseHandeler
    {
        static string connString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                                   "Data Source=194.171.20.12;"+
                                   "Catalog=MVCdb08;" +
                                   "Persist Security Info=True" + 
                                   "User ID=MVCgrp08;" + 
                                   "Password=Kacaphkor6;";

        static OleDbConnection conn;
        static string sql;
        static OleDbCommand command;

        public static void AddWishlist(WishList wishlist)
        {
            conn = new OleDbConnection(connString);
            conn.Open();
            string sql = string.Format("INSERT INTO Wishlist (Wishlist_Code, Betaald) values ('{0}', '{1}')", wishlist.wishListCode, wishlist.betaald);
            command = new OleDbCommand(sql, conn);
            command.ExecuteNonQuery();
            foreach (WishlistItem wi in wishlist.itemList)
            {
                sql = string.Format("INSERT INTO Bestellingen (Wishlist_ID, Product_ID, Aantal, Stoel) values ({0}, {1}, {2}, {3})", wishlist.wishListCode, wi.item.ID, wi.Aantal, wi.StoelNummer);
                command = new OleDbCommand(sql, conn);
                command.ExecuteNonQuery();
            }
            conn.Close();
        }

        public static void UpdateWishlist(WishList wishlist)
        {
            conn = new OleDbConnection(connString);
            conn.Open();
            sql = string.Format("DELETE FROM Bestellingen WHERE Wishlist_ID=" + wishlist.wishListCode);
            foreach (WishlistItem wi in wishlist.itemList)
            {
                sql = string.Format("INSERT INTO Bestellingen (Wishlist_ID, Product_ID, Aantal, Stoel) values ({0}, {1}, {2}, {3})", wishlist.wishListCode, wi.item.ID, wi.Aantal, wi.StoelNummer);
                command = new OleDbCommand(sql, conn);
                command.ExecuteNonQuery();
            }
        }

        public static WishList GetWishlist() {

        }
    }
}