﻿using OnlineShop_4M_DataAccess.Data;
using OnlineShop_4M_DataAccess.Repository.IRepository;
using OnlineShop_4M_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop_4M_DataAccess.Repository
{
    public class InquiryHeaderRepository : Repository<InquiryHeader>, IInquiryHeaderRepository
    {
        private readonly ApplicationDbContext context;
        public InquiryHeaderRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
        public void Update(InquiryHeader obj)
        {
            context.InquiryHeader.Update(obj);
        }
    }
}
