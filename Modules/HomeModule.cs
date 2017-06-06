using Nancy;
using RecordCollection;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RecordCollection
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => View["index.cshtml"];

      Post["/new"] = _ => {
        Record newRecord = new Record(Request.Form["artist"]);
        newRecord.Save();
        return View["new-artist.cshtml", newRecord];
      };

      Get["/view_all"] = _ => {
        List<Record> allRecords = Record.GetAll();
        return View["view_all.cshtml", allRecords];
      };
    }
  }
}
