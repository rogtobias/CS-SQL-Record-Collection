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
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=record_collection_test;Integrated Security=SSPI;";
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
  }
}
