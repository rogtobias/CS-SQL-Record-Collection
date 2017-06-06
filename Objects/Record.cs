using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace RecordCollection
{
  public class Record
  {
    private int _id;
    private string _artist;

    public Record(string Artist, int Id = 0)
    {
      _id = Id;
      _artist = Artist;
    }
    public override bool Equals(System.Object otherRecord)
    {
      if(!(otherRecord is Record))
      {
        return false;
      }
      else
      {
        Record newRecord = (Record) otherRecord;
        bool artistEquality = (this.GetArtist() == newRecord.GetArtist());
        return (artistEquality);
      }
    }

    public int GetId()
    {
      return _id;
    }
    public string GetArtist()
    {
      return _artist;
    }
    public void SetArtist(string newArtist)
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
    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO records (artist) OUTPUT INSERTED.id VALUES (@RecordArtist);", conn);

      SqlParameter artistParameter = new SqlParameter();
      artistParameter.ParameterName = "@RecordArtist";
      artistParameter.Value = this.GetArtist();
      cmd.Parameters.Add(artistParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
    }
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM records;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }
    public static Record Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM records WHERE id = @RecordId;", conn);
      SqlParameter recordIdParameter = new SqlParameter();
      recordIdParameter.ParameterName = "@RecordId";
      recordIdParameter.Value = id.ToString();
      cmd.Parameters.Add(recordIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundRecordId = 0;
      string foundRecordArtist = null;
      while(rdr.Read())
      {
        foundRecordId = rdr.GetInt32(0);
        foundRecordArtist = rdr.GetString(1);
      }
      Record foundRecord = new Record(foundRecordArtist, foundRecordId);

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return foundRecord;
    }
  }
}
