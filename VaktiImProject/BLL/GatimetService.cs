using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaktiImProject.Models;


namespace VaktiImProject.BLL
{
    public class GatimetService
    {
        private readonly Vakti_Im_Entities _db;
        public GatimetService()
        {
            _db = new Vakti_Im_Entities();
        }
        public List<GATIM> MerrListenEGatimeve()
        {
            return _db.GATIMs
                .Where(g => g.disponueshmeria == true)
                .AsEnumerable()
                .Select(p => new GATIM
                {
                    gatim_id = p.gatim_id,
                    emriGatimit = p.emriGatimit,
                    KATEGORI = p.KATEGORI,
                    pershkrimi = p.pershkrimi

                }).ToList();
        }
    }
}