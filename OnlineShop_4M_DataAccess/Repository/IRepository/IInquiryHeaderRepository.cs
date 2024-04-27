using OnlineShop_4M_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop_4M_DataAccess.Repository.IRepository
{
    public interface IInquiryHeaderRepository:IRepository<InquiryHeader>
    {
        void Update(InquiryHeader obj);

    }
}
