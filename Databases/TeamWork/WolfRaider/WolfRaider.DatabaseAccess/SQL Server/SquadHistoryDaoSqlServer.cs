using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WolfRaider.Common.Models;
using WolfRaider.DatabaseAccess.Connections;
using WolfRaider.DatabaseAccess.Contracts;

namespace WolfRaider.DatabaseAccess
{
    public class SquadHistoryDaoSqlServer :IGeneralDao<SquadHistory>
    {
        public SquadHistoryDaoSqlServer() 
        {
        }

       
        public void Insert(SquadHistory squadHistory)
        {
            var context = new WolfRaiderContext();

            using (context)
            {
                context.SquadHistories.Add(squadHistory);
                context.SaveChanges();
            }
            
        }

        public void Delete(SquadHistory squadHistory)
        {
            WolfRaiderContext context = new WolfRaiderContext();

            using (context)
            {
                SquadHistory existing = context.SquadHistories.First(x => x.SquadHistoryId == squadHistory.SquadHistoryId);

                context.SquadHistories.Remove(existing);
                int affectedRows = context.SaveChanges();
                Console.WriteLine("{0} rows affected", affectedRows);
            }
        }

        public void Update(SquadHistory squadHistory)
        {
           WolfRaiderContext context = new WolfRaiderContext();

           using (context)
           {
               SquadHistory existing = context.SquadHistories.First(x => x.SquadHistoryId == squadHistory.SquadHistoryId);
              
               existing.RedCards = squadHistory.RedCards;
               int affectedRows = context.SaveChanges();
               Console.WriteLine("{0} rows affected", affectedRows);
           }
        }

        public IEnumerable<SquadHistory> ListAll()
        {
            WolfRaiderContext context = new WolfRaiderContext();

            List<SquadHistory> list = new List<SquadHistory>();
            //using (context)
            //{
                list = context.SquadHistories.ToList();
            //}
          
            return list;
        }

        public IEnumerable<SquadHistory> Find(Expression<Func<SquadHistory, bool>> condition)
        {
            var context = new WolfRaiderContext();

            List<SquadHistory> list = new List<SquadHistory>();

            using (context)
            {
                list = context.SquadHistories.Where(condition).ToList();
            }

            return list;
        }
    }
}
