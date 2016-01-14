using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using IHFF.Models;

namespace IHFF.Classes
{
    public class DatabaseHandler
    {
        static string connString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                                   "Data Source=194.171.20.12;" +
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

        public static WishList GetWishlist(int wishListCode)
        {
            WishList wishList = new WishList();
            wishList.itemList = new List<WishlistItem>();
            wishList.wishListCode = wishListCode;
            conn = new OleDbConnection(connString);
            conn.Open();
            sql = string.Format("SELECT Betaald FROM Wishlist WHERE Wishlist_Code = {0};", wishListCode);
            command = new OleDbCommand(sql, conn);
            wishList.betaald = (bool)command.ExecuteScalar();
            sql = string.Format("SELECT TotaalPrijs FROM Wishlist WHERE Wishlist_Code = {0};", wishListCode);
            command = new OleDbCommand(sql, conn);
            wishList.TotaalPrijs = (float)command.ExecuteScalar();
            sql = string.Format("SELECT (Product_ID, Aantal, Stoel, TotaalPrijs) FROM Bestellingen WHERE Wishlist_ID = {0};", wishListCode);
            command = new OleDbCommand(sql, conn);
            OleDbDataReader rdr = command.ExecuteReader();
            while (rdr.Read())
            {
                wishList.itemList.Add(new WishlistItem { item = new Product { ID = (int)rdr["Product_ID"] }, Aantal = (int)rdr["Aantal"], StoelNummer = (int)rdr["Stoel"] });
            }
            conn.Close();
            return wishList;
        }

        public static Product GetProduct(int Product_ID)
        {
            Product product = new Product();
            conn = new OleDbConnection(connString);
            conn.Open();
            sql = string.Format("SELECT * FROM Producten WHERE Item_ID = {0};", Product_ID);
            command = new OleDbCommand(sql, conn);
            OleDbDataReader rdr = command.ExecuteReader();
            while (rdr.Read())
            {
                product = new Product { ID = Product_ID, Beschrijving = (string)rdr["Item_Beschrijving"], Locatie = new Locatie { Locatie_ID = (int)rdr["Item_LocatieID"] }, Naam = (string)rdr["Item_Naam"], Plaatsen = (int)rdr["Plaatsen"] };
            }
            sql = string.Format("SELECT * FROM Locaties WHERE Locatie_ID = {0}", product.Locatie.Locatie_ID);
            command = new OleDbCommand(sql, conn);
            rdr = command.ExecuteReader();
            while (rdr.Read())
            {
                product.Locatie.Adres = string.Format((string)rdr["Straatnaam"] + " " + (int)rdr["Huisnummer"]);
                product.Locatie.Naam = (string)rdr["Locatie_Naam"];
                product.Locatie.Postcode = (string)rdr["Locatie_Postcode"];
                product.Locatie.IsRestaurant = (bool)rdr["Restaurant"];
            }
            if (product.Locatie.IsRestaurant)
            {
                Restaurant restaurant = new Restaurant();
                sql = string.Format("SELECT * FROM Restaurants WHERE Locatie_ID = {0};", product.Locatie.Locatie_ID);
                command = new OleDbCommand(sql, conn);
                rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                    restaurant = new Restaurant { ID = product.ID, Naam = product.Naam, Beschrijving = product.Beschrijving, Locatie = product.Locatie, Plaatsen = product.Plaatsen, Keuken = (string)rdr["Soort_Keuken"], Openingstijd = (DateTime)rdr["Openingstijd"], Dinnerswitch = (DateTime)rdr["Dinertijd"], Sluitingstijd = (DateTime)rdr["Sluitingstijd"] };
                    //Checken of dit werkt.
                }
                return restaurant;
            }
            return product;
        }
    }
}
