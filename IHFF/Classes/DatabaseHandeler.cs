using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using IHFF.Models;

namespace IHFF.Classes
{
    public class DatabaseHandler
    {
        static string connString = "Data Source=194.171.20.12;" +
                                   "Initial Catalog=MVCdb08;" +
                                   "Persist Security Info=false;" +
                                   "User id=MVCgrp08;" +
                                   "Password=Kacaphkor6;";

        static SqlConnection conn;
        static string sql;
        static SqlCommand command;

        public static void PayWishlist(WishList wishlist)
        {
            conn = new SqlConnection(connString);
            conn.Open();
            string sql = string.Format("UPDATE Wishlist SET Betaald='{0}' WHERE Wishlist_ID={1}", wishlist.betaald, GetWishlistID(wishlist.wishListCode));
            command = new SqlCommand(sql, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }
        public static void AddWishlist(WishList wishlist)
        {
            conn = new SqlConnection(connString);
            conn.Open();
            string sql = string.Format("INSERT INTO Wishlist (Wishlist_Code, Betaald, TotaalPrijs) values ('{0}', '{1}', {2})", wishlist.wishListCode, wishlist.betaald, 0);
            command = new SqlCommand(sql, conn);
            command.ExecuteNonQuery();
            foreach (WishlistItem wi in wishlist.itemList)
            {
                sql = string.Format("INSERT INTO Bestellingen (Wishlist_ID, Product_ID, Aantal, Stoel) values ({0}, {1}, {2}, {3})", wishlist.wishListCode, wi.item.ID, wi.Aantal, wi.StoelNummer);
                command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();
            }
            conn.Close();
        }

        public static void UpdateWishlist(WishList wishlist)
        {
            if (!WishListExists(wishlist.wishListCode))
            {
                AddWishlist(wishlist);
                return;
            }
            conn = new SqlConnection(connString);
            conn.Open();
            sql = string.Format("DELETE FROM Bestellingen WHERE Wishlist_ID=" + wishlist.wishListCode);
            foreach (WishlistItem wi in wishlist.itemList)
            {
                sql = string.Format("INSERT INTO Bestellingen (Wishlist_ID, Product_ID, Aantal, Stoel) values ({0}, {1}, {2}, {3})", wishlist.wishListCode, wi.item.ID, wi.Aantal, wi.StoelNummer);
                command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();
            }
            conn.Close();
        }

        public static WishList GetWishlist(int wishListCode)
        {
            if (!WishListExists(wishListCode)) { return new WishList {wishListCode = wishListCode}; }
            WishList wishList = new WishList();
            wishList.itemList = new List<WishlistItem>();
            wishList.wishListCode = wishListCode;
            conn = new SqlConnection(connString);
            conn.Open();
            sql = string.Format("SELECT * FROM Bestellingen INNER JOIN Producten ON Bestellingen.Product_ID=Producten.Item_ID WHERE Wishlist_ID ={0}", wishListCode);
            command = new SqlCommand(sql, conn);
            SqlDataReader rdr = command.ExecuteReader();
            while (rdr.Read())
            {
                wishList.itemList.Add(new WishlistItem { item = new Product { ID = (int)rdr["Item_ID"], Beschrijving = (string)rdr["Item_Beschrijving"], Locatie = GetLocatie((int)rdr["Item_LocatieID"]), Naam = (string)rdr["Item_Naam"], Plaatsen = (int)rdr["Plaatsen"], Dag = (string)rdr["Dag"], Prijs = 7.50}, Aantal = (int)rdr["Aantal"], StoelNummer = (int)rdr["Stoel"],});
            }
            conn.Close();
            return wishList;
        }

        public static Product GetProduct(Product Product)
        {
            conn = new SqlConnection(connString);
            conn.Open();
            sql = string.Format("SELECT * FROM Producten WHERE Item_ID = {0};", Product.ID);
            command = new SqlCommand(sql, conn);
            SqlDataReader rdr = command.ExecuteReader();
            if (rdr.Read())
            {
                Product = new Product { ID = Product.ID, Beschrijving = (string)rdr["Item_Beschrijving"], Locatie = GetLocatie((int)rdr["Item_LocatieID"]), Naam = (string)rdr["Item_Naam"], Plaatsen = (int)rdr["Plaatsen"], Dag = (string)rdr["Dag"], Prijs = 7.50};
            }
            rdr.Close();
            return Product;
        }

        public static Product GetProduct(int Product_ID)
        {
            Product product = new Product();
            conn = new SqlConnection(connString);
            conn.Open();
            sql = string.Format("SELECT * FROM Producten WHERE Item_ID = {0};", Product_ID);
            command = new SqlCommand(sql, conn);
            SqlDataReader rdr = command.ExecuteReader();
            if (rdr.Read())
            {
                product = new Product { ID = Product_ID, Beschrijving = (string)rdr["Item_Beschrijving"], Locatie = GetLocatie((int)rdr["Item_LocatieID"]), Naam = (string)rdr["Item_Naam"], Plaatsen = (int)rdr["Plaatsen"], Dag = (string)rdr["Dag"], tijd = (DateTime)rdr["Item_DateTime"], Prijs = 7.50};
            }
            rdr.Close();
            if (product.Locatie.IsRestaurant)
            {
                Restaurant restaurant = new Restaurant();
                conn.Open();
                sql = string.Format("SELECT * FROM Restaurants WHERE Locatie_ID = {0};", product.Locatie.Locatie_ID);
                command = new SqlCommand(sql, conn);
                rdr = command.ExecuteReader();
                if (rdr.Read())
                {
                    restaurant = new Restaurant { ID = product.ID, Naam = product.Naam, Beschrijving = product.Beschrijving, Locatie = product.Locatie, Openingstijd = (DateTime)rdr["Openingstijd"], Dinnerswitch = (DateTime)rdr["Dinertijd"], Sluitingstijd = (DateTime)rdr["Sluitingstijd"]};
                }
                conn.Close();
                return restaurant;
            }
            conn.Close();
            return product;
        }

        public static Restaurant GetRestaurant(int Product_ID)
        {
            Product product = new Product();
            conn = new SqlConnection(connString);
            conn.Open();
            sql = string.Format("SELECT * FROM Producten WHERE Item_ID = {0};", Product_ID);
            command = new SqlCommand(sql, conn);
            SqlDataReader rdr = command.ExecuteReader();
            if (rdr.Read())
            {
                product = new Product { ID = Product_ID, Beschrijving = (string)rdr["Item_Beschrijving"], Locatie = new Locatie { Locatie_ID = (int)rdr["Item_LocatieID"] }, Naam = (string)rdr["Item_Naam"], Plaatsen = (int)rdr["Plaatsen"], Dag = (string)rdr["Dag"] };
            }
            rdr.Close();
            sql = string.Format("SELECT * FROM Locaties WHERE Locatie_ID = {0}", product.Locatie.Locatie_ID);
            command = new SqlCommand(sql, conn);
            rdr = command.ExecuteReader();
            if (rdr.Read())
            {
                product.Locatie.Adres = string.Format((string)rdr["Locatie_Straatnaam"] + " " + (int)rdr["Locatie_Huisnummer"]);
                product.Locatie.Naam = (string)rdr["Locatie_Naam"];
                product.Locatie.Postcode = (string)rdr["Locatie_Postcode"];
                product.Locatie.IsRestaurant = (bool)rdr["Restaurant"];
            }
            rdr.Close();
            if (product.Locatie.IsRestaurant)
            {
                Restaurant restaurant = new Restaurant();
                sql = string.Format("SELECT * FROM Restaurants WHERE Locatie_ID = {0};", product.Locatie.Locatie_ID);
                command = new SqlCommand(sql, conn);
                rdr = command.ExecuteReader();
                if (rdr.Read())
                {
                    restaurant = new Restaurant { ID = product.ID, Naam = product.Naam, Beschrijving = product.Beschrijving, Locatie = product.Locatie, Plaatsen = product.Plaatsen, Keuken = (string)rdr["Soort_Keuken"], Openingstijd = (DateTime)rdr["Openingstijd"], Dinnerswitch = (DateTime)rdr["Dinertijd"], Sluitingstijd = (DateTime)rdr["Sluitingstijd"], Dag = (string)rdr["Dag"] };
                    //Checken of dit werkt.
                }
                conn.Close();
                return restaurant;
            }
            conn.Close();
            return new Restaurant();
        }

        public static List<Product> GetAllProducts()
        {
            List<Product> AlleProducten = new List<Product>();
            conn = new SqlConnection(connString);
            conn.Open();
            sql = string.Format("SELECT * FROM Producten");
            command = new SqlCommand(sql, conn);
            SqlDataReader rdr = command.ExecuteReader();
            while (rdr.Read())
            {
                AlleProducten.Add(new Product { ID = (int)rdr["Item_ID"], Beschrijving = (string)rdr["Item_Beschrijving"], Locatie = GetLocatie((int)rdr["Item_LocatieID"]), Naam = (string)rdr["Item_Naam"], Plaatsen = (int)rdr["Plaatsen"], Dag = (string)rdr["Dag"] });
            }
            conn.Close();
            return AlleProducten;
        }

        public static List<Restaurant> GetAllRestaurants()
        {
            List<Restaurant> AlleRestaurants = new List<Restaurant>();
            List<Locatie> AlleRestaurantLocaties = new List<Locatie>();
            List<int> RestaurantIDs = new List<int>();
            conn = new SqlConnection(connString);
            conn.Open();
            sql = string.Format("SELECT * FROM Locaties where Restaurant = 1");
            command = new SqlCommand(sql, conn);
            SqlDataReader rdr = command.ExecuteReader();
            while (rdr.Read())
            {
                AlleRestaurantLocaties.Add(new Locatie { Locatie_ID = (int)rdr["Locatie_ID"], Naam = (string)rdr["Locatie_Naam"], Adres = string.Format((string)rdr["Locatie_Straatnaam"] + " " + (int)rdr["Locatie_Huisnummer"]), Postcode = (string)rdr["Locatie_Postcode"] });
            }
            rdr.Close();
            foreach(Locatie L in AlleRestaurantLocaties)
            {
                RestaurantIDs.Add(L.Locatie_ID);
            }
            sql = string.Format("SELECT * FROM Producten");
            command = new SqlCommand(sql, conn);
            rdr = command.ExecuteReader();
            while (rdr.Read())
            {
                if (RestaurantIDs.Contains((int)rdr["Item_LocatieID"]))
                {
                    AlleRestaurants.Add(new Restaurant { ID = (int)rdr["Item_ID"], Beschrijving = (string)rdr["Item_Beschrijving"], Locatie = AlleRestaurantLocaties[RestaurantIDs.IndexOf((int)rdr["Item_LocatieID"])], Naam = (string)rdr["Item_Naam"], Plaatsen = (int)rdr["Plaatsen"]});
                }
            }
            conn.Close();
            return AlleRestaurants;
        }

        private static bool WishListExists(int wishListCode)
        {
            conn = new SqlConnection(connString);
            conn.Open();
            sql = string.Format("SELECT COUNT(*) from Wishlist WHERE Wishlist_Code = {0}", wishListCode);
            command = new SqlCommand(sql, conn);
            if((int)command.ExecuteScalar() > 0)
            {
                return true;
            }
            return false;
            conn.Close();
        }

        public static int GetWishlistID(int wishListCode)
        {
            if (!WishListExists(wishListCode)) return 0;
            conn = new SqlConnection(connString);
            conn.Open();
            sql = string.Format("SELECT Wishlist_ID from Wishlist WHERE Wishlist_Code = {0}", wishListCode);
            command = new SqlCommand(sql, conn);
            return (int)command.ExecuteScalar();
            conn.Close();
        }

        public static Locatie GetLocatie(int id)
        {
            Locatie loc = new Locatie();
            conn = new SqlConnection(connString);
            conn.Open();
            sql = string.Format("SELECT * FROM Locaties WHERE Locatie_ID = {0}", id);
            command = new SqlCommand(sql, conn);
            SqlDataReader rdr = command.ExecuteReader();
            if (rdr.Read())
            {
                loc.Adres = string.Format((string)rdr["Locatie_Straatnaam"] + " " + (int)rdr["Locatie_Huisnummer"]);
                loc.Naam = (string)rdr["Locatie_Naam"];
                loc.Postcode = (string)rdr["Locatie_Postcode"];
                loc.IsRestaurant = (bool)rdr["Restaurant"];
            }
            rdr.Close();
            conn.Close();
            return loc;
        }
    }
}
