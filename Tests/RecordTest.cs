using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace RecordCollection
{
  public class RecordCollectionTest : IDisposable
  {
    public RecordCollectionTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=record_collection_tests;Integrated Security=SSPI;";
    }
    public void Dispose()
    {
      Record.DeleteAll();
    }

    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      //Arrange, Act
      int result = Record.GetAll().Count;

      //Assert
      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Equal_ReturnsTrueIfArtistAreTheSame()
    {
      //Arrange, Act
      Record firstRecord = new Record("Primus");
      Record secondRecord = new Record("Primus");

      //Assert
      Assert.Equal(firstRecord, secondRecord);
    }
    [Fact]
    public void Test_Save_SavesToDatabase()
    {
      //Arrange
      Record testRecord = new Record("Primus");
      //Act
      testRecord.Save();
      List<Record> result = Record.GetAll();
      List<Record> testList = new List<Record>{testRecord};

      //Assert
      Assert.Equal(testList, result);
    }
    [Fact]
    public void Test_Find_FindsRecordInDatabase()
    {
      //Arrange
      Record testRecord = new Record("Primus");
      testRecord.Save();

      //Act
      Record foundRecord = Record.Find(testRecord.GetId());

      //Assert
      Assert.Equal(testRecord, foundRecord);
    }

  }
}
