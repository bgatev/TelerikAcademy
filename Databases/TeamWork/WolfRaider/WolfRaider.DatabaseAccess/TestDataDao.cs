using System.Collections.Generic;
using WolfRaider.Common.Models;

namespace WolfRaider.DatabaseAccess
{
    public class TestDataDao : ITestDataDao<TestData>
    {
        public void Insert(TestData data)
        {
           
        }

        public List<TestData> List()
        {
            throw new System.NotImplementedException();
        }
    }
}
