using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace RecordCollection
{
  public class AlbumnTest : IDisposable
  {
    public AlbumnTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=record_collection_tests;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_AlbumnsEmptyAtFirst()
    {
      //Arrange, Act
      int result = Albumn.GetAll().Count;

      //Assert
      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Equal_ReturnsTrueForSameTitle()
    {
      //Arrange, Act
      Albumn firstAlbumn = new Albumn("Pork Soda");
      Albumn secondAlbumn = new Albumn("Pork Soda");

      //Assert
      Assert.Equal(firstAlbumn, secondAlbumn);
    }

    [Fact]
    public void Test_Save_SavesAlbumnToDatabase()
    {
      //Arrange
      Albumn testAlbumn = new Albumn("Pork Soda");
      testAlbumn.Save();

      //Act
      List<Albumn> result = Albumn.GetAll();
      List<Albumn> testList = new List<Albumn>{testAlbumn};

      //Assert
      Assert.Equal(testList, result);
    }
    [Fact]
    public void Test_Save_AssignsIdToAlbumnObject()
    {
      //Arrange
      Albumn
    }
  }
}
