using Sabio.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sabio.Models.Domain;
using Sabio.Models.Requests;
using Sabio.Data.Providers;
using System.Data.SqlClient;
using System.Data;
using Sabio.Data;

namespace Sabio.Services
{
    public class PathwayServices : IPathwayServices
    {
        readonly IDataProvider dataProvider;
      

        public PathwayServices(IDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }

        public List<PathwayOnlyIdAndName> SelectOnlyIdAndName()
        {
            List<PathwayOnlyIdAndName> list = null;

            dataProvider.ExecuteCmd("dbo.Pathway_SelectOnlyIdAndName"
                , inputParamMapper: null
                , singleRecordMapper: delegate (IDataReader reader, short set)
                {
                    PathwayOnlyIdAndName singleItem = new PathwayOnlyIdAndName();
                    int startingIndex = 0;

                    singleItem.Id = reader.GetSafeInt32(startingIndex++);
                    singleItem.Name = reader.GetSafeString(startingIndex++);

                    if (list == null)
                    {
                        list = new List<PathwayOnlyIdAndName>();
                    }
                    list.Add(singleItem);
                }
                );
            return list;
        }
    }
}
