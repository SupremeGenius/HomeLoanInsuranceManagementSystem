using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using HLIMS.Entities;
namespace HLIMS.Services.Business
{
    public class BankManager
	{
        public IList<Bank> GetBankList()
        {
            IList<Bank> data = getFromCache();
            if (data== null || data.Count==0)
            {
                data = getBankData();
                updateCache(data);
            }
            return data;
        }
        public void InsertBankData(Bank bank)
        {
            using (var ctx = new HLIMSYSTEMEntities())
            {
                ctx.tblBanks.Add(new tblBank()
                {
                    Name = bank.Name
                });
                ctx.SaveChanges();
                IList<Bank> bnkList = getBankData();
                updateCache(bnkList);
            }
        }
        public void UpdateBankData(Bank bank)
        {
            using (var ctx = new HLIMSYSTEMEntities())
            {
                var data = ctx.tblBanks.First<tblBank>();
                data.Name = bank.Name;
                ctx.SaveChanges();

                IList<Bank> bnkList= getBankData();
                updateCache(bnkList);
            }
        }
        private IList<Bank> getBankData()
        {
            IList<Bank> data = null;
            using (var ctx = new HLIMSYSTEMEntities())
            {
                data = ctx.tblBanks.Select(s => new Bank()
                {
                    Id = s.Id,
                    Name = s.Name
                }).ToList<Bank>();
            }
            return data;
        }
        private void updateCache(IList<Bank> data)
        {
            var cache = CacheManager.Connection.GetDatabase();
            var objectString = cache.StringGet(@"BANK_CACHE");
            objectString = JSONSerializer.Serialize(data);
            cache.StringSet(@"BANK_CACHE", objectString);

        }
        private IList<Bank> getFromCache()
        {
            IList<Bank> data = null;
            var cache = CacheManager.Connection.GetDatabase();
            var objectString = cache.StringGet(@"BANK_CACHE");

            if (!objectString.IsNullOrEmpty)
            {
                data = JSONSerializer.DeserializeBankList(objectString);
            }
            return data;
        }
	}
}