using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop_4M_DataAccess.Repository.IRepository;
using OnlineShop_4M_Models;
using OnlineShop_4M_Models.ViewModels;
using OnlineShop_4M_Utility;

namespace OnlineShop_4M.Controllers
{
    [Authorize(Roles =PathManager.AdminRole)]
    public class InquiryController : Controller
    {
        private IInquiryHeaderRepository inquiryHeaderRepository;
        private IInquiryDetailRepository inquiryDetailRepository;
        [BindProperty]
        public InquiryViewModel InquiryViewModel { get; set; }
        public InquiryController(IInquiryHeaderRepository inquiryHeaderRepository, IInquiryDetailRepository inquiryDetailRepository)
        {
            this.inquiryHeaderRepository = inquiryHeaderRepository;
            this.inquiryDetailRepository = inquiryDetailRepository;
        }
        public IActionResult Details(int id)
        {
            InquiryViewModel = new InquiryViewModel()
            {
                InquiryHeader = inquiryHeaderRepository.FirstOrDefault(x => x.Id == id),
                InquiryDetails = inquiryDetailRepository.GetAll(x => x.InquiryHeaderId == id, includeProperties: "Product")
            };
            return View(InquiryViewModel);
        }
        [HttpPost]
        public IActionResult Delete()
        {
            InquiryHeader inquiryHeader=inquiryHeaderRepository.FirstOrDefault(x=>x.Id==InquiryViewModel.InquiryHeader.Id);
            IEnumerable<InquiryDetail> inquiryDetails = inquiryDetailRepository.GetAll(x => x.InquiryHeaderId ==InquiryViewModel.InquiryHeader.Id);
            inquiryDetailRepository.RemoveRange(inquiryDetails);
            inquiryHeaderRepository.Remove(inquiryHeader);
            inquiryDetailRepository.Save();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult ConvertToCart()
        {
            List<ShoppingCart> shoppingCarts = new List<ShoppingCart>();

            InquiryViewModel.InquiryDetails=inquiryDetailRepository.GetAll(x=>x.InquiryHeaderId==InquiryViewModel.InquiryHeader.Id);

            foreach (var item in InquiryViewModel.InquiryDetails)
            {
                ShoppingCart shoppingCart = new ShoppingCart()
                {
                    ProductId = item.ProductId
                };
                shoppingCarts.Add(shoppingCart);
            }
            HttpContext.Session.Clear();
            HttpContext.Session.Set(PathManager.SessionCart,shoppingCarts);
            HttpContext.Session.Set(PathManager.SessionInquiryId, InquiryViewModel.InquiryHeader.Id);
            return RedirectToAction("Index","Cart");
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetInquiryList() 
        {
            var result = Json( new {data=inquiryHeaderRepository.GetAll()});
            return result;
        }
    }
}
