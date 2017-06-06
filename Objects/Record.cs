using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace RecordCollection
{
  public class RecordCollection
  {
    private int _id;
    private string _artist;

    public Record(string Artist, int Id = 0)
    {
      _id = Id;
      _artist = Artist;
    }

    public int GetId()
    {
      return _id;
    }
    public string GetArtist()
    {
      return _artist;
    }
    public void SetArtist()
    {
      _artist = newArtist;
    }

    public static List<Record> GetAll()
    {
      List<Record> allRecords = new List<Record>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM records;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int recordId = rdr.GetInt32(0);
        string recordArtist = rdr.GetString(1);
        Record newRecord = new Record(recordArtist, recordId);
        allRecords.Add(newRecord);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if ( conn != null)
      {
        conn.Close();
      }
      return allRecords;
    }
  }
}
