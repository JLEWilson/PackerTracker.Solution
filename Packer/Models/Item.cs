using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Packer.Models
{
    public class Item
    {
      public string Name { get; set; }
      public bool Purchased { get; set; }
      public bool Packed { get; set; }
      public int Price { get; set; }
      public string Source { get; set; }
      public int Id { get; set;}
      public Item(string name, bool purchased, bool packed, int price, string source)
      {
        Name = name;
        Purchased = purchased;
        Packed = packed;
        Price = price;
        Source = source;
      }
      public Item(string name, bool purchased, bool packed, int price, string source, int id)
      {
        Name = name;
        Purchased = purchased;
        Packed = packed;
        Price = price;
        Source = source;
        Id = id;
      }
      public override bool Equals(System.Object otherItem)
      {
        if(!(otherItem is Item))
        {
          return false;
        }
        else
        {
          Item newItem = (Item) otherItem;
          bool idEquality = (this.Id == newItem.Id);
          bool nameEquality = (this.Name == newItem.Name);
          bool purchasedEquality = (this.Purchased == newItem.Purchased);
          bool packedEquality = (this.Packed == newItem.Packed);
          bool sourceEquality = (this.Source == newItem.Source);
          bool priceEquality = (this.Price == newItem.Price);
          return (idEquality && nameEquality && purchasedEquality && packedEquality && sourceEquality && priceEquality);
        }
      }
      public void Save()
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;

        cmd.CommandText = @"INSERT INTO items (name, purchased, packed, price, source) VALUES (@itemName, @itemPurchased, @itemPacked, @itemPrice, @itemSource)";
        MySqlParameter name = new MySqlParameter();
        name.ParameterName = "@itemName";
        name.Value = this.Name;
        MySqlParameter purchased = new MySqlParameter();
        purchased.ParameterName = "@itemPurchased";
        purchased.Value = this.Purchased;
        MySqlParameter packed = new MySqlParameter();
        packed.ParameterName = "@itemPacked";
        packed.Value = this.Packed;
        MySqlParameter price = new MySqlParameter();
        price.ParameterName = "@itemPrice";
        price.Value = this.Price;
        MySqlParameter source = new MySqlParameter();
        source.ParameterName = "@itemSource";
        source.Value = this.Source;
        cmd.Parameters.Add(name);
        cmd.Parameters.Add(purchased);
        cmd.Parameters.Add(packed);
        cmd.Parameters.Add(price);
        cmd.Parameters.Add(source);
        cmd.ExecuteNonQuery();
        Id = (int) cmd.LastInsertedId;

        conn.Close();
        if(conn != null)
        {
          conn.Dispose();
        }
      }
      public static List<Item> GetAll()
      {
        List<Item> allItems = new List<Item>{};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM items";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          int itemId = rdr.GetInt32(0);
          string itemName = rdr.GetString(1);
          bool itemPurchased = rdr.GetBoolean(2);
          bool itemPacked = rdr.GetBoolean(3);
          int itemPrice = rdr.GetInt32(4);
          string itemSource = rdr.GetString(5);
          Item newItem = new Item(itemName, itemPacked, itemPurchased, itemPrice, itemSource, itemId);
          allItems.Add(newItem);
        }
        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }
        return allItems;
      }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE from items;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static Item Find(int searchId)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM items WHERE id = @thisId;";
      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@thisId";
      thisId.Value = searchId;
      cmd.Parameters.Add(thisId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int itemId = 0;
      string itemName = "";
      bool itemPurchased = false;
      bool itemPacked = false;
      int itemPrice = 0;
      string itemSource = "";
      
      while (rdr.Read())
      {
        itemId = rdr.GetInt32(0);
        itemName = rdr.GetString(1);
        itemPurchased = rdr.GetBoolean(2);
        itemPacked = rdr.GetBoolean(3);
        itemPrice = rdr.GetInt32(4);
        itemSource = rdr.GetString(5);
      }
      Item foundItem = new Item(itemName, itemPurchased, itemPacked, itemPrice, itemSource, itemId);

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundItem;
    }

    public static List<Item> GetUnpacked()
    {
      List<Item> unpackedItems = new List<Item>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM items WHERE @itemPacked = 0;";
      MySqlParameter packed = new MySqlParameter();
      packed.ParameterName = "@itemPacked";
      packed.Value = false;
      cmd.Parameters.Add(packed);

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int itemId = rdr.GetInt32(0);
        string itemName = rdr.GetString(1);
        bool itemPurchased = rdr.GetBoolean(2);
        bool itemPacked = rdr.GetBoolean(3);
        int itemPrice = rdr.GetInt32(4);
        string itemSource = rdr.GetString(5);
        Item unpackedItem = new Item(itemName, itemPacked, itemPurchased, itemPrice, itemSource);
        unpackedItems.Add(unpackedItem);
      }

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return unpackedItems;
    }
  }
}
